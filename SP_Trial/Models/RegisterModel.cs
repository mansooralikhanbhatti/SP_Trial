using System.ComponentModel.DataAnnotations;
namespace SP_Trial.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password!")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
