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
    
    public class ConsultaController : Controller
    {
        //
        // GET: /Consulta/

        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        [PermissaoFiltro("ConsultarDocumentosAluno")]
        public ActionResult ConsultarDocumentosAluno()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ConsultaAluno(string _nomeAluno)
        {
            return PartialView("ConsultaAluno", new Sistema.Acadiesp.DAO.business.AlunoBO().GetAlunosPorNome(_nomeAluno));
        }

        public PartialViewResult DocumentosDoAluno(string _matriculaAluno)
        {
            List<Documento> d = new DocumentoBO().DocumentosDeUmaMatricula(_matriculaAluno);
            return PartialView("DocumentosDoAluno", new DocumentoBO().DocumentosDeUmaMatricula(_matriculaAluno));
        }

    }
}
