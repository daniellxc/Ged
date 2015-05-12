using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB5GED.MVC.Acessorio
{
    public class MetodosUtilidadeGeral
    {
        public static void MensagemDeErro(string mensagem, HttpResponseBase response)
        {
            

        }

        public static void MensagemDeSucesso(string mensagem, HttpResponseBase response)
        {
            response.Write("<div style='background-color:green;'>" + mensagem + "</div>");

        }

        public static void LimparSessaoEdicao(HttpSessionStateBase _session)
        {
            _session["id"] = null;
        }

  


        
    }
}