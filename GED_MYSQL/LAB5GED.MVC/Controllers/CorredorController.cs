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
    [PermissaoFiltro("Controlar Corredor")]
    public class CorredorController : Controller
    {
        //
        // GET: /Corredor/

        private CorredorBO _DAO = new CorredorBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 

            return View(_DAO.GetAll());
        }

        public ActionResult Cadastrar(Corredor _corredor)
        {
            return View(_corredor);
        }



        public ActionResult CadastrarCorredor(Corredor _ncorredor)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _ncorredor);
            {
                try
                {

                    if (Session["id"] != null) _ncorredor.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarCorredor(_ncorredor);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _ncorredor);
                    return RedirectToAction("Index").ComMensagemDeSucesso("Corredor salvo com sucesso!") ;

                }
                catch (Exception ex)
                {
                   
                    return RedirectToAction("Cadastrar", _ncorredor).ComMensagemDeErro(ex.Message);

                }
            }

        }


        public ActionResult Editar(int _registroCorredor)
        {
            Session["id"] = _registroCorredor;
            return View("Cadastrar", _DAO.GetByRegistro(_registroCorredor));

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Corredor _corredor = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirCorredor(_corredor);
                Logador.LogEntidade(LAB5GED.MVC.Acessorio.Logador.LogAcoes.Excluir,_corredor );
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

    }
}
