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
   [PermissaoFiltro("Controlar Subsérie")]
    public class SubserieController : CustomController
    {
        //
        // GET: /Subserie/

        private SubserieBO _DAO = new SubserieBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll());
        }

        public ActionResult Cadastrar(Subserie _subserie)
        {

            return View(_subserie);

        }

        public ActionResult Editar(int registro)
        {
            Session["id"] = registro;
            return View("Cadastrar", _DAO.GetByRegistro(registro));

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Subserie _subserie = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirSubserie(_subserie);
                Logador.LogEntidade(Logador.LogAcoes.Excluir,_subserie );
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult CadastrarSubserie(Subserie _novaSerie)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novaSerie);
            {
                try
                {

                    if (Session["id"] != null) _novaSerie.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarSubserie(_novaSerie);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar,_novaSerie);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Subsérie salva com sucesso!");

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Cadastrar", _novaSerie).ComMensagemDeErro(ex.Message);
                }
            }

        }

        public JsonResult GetSubseriesDaSerie(string id)
        {
            return Json(new SelectList(_DAO.GetSubseriesAtivasDeUmaSerieComItemNulo(int.Parse(id)),"Registro","Rotulo_subserie"));

        }

        public ActionResult CadastrarIndexador(int registroSubserie)
        {
            return RedirectToAction("Cadastrar", "SubserieIndice", new {_novoSubserieIndice = new SubserieIndice(), _subserie = registroSubserie });
        }

    }
}
