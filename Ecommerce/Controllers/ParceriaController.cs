using AutoMapper;
using Ecommerce.DAO;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ParceriaController : Controller
    {
        public ActionResult Index()
        {
            ParceriaDAO dao = new ParceriaDAO();
            IList<Parceria> parceiros = dao.Lista();
            ViewBag.Parceria = parceiros;
            return View();
        }

        public ActionResult Detalhes(int id)
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            ParceriaDAO dao = new ParceriaDAO();
            var parceiros = Mapper.Map<IEnumerable<Parceria>, IEnumerable<ParceriaViewModel>>(dao.Lista());
            ViewBag.Parceria = parceiros;

            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(ParceriaViewModel parceriaViewModel)
        {
            var parceria = Mapper.Map<ParceriaViewModel, Parceria>(parceriaViewModel);
            ParceriaDAO dao = new ParceriaDAO();
            dao.Adicionar(parceria);


            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            var dao = new ParceriaDAO();
            Parceria parceria = dao.BuscaPorId(id);
            var parceriaViewModel = Mapper.Map<Parceria, ParceriaViewModel>(parceria);
            ViewBag.Parceria = parceriaViewModel;
            return View(parceriaViewModel);
        }

        [HttpPost]
        public ActionResult Alterar(int id, ParceriaViewModel parceriaViewModel)
        {
            parceriaViewModel.Id = id;
            if (ModelState.IsValid)
            {
                var dao = new ParceriaDAO();
                var parceria = Mapper.Map<ParceriaViewModel, Parceria>(parceriaViewModel);

                dao.Atualizar(parceria);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Atualiza(int id)
        {
            var dao = new ParceriaDAO();
            Parceria parceria = dao.BuscaPorId(id);
            return View(parceria);
        }

        public ActionResult Remover(int id)
        {
            var dao = new ParceriaDAO();
            Parceria parceria = dao.BuscaPorId(id);
            dao.Remover(parceria);
            return RedirectToAction("Index");
        }
    }
}