using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Acessorio
{
    public class PermissaoFiltro:AuthorizeAttribute
    {
        string[] _actions = null;
        string   _action  = string.Empty;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.HttpContext.Response.Redirect("~/Login/AcessoNegado");
            else
            {
                if (_action != string.Empty)
                {
                    AcaoPermitida(filterContext, Seguranca.UsuarioLogado());
                }

            }
        }
        public PermissaoFiltro()
        {

        }
        public PermissaoFiltro(string action)
        {
            _action = action;
        }

        public PermissaoFiltro(string[] actions)
        {
            _actions = actions;
        }

        public void AcaoPermitida(AuthorizationContext filterContext, Usuario user)
        {

            var retorno = from grupo in user.Grupos
                          from acao in grupo.Acoes
                          where acao.NomeAcao == _action
                          select grupo;
            filterContext.HttpContext.Session["action"] = _action;
            if (retorno.ToList().Count == 0)
                filterContext.HttpContext.Response.Redirect("~/Login/AcessoNegado");
                //throw new Exception("Você não possui permissão para executar esta ação. Ação: " + _action.ToUpper());
            

        }





        

        
    }
}