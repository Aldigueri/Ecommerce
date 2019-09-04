using Ecommerce.Exceptions;
using Ecommerce.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Login é obrigatório.")]
        public string Login { get; set; }

        [Required]
        [CPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        public UsuarioTipo UsuarioTipo { get; set; }

     
        public string Cep { get; set; }  
        public string NomeRua { get; set; }   
        public int Numero { get; set; }        
        public string Complemento { get; set; }       
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public Usuario()
        {

        }

        public Usuario(string nome, string login, string cpf, string senha, string cep, string nomeRua, int numero, string complemento,
            string bairro, string estado, string cidade)
        {
            CPF validaCPF = new CPF();

            Nome = nome;
            Login = login;
            Senha = senha;
            Cep = cep;
            NomeRua = nomeRua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
            Cidade = cidade;


            //if (validaCPF.IsCpf(cpf) == false)
            //{
            //    throw new CampoInvalidException();
            //}
            //else
            //{
            //    CPF = cpf;
            //}

        }
    }
}