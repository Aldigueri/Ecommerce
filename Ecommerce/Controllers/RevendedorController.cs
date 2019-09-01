using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAO;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using AutoMapper;

namespace Ecommerce.Controllers
{
    public class RevendedorController : Controller
    {
        public ActionResult Index()
        {
            RevendedorDAO dao = new RevendedorDAO();
            IList<Revendedor> revendedores = dao.Lista();
            ViewBag.Revendedores = revendedores;
            return View();
        }

        public ActionResult Detalhes(int id)
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            RevendedorDAO dao = new RevendedorDAO();
            var revendedores = Mapper.Map<IEnumerable<Revendedor>, IEnumerable<RevendedorViewModel>>(dao.Lista());
            ViewBag.Revendedor = revendedores;

            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(RevendedorViewModel revendedorViewModel)
        {
            var revendedores = Mapper.Map<RevendedorViewModel, Revendedor>(revendedorViewModel);
            RevendedorDAO dao = new RevendedorDAO();
            dao.Adicionar(revendedores);


            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            var dao = new RevendedorDAO();
            Revendedor revendedor = dao.BuscaPorId(id);
            var revendedorViewModel = Mapper.Map<Revendedor, RevendedorViewModel>(revendedor);
            ViewBag.Revendedor = revendedorViewModel;
            return View(revendedorViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(int id, RevendedorViewModel revendedorViewModel)
        {
            revendedorViewModel.Id = id;
            if (ModelState.IsValid)
            {
                var dao = new RevendedorDAO();
                var revendedor = Mapper.Map<RevendedorViewModel, Revendedor>(revendedorViewModel);

                dao.Atualizar(revendedor);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Atualiza(int id)
        {
            var dao = new RevendedorDAO();
            Revendedor revendedor = dao.BuscaPorId(id);
            return View(revendedor);
        }

        public ActionResult Remover(int id)
        {
            var dao = new RevendedorDAO();
            Revendedor revendedor = dao.BuscaPorId(id);
            dao.Remover(revendedor);
            return RedirectToAction("Index");
        }
    }
}