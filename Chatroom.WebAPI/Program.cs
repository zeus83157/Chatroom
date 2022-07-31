using Chatroom.Repositories.Models.EFCoreRepositories;
using Chatroom.Repositories.Models.EFCoreRepositories.ORM;
using Chatroom.Repositories.Models.Interfaces.Repository;
using Chatroom.Utilities.Services;
using Chatroom.WebAPI.Helpers;
using Chatroom.WebAPI.Models;
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
         // �����ҥ��ѮɡA�^�����Y�|�]�t WWW-Authenticate ���Y�A�o�̷|��ܥ��Ѫ��Բӿ��~��]
         options.IncludeErrorDetails = true; // �w�]�Ȭ� true�A���ɷ|�S�O����

         options.TokenValidationParameters = new TokenValidationParameters
         {
             // �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
             NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
             // �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����
             RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",

             // �@��ڭ̳��|���� Issuer
             ValidateIssuer = true,
             ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),

             // �q�`���ӻݭn���� Audience
             ValidateAudience = false,
             //ValidAudience = "JwtAuthDemo", // �����ҴN���ݭn��g

             // �@��ڭ̳��|���� Token �����Ĵ���
             ValidateLifetime = true,

             // �p�G Token ���]�t key �~�ݭn���ҡA�@�볣�u��ñ���Ӥw
             ValidateIssuerSigningKey = false,

             // "1234567890123456" ���ӱq IConfiguration ���o
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:Key")))
         };
     });
builder.Services.AddAuthorization();
builder.Services.AddScoped(typeof(ClaimsPrincipal));

builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(AuthService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
