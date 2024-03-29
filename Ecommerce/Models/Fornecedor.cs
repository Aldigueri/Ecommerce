﻿using Ecommerce.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required]
        public string NomeEmpresa { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [CPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        public Fornecedor()
        {

        }

        public Fornecedor(string nomeEmpresa, string nome, string cpf)
        {
            CPF validaCPF = new CPF();

            NomeEmpresa = nomeEmpresa;
            Nome = nome;

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