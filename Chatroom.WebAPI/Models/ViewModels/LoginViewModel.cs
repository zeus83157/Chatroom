using System.ComponentModel.DataAnnotations;

namespace Chatroom.WebAPI.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
