using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{

    public class ConsultaController : CustomController
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

        

        public PartialViewResult DocumentosDoAluno(string _matriculaAluno)
        {
           // List<Documento> d = new DocumentoBO().DocumentosDeUmaMatricula(_matriculaAluno);
            return PartialView("DocumentosDoAluno", new DocumentoBO().DocumentosDeUmaMatricula(_matriculaAluno));
        }

        public PartialViewResult ConsultarDocumentoIndex(string indice, string valor, bool ckdtl)
        {
            if (ckdtl)
            {
                int _indice = int.Parse(indice);
                return PartialView("partialGridDocumento", new SubserieIndiceValorBO().ListarIndexacao(_indice, valor).Select(d => d.FK_Documento).ToList());
            }

            return PartialView("partialGridDocumento", new DocumentoBO().Pesquisar(valor));
            
        }

        [PermissaoFiltro("Consulta Detalhada")]
        public ActionResult ConsultarDocumentos()
        {
            return View();
        }



        #region Consultas JSONS
        public JsonResult GetSubclasses(string id)
        {
            if (id == "")
                id = "0";
            int classe = int.Parse(id);
            return Json(new SelectList(new SubclasseBO().GetSubclassesAtivas().Where(s => s.Classe == classe).ToList(), "Registro", "Rotulo_subclasse"));

        }

        public JsonResult GetSeries(string id)
        {
            if (id == "")
                id = "0";
            int subclasse = int.Parse(id);
            return Json(new SelectList(new SerieBO().GetSeriesAtivas().Where(s => s.Subclasse == subclasse).ToList(), "Registro", "Rotulo_serie"));

        }


        public JsonResult GetSubseries(string id)
        {
            if (id == "")
                id = "0";
            
            //return Json(new SelectList(new SubserieBO().GetSubseriesAtivasDeUmaSerie(int.Parse(id)), "Registro", "Rotulo_subserie"));
            return Json(new SelectList(new UsuarioBO().GetByRegistro(int.Parse(User.Identity.Name)).Subseries, "Registro", "Rotulo_subserie"));

        }

        public JsonResult GetSubserieIndices(string id)
        {
            if (id == "")
                id = "0";

            return Json(new SelectList(new SubserieIndiceBO().GetIndexadoresDeUmaSubserie(int.Parse(id)), "Registro", "NomeIndice"));

           

        }

        #endregion
    }
}
