using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Produto
    {
        public Produto()
        {

        }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório."), StringLength(30)]
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }

        public virtual Categoria Categoria { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatório.")]
        public string Descricao { get; set; }

        public string Img { get; set; }

        public Produto(int id, string nome, double preco, string descricao, Categoria categoria)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Categoria = categoria;
        }

      
    }
}
