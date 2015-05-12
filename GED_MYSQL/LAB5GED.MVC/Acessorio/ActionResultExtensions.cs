using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Acessorio
{
    public static class ActionResultExtensions
    {
        public static ActionResult ComMensagemDeSucesso(this ActionResult actionResult, string mensagem)
        {
            return new TempDataActionResult(actionResult, mensagem,true);
        }

        public static ActionResult ComMensagemDeSucesso(this ActionResult actionResult)
        {
            return new TempDataActionResult(actionResult, "Ação concluída com sucesso!", true);
        }


        public static ActionResult ComMensagemDeErro(this ActionResult actionResult, string mensagem)
        {
            return new TempDataActionResult(actionResult, mensagem, false);
        }
    }
}