using Ecommerce.Context;
using Ecommerce.DAO;
using Ecommerce.Filtros;
using Ecommerce.Models;
using Ecommerce.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    [AutorizacaoFilter(Roles = new UsuarioTipo[] { UsuarioTipo.Cliente, UsuarioTipo.Administrador })]
    public class HistoricoComprasController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        HistoricoComprasDAO historicoComprasDAO = new HistoricoComprasDAO();
        ProdutoDAO produtoDAO = new ProdutoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        Usuario usuario = new Usuario();
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        // GET: HistoricoCompras
        [AutorizacaoFilter(Roles = new UsuarioTipo[] { UsuarioTipo.Administrador, UsuarioTipo.Cliente })]
        public ActionResult Index()
        {

            var compras = db.Compras.Select(x => x).ToList();
            foreach (var compra in compras)
            {
                compra.Produto = produtoDAO.BuscaPorId(compra.ProdutoId);
                compra.Categoria = categoriaDAO.BuscaPorId(compra.CategoriaId);
                compra.Usuario = usuarioDAO.BuscaPorId(compra.UsuarioId);
            }


            var user = (Usuario)Session["usuarioLogado"];
            if (user.UsuarioTipo == UsuarioTipo.Cliente)
            {
                var Usuario = usuarioDAO.BuscaPorId(user.Id);
                //filtragem de produto por usuário cliente
                var cliente = compras.Where(r => r.UsuarioId == user.Id).ToList();           
                return View(cliente);
            }

            return View(compras);
           
        }

    }
}