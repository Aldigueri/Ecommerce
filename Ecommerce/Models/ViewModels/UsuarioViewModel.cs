using Ecommerce.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe seu nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu sobrenome.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Seu nome de usuário é obrigatório.")]
        public string NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Escolha seu perfil.")]
        public UsuarioTipo UsuarioTipo { get; set; }
    }
}