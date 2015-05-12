using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    [PermissaoFiltro("Controlar Prazo de Guarda")]
    public class PrazoGuardaController : CustomController
    {
        //
        // GET: /PrazoGuarda/
        private PrazoGuardaBO _DAO = new PrazoGuardaBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll());
        }

        public ActionResult Cadastrar(PrazoGuarda _prazoGuarda)
        {

            return View(_prazoGuarda);

        }

        public ActionResult Editar(int registro)
        {
            Session["id"] = registro;
            return View("Cadastrar", _DAO.GetByRegistro(registro));

        }

        public ActionResult CadastrarPrazoGuarda(PrazoGuarda _prazoGuarda)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _prazoGuarda);
            {
                try
                {

                    if (Session["id"] != null) _prazoGuarda.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarPrazoGuarda(_prazoGuarda);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _prazoGuarda);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Prazo de guarda salvo com sucesso!");

                }
                catch (Exception ex)
                {
                    
                    return RedirectToAction("Cadastrar",_prazoGuarda).ComMensagemDeErro(ex.Message) ;
                }
            }

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                PrazoGuarda _prazoGuarda = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirPrazoGuarda(_prazoGuarda);
                Logador.LogEntidade(Logador.LogAcoes.Excluir, _prazoGuarda);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

    }
}
