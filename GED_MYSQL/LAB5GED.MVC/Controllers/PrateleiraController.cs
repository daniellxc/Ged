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
    [PermissaoFiltro("Controlar Prateleira")]
    public class PrateleiraController : Controller
    {
        //
        // GET: /Prateleira/
        private PrateleiraBO _DAO = new PrateleiraBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session);
            return View(_DAO.GetAll().OrderBy(p=>p.FK_Estante.Numero).ToList());
        }

        public ActionResult Cadastrar(Prateleira _prateleira)
        {
            return View(_prateleira);
        }



        public ActionResult CadastrarPrateleira(Prateleira _prateleira)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _prateleira);
            {
                try
                {

                    if (Session["id"] != null) _prateleira.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarPrateleira(_prateleira);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _prateleira);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Prateleira salva com sucesso!");

                }
                catch (Exception ex)
                {
                    
                    return RedirectToAction("Cadastrar", _prateleira).ComMensagemDeErro(ex.Message);

                }
            }

        }


        public ActionResult Editar(int _registroPrateleira)
        {
            Session["id"] = _registroPrateleira;
            return View("Cadastrar", _DAO.GetByRegistro(_registroPrateleira));

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Prateleira prateleira = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirPrateleira(prateleira);
                Logador.LogEntidade(LAB5GED.MVC.Acessorio.Logador.LogAcoes.Excluir, prateleira);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
              
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

    }
}
