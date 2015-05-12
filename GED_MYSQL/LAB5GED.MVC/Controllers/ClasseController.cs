using LAB5GED.DOMAIN.Acessorio;
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
    [PermissaoFiltro("Controlar Classe")]
    public class ClasseController : CustomController
    {
        //
        // GET: /Classe/

        private  ClasseBO _DAO = new ClasseBO();
        
        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll().OrderBy(cl=>cl.Id_classe).ToList());
        }

     
        
        public ActionResult Cadastrar(Classe _classe)
        {

            return View(_classe);

        }

        public ActionResult Editar(int _registroClasse)
        {
            Session["id"] = _registroClasse;
            return View("Cadastrar", _DAO.GetByRegistro(_registroClasse));

        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Classe _classe =  _DAO.GetByRegistro(int.Parse(Id));
                Logador.LogEntidade(Logador.LogAcoes.Excluir, _classe);
                _DAO.ExcluirClasse(_classe);
                return View("Index", _DAO.GetAll().OrderBy(cl => cl.Id_classe).ToList());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult CadastrarClasse(Classe _novaClasse)
        {
           
            if (!ModelState.IsValid)
                return View("Cadastrar",_novaClasse);
            {
                try
                {

                    if (Session["id"] != null) _novaClasse.Registro = int.Parse(Session["id"].ToString());
                        _DAO.SalvarClasse(_novaClasse);
                        Logador.LogEntidade(Logador.LogAcoes.Salvar, _novaClasse);
                        return RedirectToAction("Index").ComMensagemDeSucesso("Classe salva com sucesso!");
                    
                }
                catch (Exception ex)
                {
         
                    return RedirectToAction("Cadastrar",_novaClasse).ComMensagemDeErro(ex.Message);
                 
                }
            }

        }


     
    }
}
