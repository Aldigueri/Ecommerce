using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class ProdutoDAO
    {
        private readonly EcommerceContext contexto;

        public ProdutoDAO()
        {
            contexto = new EcommerceContext();
        }

        public void Adicionar(Produto Produto)
        {
            contexto.Produtos.Add(Produto);
            contexto.SaveChanges();
        }

        public IList<Produto> Lista()
        {
            return contexto.Produtos.ToList();
        }

        public void Atualizar(Produto Produto)
        {
            contexto.Entry(Produto).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Produto BuscaPorId(int id)
        {
            return contexto.Produtos.Find(id);
        }

        public void Recuperar()
        {
            using (var contexto = new EcommerceContext())
            {
                IList<Produto> Produto = contexto.Produtos.ToList();
            }
        }

        public void Remover(Produto Produto)
        {
            contexto.Produtos.Remove(Produto);
            contexto.SaveChanges();
        }
    }
}