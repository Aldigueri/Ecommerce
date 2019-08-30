using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class HistoricoCompras
    {
        public int Id { get; set; }

        
        public virtual Produto Produto { get; set; }
        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }

       
        public virtual Categoria Categoria { get; set; }
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }

       
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public DateTime DataPedido { get; set; }

        public HistoricoCompras()
        {

        }

        public HistoricoCompras(int usuarioId, int produtoId, int categoriaId)
        {
            UsuarioId = usuarioId;
            ProdutoId = produtoId;
            CategoriaId = categoriaId;
            DataPedido = DateTime.Now;
        }


    }
}