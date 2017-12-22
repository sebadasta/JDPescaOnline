using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JDPesca.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El campo Email es Obligatorio")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "El campo Telefono es Obligatorio")]
        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "El campo Nombre es Obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido es Obligatorio")]
        [Display(Name = "Apellido")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "El campo Password es Obligatorio")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password", ErrorMessage = "Las contrasenas no coinciden!!!")]
        public string ConfirmPassword { get; set; }
    }
}
