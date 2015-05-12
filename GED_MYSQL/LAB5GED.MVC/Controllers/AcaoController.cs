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
    [PermissaoFiltro("Controlar Ação")]
    public class AcaoController : CustomController
    {
        //
        // GET: /Acao/
        AcaoBO _DAO = new AcaoBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll());
        }

        public ActionResult Cadastrar(Acao _acao)
        {
            return View(_acao);
        }

        public ActionResult Editar(int _registroAcao)
        {
            Session["id"] = _registroAcao;
            return View("Cadastrar", _DAO.GetByRegistro(_registroAcao));

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Acao _acao = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirAcao(_acao);
                Logador.LogEntidade(LAB5GED.MVC.Acessorio.Logador.LogAcoes.Excluir, _acao);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult CadastrarAcao(Acao _novaAcao)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novaAcao);
            {
                try
                {

                    if (Session["id"] != null) _novaAcao.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarAcao(_novaAcao);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _novaAcao);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Ação cadastrada com sucesso");

                }
                catch (Exception ex)
                {
                  
                    return RedirectToAction("Cadastrar", _novaAcao).ComMensagemDeErro(ex.Message);

                }
            }

        }

    }
}
