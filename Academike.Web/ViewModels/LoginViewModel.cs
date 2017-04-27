using System.ComponentModel.DataAnnotations;

namespace Academike.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserNameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembre-me")]
        public bool RememberMe { get; set; }
    }
}