using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    public class MensagemController : Controller
    {
        //
        // GET: /Mensagem/

        public PartialViewResult Erro(string _erroMessage)
        {
           


            return PartialView("Erro",_erroMessage);
        }

        public PartialViewResult Confirmacao(string _controller, string _action, object _model)
        {
            ViewBag.action = _action;
            ViewBag.controller = _controller;
            return PartialView("_partialConfirmacao", _model);

        }

    }
}
