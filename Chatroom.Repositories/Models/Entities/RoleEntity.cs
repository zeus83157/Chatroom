namespace Chatroom.Repositories.Models.Entities
{
    public class RoleEntity
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTimeOffset CreateDatetime { get; set; }
        public DateTimeOffset UpdatedDatetime { get; set; }
    }
}
