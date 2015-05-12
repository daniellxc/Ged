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
    [PermissaoFiltro("Controlar Grupo")]
    public class GrupoController : CustomController
    {
        //
        // GET: /Grupo/
        private GrupoBO _DAO = new GrupoBO();
        public ActionResult Index()
        {
            return View(_DAO.GetAll());
        }

        public ActionResult Editar(int _registroGrupo)
        {
            Session["id"] = _registroGrupo;
            return View("Cadastrar", _DAO.GetByRegistro(_registroGrupo));

        }

        public ActionResult Cadastrar(Grupo _grupo)
        {
            return View(_grupo);
        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Grupo _grupo =  _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirGrupo(_grupo);
                Logador.LogEntidade(Logador.LogAcoes.Salvar, _grupo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }


        }

        public ActionResult CadastrarGrupo(Grupo _novaGrupo)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novaGrupo);
            {
                try
                {

                    if (Session["id"] != null) _novaGrupo.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarGrupo(_novaGrupo);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _novaGrupo);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Grupo salvo com sucesso!");

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Cadastrar", _novaGrupo).ComMensagemDeErro(ex.Message);
               
                }
            }

        }

    }
}
