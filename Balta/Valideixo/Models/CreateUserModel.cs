using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Valideixo.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "O usuário é obrigatório")]
        [StringLength(
            10, MinimumLength =3,
            ErrorMessage = "O nome de usuario deve conter entre 3 e 10 caracteres"
        )]
        public string Username { get; set; }

        [Required(ErrorMessage = "O password é obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O salary é obrigatório")]
        public decimal Salary { get; set; }
        
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }
    }

    
}