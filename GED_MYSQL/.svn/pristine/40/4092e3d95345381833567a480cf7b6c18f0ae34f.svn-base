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
    [PermissaoFiltro("Subclasse")]
    public class SubclasseController : Controller
    {
        //
        // GET: /Subclasse/

        private SubclasseBO _DAO = new SubclasseBO();

        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll().OrderBy(sc=>sc.Classe).OrderBy(sc=>sc.Id_subclasse).ToList());
        }

        public ActionResult Cadastrar(Subclasse _subclasse)
        {
            return View(_subclasse);
        }

        public ActionResult Editar(int registro)
        {
            Session["id"] = registro;
            return View("Cadastrar", _DAO.GetByRegistro(registro));

        }

        public ActionResult CadastrarSubclasse(Subclasse _novaSubclasse)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novaSubclasse);
            {
                try
                {

                    if (Session["id"] != null) _novaSubclasse.Registro = int.Parse(Session["id"].ToString());
                    _DAO.SalvarSubclasse(_novaSubclasse);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                    return View("Cadastrar", _novaSubclasse);
                }
            }

        }
    }
}
