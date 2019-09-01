using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; } 
        public double Preco { get; set; }      
        public int Quantidade { get; set; }    
        public string Descricao { get; set; }


    }
}