namespace Chatroom.Repositories.Models.Entities
{
    public class UserEntity
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTimeOffset CreateDatetime { get; set; }
        public DateTimeOffset UpdatedDatetime { get; set; }
        public bool Gender { get; set; }
        public int StarSignID { get; set; }
    }
}
