using Ecommerce.Exceptions;

namespace Ecommerce.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string NomeEmpresa { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public Fornecedor()
        {

        }

        public Fornecedor(string nomeEmpresa, string nome, string cpf)
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