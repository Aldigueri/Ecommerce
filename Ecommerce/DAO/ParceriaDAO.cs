using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class ParceriaDAO
    {
        private readonly EcommerceContext contexto;

        public ParceriaDAO()
        {
            contexto = new EcommerceContext();
        }
        public void Adicionar(Parceria parceria)
        {
            using (var contexto = new EcommerceContext())
            {
                contexto.Parceiros.Add(parceria);
                contexto.SaveChanges();
            }
        }

        public IList<Parceria> Lista()
        {
            using (var contexto = new EcommerceContext())
            {
                return contexto.Parceiros.ToList();
            }
        }

        public Parceria BuscaPorId(int id)
        {
            using (var contexto = new EcommerceContext())
            {
                return contexto.Parceiros.Find(id);
            }
        }
        //UPDATE
        public void Atualizar(Parceria parceria)
        {
            using (var contexto = new EcommerceContext())
            {
                contexto.Parceiros.Update(parceria);
                contexto.SaveChanges();
            }
        }


        public void Remover(Parceria parceria)
        {
            contexto.Parceiros.Remove(parceria);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}