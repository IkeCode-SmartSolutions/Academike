using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academike.Web.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "O {0} precisa ter no minimo {1} caracteres")]
        [Display(Name = "Nome completo")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "O {0} precisa ter no minimo {1} caracteres")]
        [Display(Name = "Nome de usuário")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "A {0} precisa ter no minimo {1} caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Eu concordo com os Termos de Condições de Uso")]
        public bool TermAccepted { get; set; }
    }
}
