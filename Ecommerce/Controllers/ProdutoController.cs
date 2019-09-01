using Ecommerce.Context;
using Ecommerce.DAO;
using Ecommerce.Filtros;
using Ecommerce.Models;
using Ecommerce.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecommerce.Controllers
{
  
    public class ProdutoController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        ProdutoDAO produtoDAO = new ProdutoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();


        
        public ActionResult Index()
        {
            var produtos = db.Produtos.Select(x => x).ToList();
            foreach (var produto in produtos)
            {
                produto.Categoria = categoriaDAO.BuscaPorId(produto.CategoriaId);
            }

            return View(produtos);
        }

        // GET: Produtoes/Details/5
        public ActionResult Detalhes(int? id)
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

        // GET: Produtoes/Create
        public ActionResult Criar()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtoes/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar([Bind(Include = "Id,Nome,CategoriaId,Preco,Quantidade,Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                //Converte de inputStream para base64
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    byte[] buffer = new byte[file.InputStream.Length];
                    file.InputStream.Read(buffer, 0, buffer.Length);
                    produto.Img = Convert.ToBase64String(buffer);
                }
                //add e salva produto
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Editar(int? id)
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
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Nome,CategoriaId,Preco,Quantidade,Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    //Converte de inputStream para base64 para salvar no banco
                    HttpPostedFileBase file = Request.Files[0];
                    byte[] buffer = new byte[file.InputStream.Length];
                    file.InputStream.Read(buffer, 0, buffer.Length);
                    produto.Img = Convert.ToBase64String(buffer);
                }
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Deletar(int? id)
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

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletadoSucesso(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorId(id);         
            produto.Quantidade--;
            dao.Atualizar(produto);

            GeraRegistroHistorico(produto);
        

   
            return RedirectToAction("DecrementaQtd");
        }

        private void GeraRegistroHistorico(Produto produto)
        {
            var HistoricoCompras = new HistoricoCompras((int)Session["usuarioId"], produto.Id, produto.CategoriaId, produto.Preco);
            var historicoDAO = new HistoricoComprasDAO();
            historicoDAO.Adiciona(HistoricoCompras);

        }


        public ActionResult CompraRealizada()
        {

            return View();
        }
                                     
    }
}