using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
namespace SP_Trial.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please Enter Password!")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
