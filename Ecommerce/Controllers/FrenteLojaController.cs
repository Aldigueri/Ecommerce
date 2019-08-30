using Ecommerce.Context;
using Ecommerce.DAO;
using Ecommerce.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class FrenteLojaController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        EcommerceContext contexto = new EcommerceContext();
        // GET: StoreFront
        public ActionResult Index()
        {
            var produtos = db.Produtos.Select(x => x).ToList();
            return View(produtos);
        }

        public ActionResult Produto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            
            return View(produto);
            
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualizar(produto);

            GeraRegistroHistorico(produto);

            return RedirectToAction("CompraRealizada");
        }

        private void GeraRegistroHistorico(Produto produto)
        {
            var HistoricoCompras = new HistoricoCompras((int)Session["usuarioId"], produto.Id, produto.CategoriaId);
            var historicoDAO = new HistoricoComprasDAO();
            historicoDAO.Adiciona(HistoricoCompras);

        }

        public ActionResult CompraRealizada()
        {
            return View();
        }


    }
}