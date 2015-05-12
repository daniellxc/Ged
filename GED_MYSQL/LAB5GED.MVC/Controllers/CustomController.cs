using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    public class CustomController : Controller
    {
        //
        // GET: /Custom/

        protected override void OnException(ExceptionContext filterContext)
        {
            //RedirectToAction("Erro", "Mensagem",//, new { _erro = filterContext.Exception.Message });
            //Response.Redirect(Url.Action("Erro", "Mensagem", new { _erro = filterContext.Exception.Message }));
            ModelState.AddModelError("",filterContext.Exception.Message);
           // Response.Redirect(Url.Action("Erro","Mensagem",new {_erroMessage = filterContext.Exception.Message}));
        }

    }
}
