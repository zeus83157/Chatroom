namespace Chatroom.Repositories.Models.Entities
{
    public class UsersWithRoleEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid RoleID { get; set; }
        public DateTimeOffset CreateDatetime { get; set; }
        public DateTimeOffset UpdatedDatetime { get; set; }
    }
}
