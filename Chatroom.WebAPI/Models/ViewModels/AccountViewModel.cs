using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chatroom.WebAPI.Models.ViewModels
{
    public class AccountViewModel
    {
        [JsonIgnore]
        public Guid UserID { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [JsonIgnore]
        public DateTimeOffset CreateDatetime { get; set; }

        [JsonIgnore]
        public DateTimeOffset UpdatedDatetime { get; set; }

        [Required]
        public string Gender { get; set; }

        [JsonIgnore]
        public int StarSignID { get; set; }
    }
}
