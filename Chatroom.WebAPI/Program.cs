using Chatroom.Repositories.Models.EFCoreRepositories;
using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Interfaces.Repository;
using Chatroom.Repositories.Models.Interfaces.UnitOfWork;
using Chatroom.Repositories.Models.UnitOfWorks;
using Chatroom.Utilities.Services;
using Chatroom.WebAPI.Helpers;
using Chatroom.WebAPI.Models;
using Chatroom.WebAPI.Models.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddDbContext<SampleDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleEntity"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
         options.IncludeErrorDetails = true; // 預設值為 true，有時會特別關閉

         options.TokenValidationParameters = new TokenValidationParameters
         {
             // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
             NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
             // 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
             RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

             // 一般我們都會驗證 Issuer
             ValidateIssuer = true,
             ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),

             // 通常不太需要驗證 Audience
             ValidateAudience = false,
             //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

             // 一般我們都會驗證 Token 的有效期間
             ValidateLifetime = true,

             // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
             ValidateIssuerSigningKey = false,

             // "1234567890123456" 應該從 IConfiguration 取得
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:Key")))
         };

         options.Events = new JwtBearerEvents
         {
             OnMessageReceived = context =>
             {
                 // SignalR 會將 Token 以參數名稱 access_token 的方式放在 URL 查詢參數裡
                 var accessToken = context.Request.Query["access_token"];

                 // 連線網址為 Hubs 相關路徑才檢查
                 var path = context.HttpContext.Request.Path;
                 if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/ChatHub"))
                 {
                    context.Token = accessToken;
                 }
                 return Task.CompletedTask;
             }
         };
     });
builder.Services.AddAuthorization();
builder.Services.AddScoped(typeof(ClaimsPrincipal));

builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUsersWithRoleRepository, UsersWithRoleRepository>();
builder.Services.AddScoped<IUnitOfWork, EFCoreUnitOfWork>();
builder.Services.AddScoped(typeof(AuthService));
builder.Services.AddScoped(typeof(AccountService));

builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.Run();
