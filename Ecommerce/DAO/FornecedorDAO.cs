using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAO
{
    public class FornecedorDAO
    {
        private readonly EcommerceContext contexto;

        public FornecedorDAO()
        {
            contexto = new EcommerceContext();
        }
        public void Adicionar(Fornecedor fornecedor)
        {
            using (var contexto = new EcommerceContext())
            {
                contexto.Fornecedores.Add(fornecedor);
                contexto.SaveChanges();
            }
        }

        public IList<Fornecedor> Lista()
        {
            using (var contexto = new EcommerceContext())
            {
                return contexto.Fornecedores.ToList();
            }
        }

        public Fornecedor BuscaPorId(int id)
        {
            using (var contexto = new EcommerceContext())
            {
                return contexto.Fornecedores.Find(id);
            }
        }
        //UPDATE
        public void Atualizar(Fornecedor fornecedor)
        {
            using (var contexto = new EcommerceContext())
            {
                contexto.Fornecedores.Update(fornecedor);
                contexto.SaveChanges();
            }
        }


        public void Remover(Fornecedor fornecedor)
        {
            contexto.Fornecedores.Remove(fornecedor);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}