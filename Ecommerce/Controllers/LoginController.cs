using Ecommerce.Context;
using Ecommerce.DAO;
using Ecommerce.Models;
using Ecommerce.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        private EcommerceContext db = new EcommerceContext();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autentica(String login, String senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            //UsuarioTipo tipo = new UsuarioTipo();
            Usuario usuario = dao.Busca(login, senha);
            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                Session["usuarioId"] = usuario.Id;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        // GET: Login/Create
        public ActionResult Criar()
        {
           
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar([Bind(Include = "Id,Nome,Login,Senha,CPF,Cep,NomeRua,Numero,Complemento,Bairro,Estado,Cidade")] Usuario usuario)
        {
            //Consulta no banco se o login existe
            if (db.Usuarios.Where(x => x.Login == usuario.Login).Count() > 0)
            {
                ModelState.AddModelError("Login", "Login existente.");
            }
            if (db.Usuarios.Where(x => x.CPF == usuario.CPF).Count() > 0)
            {
                ModelState.AddModelError("CPF", "CPF existente.");
            }
            if (ModelState.IsValid)
            {
                //Seta como padrão o usuario na tabela
                usuario.UsuarioTipo = /*(int)*/UsuarioTipo.Cliente;
                //
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            
                                  
            return View(usuario);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Editar
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
           
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Nome,Login,CPF,TipoUsuario,Cep,NomeRua,Numero,Complemento,Bairro,Estado,Cidade")] Usuario usuario)
        {
            //Remove a necessidade de editar a senha
            ModelState.Where(c => c.Key.Equals(nameof(usuario.Senha))).ToList().ForEach(c => ModelState.Remove(c));

            if (ModelState.IsValid)
            {
                UsuarioDAO dao = new UsuarioDAO();
                Usuario up = dao.BuscaPorId(usuario.Id);
                if (string.IsNullOrWhiteSpace(usuario.Senha))
                    usuario.Senha = up.Senha;

                //Salva
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            
            return View(usuario);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();

            return RedirectToAction("Index");

        }

           

    }
}