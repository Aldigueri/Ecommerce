using Ecommerce.Models;
using Ecommerce.Models.Enum;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ecommerce.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {

        public UsuarioTipo[] Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Setando isLogin como false
            bool isLogin = false;
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario != null && usuario is Usuario)
            {
                //TODO comparar Roles com os tipos do usuario dentro do registro
                if (Roles != null && Roles.Length > 0)
                {
                    UsuarioTipo tipo = (UsuarioTipo)(usuario as Usuario).UsuarioTipo;
                    int indexOf = Array.IndexOf(Roles, tipo);
                    if (indexOf > -1)
                    {
                        isLogin = true;
                    }
                }
                else
                {
                    isLogin = true;
                }
            }

            //Se metodo isLogin for falso vai redirecionar para a index novamente.
            if (!isLogin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {controller = "Login",  action = "Index"   }));
            }
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    object cadastro = filterContext.HttpContext.Session["usuarioLogado"];

        //    if (cadastro == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(
        //            new RouteValueDictionary(
        //                new { controller = "Login", action = "Index" }
        //                )
        //            );
        //    }
        //}
    }
}