using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Acessorio
{
    public class TempDataActionResult : ActionResult
    {
        private readonly ActionResult _actionResult;
        private readonly string _mensagem;
        private readonly bool _sucesso;

        public TempDataActionResult(ActionResult actionResult, string mensagem, bool sucesso)
        {
            _actionResult = actionResult;
            _mensagem = mensagem;
            _sucesso = sucesso;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData["Sucesso"] = _sucesso;
             context.Controller.TempData["Mensagem"] = _mensagem;
            _actionResult.ExecuteResult(context);
        }
    }
}