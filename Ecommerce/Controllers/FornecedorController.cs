using AutoMapper;
using Ecommerce.DAO;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class FornecedorController : Controller
    {
        public ActionResult Index()
        {
            FornecedorDAO dao = new FornecedorDAO();
            IList<Fornecedor> fornecedores = dao.Lista();
            ViewBag.Fornecedores = fornecedores;
            return View();
        }

        public ActionResult Detalhes(int id)
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            FornecedorDAO dao = new FornecedorDAO();
            var fornecedor = Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(dao.Lista());
            ViewBag.Fornecedor = fornecedor;

            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedorViewModel);
            FornecedorDAO dao = new FornecedorDAO();
            dao.Adicionar(fornecedor);


            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            var dao = new FornecedorDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);
            ViewBag.Fornecedor = fornecedorViewModel;
            return View(fornecedorViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(int id, FornecedorViewModel fornecedorViewModel)
        {
            fornecedorViewModel.Id = id;
            if (ModelState.IsValid)
            {
                var dao = new FornecedorDAO();
                var fornecedor = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedorViewModel);

                dao.Atualizar(fornecedor);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Atualiza(int id)
        {
            var dao = new FornecedorDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            return View(fornecedor);
        }

        public ActionResult Remover(int id)
        {
            var dao = new FornecedorDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            dao.Remover(fornecedor);
            return RedirectToAction("Index");
        }
    }
}
