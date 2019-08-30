using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class HistoricoComprasDAO
    {
        public void Adiciona(HistoricoCompras compras)
        {
            using (var context = new EcommerceContext())
            {
                context.Compras.Add(compras);
                context.SaveChanges();
            }
        }

        private readonly EcommerceContext contexto;
        public IList<HistoricoCompras> Lista()
        {
            return contexto.Compras.ToList();
        }

        public HistoricoCompras BuscaPorId(int id)
        {
            return contexto.Compras.Find(id);
        }
    }
}