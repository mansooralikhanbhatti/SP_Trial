using System.ComponentModel.DataAnnotations;

namespace SP_Trial.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
