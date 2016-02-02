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


        public List<Subserie> SubseriesDoUsuario()
        {
            return new UsuarioBO().GetByRegistro(int.Parse(User.Identity.Name)).Subseries;

        }
        #region Consultas JSONS


        public JsonResult GetClassesAtivas()
        {
            return Json(new SelectList(new ClasseBO().GetClassesAtivas(), "Registro", "Rotulo"));
        }



        public JsonResult GetSubclassesUsuarioLogado(string id)
        {
            if (id == "")
                id = "0";
            int classe = int.Parse(id);
           // return Json(new SelectList(new SubclasseBO().GetSubclassesAtivas().Where(s => s.Classe == classe).ToList(), "Registro", "Rotulo_subclasse"));
            return Json(new SelectList(new UsuarioBO().GetSubclassesAtivasUsuario(int.Parse(User.Identity.Name)).Where(sc=>sc.Classe == classe), "Registro", "Rotulo_subclasse"));

        }

        /// <summary>
        /// Retorna as subclasses ativas de uma classe onde ID representa o ID da classe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetSubclassesAtivas(string id)
        {
            int classe;
            if(id=="")
                classe = 0;
            else
                classe = int.Parse(id);
            return Json(new SelectList(new SubclasseBO().GetSubclassesAtivas().Where(sc => sc.Classe == classe), "Registro", "Rotulo_subclasse"));
        }

        public JsonResult GetSeriesUsuarioLogado(string id)
        {
            

            if (id == "")
                id = "0";
            int subclasse = int.Parse(id);
            //return Json(new SelectList(new SerieBO().GetSeriesAtivas().Where(s => s.Subclasse == subclasse ).ToList(), "Registro", "Rotulo_serie"));
            return Json(new SelectList(new UsuarioBO().GetSeriesAtivasUsuario(int.Parse(User.Identity.Name)).Where(s=>s.Subclasse == subclasse), "Registro", "Rotulo_serie"));

        }


        /// <summary>
        /// Retorna as series ativas de uma subclasse onde ID representa o ID da subclasse.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetSeriesAtivas(string id)
        {
            int subClasse;
            if (id == "")
                subClasse = 0;
            else
                subClasse = int.Parse(id);
            return Json(new SelectList(new SerieBO().GetSeriesAtivas().Where(sc => sc.Subclasse == subClasse), "Registro", "Rotulo_serie"));
        }


        public JsonResult GetSubseriesUsuarioLogado(string id)
        {
            if (id == "")
                id = "0";


            int idserie = int.Parse(id);
            
            //return Json(new SelectList(new SubserieBO().GetSubseriesAtivasDeUmaSerie(int.Parse(id)), "Registro", "Rotulo_subserie"));
            return Json(new SelectList(new UsuarioBO().GetSubseriesAtivas(int.Parse(User.Identity.Name)).Where(s=>s.Serie == idserie), "Registro", "Rotulo_subserie"));
           
        }

        private int buscaPosicao(List<Subserie> list, Subserie k)
        {
            try { return list.FindIndex(o => o.Equals(k)); }
            catch
            {
                return -1;
            } 

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
