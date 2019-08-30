using Ecommerce.Context;
using Ecommerce.DAO;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HistoricoComprasController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        HistoricoComprasDAO historicoComprasDAO = new HistoricoComprasDAO();
        ProdutoDAO produtoDAO = new ProdutoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        // GET: HistoricoCompras
        public ActionResult Index()
        {
            var compras = db.Compras.Select(x => x).ToList();
            foreach (var compra in compras)
            {
                compra.Produto = produtoDAO.BuscaPorId(compra.ProdutoId);
                compra.Categoria = categoriaDAO.BuscaPorId(compra.CategoriaId);
                compra.Usuario = usuarioDAO.BuscaPorId(compra.UsuarioId);
            }

            return View(compras);
           
        }

    }
}