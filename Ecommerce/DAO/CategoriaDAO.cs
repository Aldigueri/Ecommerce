using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class CategoriaDAO
    {
        private readonly EcommerceContext contexto;

        public CategoriaDAO()
        {
            contexto = new EcommerceContext();
        }

        public void Adicionar(Categoria Categoria)
        {
            contexto.Categorias.Add(Categoria);
            contexto.SaveChanges();
        }

        public IList<Categoria> Lista()
        {
            return contexto.Categorias.ToList();
        }

        public void Atualizar(Categoria Categoria)
        {
            contexto.Entry(Categoria).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Categoria BuscaPorId(int id)
        {
            return contexto.Categorias.Find(id);
        }

        public void Recuperar()
        {
            using (var contexto = new EcommerceContext())
            {
                IList<Categoria> Categoria = contexto.Categorias.ToList();
            }
        }

        public void Remover(Categoria Categoria)
        {
            contexto.Categorias.Remove(Categoria);
            contexto.SaveChanges();
        }
    }
}