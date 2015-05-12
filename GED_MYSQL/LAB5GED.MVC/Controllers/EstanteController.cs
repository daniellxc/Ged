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
    [PermissaoFiltro("Controlar Estante")]
    public class EstanteController : Controller
    {
        //
        // GET: /Estante/
        private EstanteBO _DAO = new EstanteBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session);
            return View(_DAO.GetAll().OrderBy(e=>e.FK_Corredor.Numero).ToList());
        }

        public ActionResult Cadastrar(Estante _estante)
        {
            return View(_estante);
        }



        public ActionResult CadastrarEstante(Estante _estante)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _estante);
            {
                try
                {

                    if (Session["id"] != null) _estante.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarEstante(_estante);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _estante);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Estante salva com sucesso!");

                }
                catch (Exception ex)
                {
                   return RedirectToAction("Cadastrar",_estante).ComMensagemDeErro(ex.Message);

                }
            }

        }


        public ActionResult Editar(int _registroEstante)
        {
            Session["id"] = _registroEstante;
            return View("Cadastrar", _DAO.GetByRegistro(_registroEstante));

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Estante estante = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirEstante(estante);
                Logador.LogEntidade(LAB5GED.MVC.Acessorio.Logador.LogAcoes.Excluir, estante);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

    }
}
