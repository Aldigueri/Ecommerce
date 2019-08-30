using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Categoria
    {
        public Categoria()
        {

        }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição da categoria é obrigatório.")]
        public string Descricao { get; set; }

        public virtual IList<Produto> Produtos { get; set; }

        //public Categoria(int id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}

        //public int Id { get; set; }

        //[Display(Name = "Categoria")]
        //[Required(ErrorMessage = "Nome da Categoria Obrigatório")]
        //[MaxLength(45, ErrorMessage = "O nome da Categoria pode ter no máximo 45 Caracteres")]
        //public string Nome { get; set; }
        //public int ProdutoId { get; set; }

        //[ForeignKey("ProdutoId")]
        //public ICollection<Produto> Produtos { get; set; }
    }
}