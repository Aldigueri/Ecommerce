using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Context;
using Ecommerce.Models;

namespace Ecommerce.DAO
{
    public class RevendedorDAO
    {
        private readonly EcommerceContext contexto;

        public RevendedorDAO()
        {
            contexto = new EcommerceContext();
        }
        public void Adicionar(Revendedor revendedor)
        {
            using (var contexto = new EcommerceContext())
            {
                contexto.Revendedores.Add(revendedor);
                contexto.SaveChanges();
            }
        }

        public IList<Revendedor> Lista()
        {
            using (var contexto = new EcommerceContext())
            {
                return contexto.Revendedores.ToList();
            }
        }

        public Revendedor BuscaPorId(int id)
        {
            using (var contexto = new EcommerceContext())
            {
                return contexto.Revendedores.Find(id);
            }
        }
        //UPDATE
        public void Atualizar(Revendedor revendedor)
        {
            using (var contexto = new EcommerceContext())
            {
                contexto.Revendedores.Update(revendedor);
                contexto.SaveChanges();
            }
        }


        public void Remover(Revendedor revendedor)
        {
            contexto.Revendedores.Remove(revendedor);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
