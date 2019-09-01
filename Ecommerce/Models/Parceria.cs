using Ecommerce.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Parceria
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Parceria()
        {

        }

        public Parceria(string nomeEmpresa, string nome, string cpf)
        {
            CPF validaCPF = new CPF();

            NomeEmpresa = nomeEmpresa;
            Nome = nome;

            if (validaCPF.IsCpf(cpf) == false)
            {
                throw new CampoInvalidException();
            }
            else
            {
                CPF = cpf;
            }

        }
    }
}