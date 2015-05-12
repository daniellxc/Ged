using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using Sistema.Acadiesp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace LAB5GED.MVC.Controllers
{
    [PermissaoFiltro("Indexação")]
    public class SubserieIndiceValorController : CustomController
    {
        //
        // GET: /SubserieIndiceValor/

        private SubserieIndiceValorBO _DAO = new SubserieIndiceValorBO();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Indexacao(int _registroDocumento)
        {
          
            return View("Indexacao",new DocumentoBO().GetByRegistro(_registroDocumento));

        }

        [PermissaoFiltro("Editar Indexação")]
        public ActionResult Editar(int _registroDocumento)
        {
            return View(_DAO.GetIndexadoresDoDocumento(_registroDocumento));

        }

        public ActionResult Indexar(int Registro, List<int> regIndex, List<string> valor)
        {
            bool sucesso = false;

            if (!ModelState.IsValid)
                return View("Indexacao", new DocumentoBO().GetByRegistro(Registro));
            //using (TransactionScope scope = new TransactionScope())
            //{
                try
                {
                    SubserieIndiceValor _valorIndice;
                    for (int i = 0; i < regIndex.Count; i++)
                    {
                        _valorIndice = new SubserieIndiceValor(Registro, regIndex[i], valor[i]);
                         SalvarIndice(_valorIndice);
                    }

                    new DocumentoBO().RegistrarIndexacaoDocumento(Registro, Seguranca.UsuarioLogado().Registro);

                    sucesso = true;
                  
                }
                catch (Exception ex)
                {
                    sucesso = false;
                    
                   // MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                    valor = new List<string>();
                    return RedirectToAction("Indexacao", new {_registroDocumento = Registro }).ComMensagemDeErro(ex.Message);
                }

                if (sucesso)
                {
                    //scope.Complete();
                    return RedirectToAction("ConcluirCaptura", "Documento", new {_registroDocumento=Registro });
                }
                //else
                //{
                //    scope.Dispose();
                return View("Indexacao", new DocumentoBO().GetByRegistro(Registro));
                //}
           // }
        }

        public ActionResult EditarIndexacao(int Registro, List<int> regIndex, List<string> valor, List<int> regValor)
        {
            bool sucesso = false;

            //using (TransactionScope scope = new TransactionScope())
            //{
                try
                   {
                    SubserieIndiceValor _valorIndice = new SubserieIndiceValor();
                    for (int i = 0; i < regIndex.Count; i++)
                    {
                        _valorIndice = _DAO.GetByRegistro(regValor[i]);
                        _valorIndice.Valor = valor[i];
                        _DAO.SalvarSubserieIndiceValor(_valorIndice);

                    }

                    sucesso = true; 
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Editar", new { _registroDocumento = Registro }).ComMensagemDeErro(ex.Message);
                }
                if (sucesso)
                {
                  //  scope.Complete();
                    return RedirectToAction("Revisar", "Documento", new { _registroDocumento = Registro}).ComMensagemDeSucesso("Indexadores atualizados com sucesso");
                }
                return RedirectToAction("Index", "Home");
            //}

        }

        private void SalvarIndice(SubserieIndiceValor _valorIndice)
        {
            
            if (new SubserieIndiceBO().GetByRegistro(_valorIndice.Indice).Obrigatorio)
               if(_valorIndice.Valor.Trim()!=string.Empty && _valorIndice.Valor.Trim() != null)
                    _DAO.SalvarSubserieIndiceValor(_valorIndice);
            else
                throw new Erros.ErroGeral("Um indexador obrigatório não foi preenchido");
            else
                if(_valorIndice.Valor.Trim()!=string.Empty && _valorIndice.Valor.Trim() != null)
                    _DAO.SalvarSubserieIndiceValor(_valorIndice);
          

        }

        [HttpPost]        
        public JsonResult ConsultarAluno(string _nome)
        {         
            IEnumerable<Pessoa> alunos = new Sistema.Acadiesp.DAO.business.AlunoBO().GetAlunosPorNome(_nome).Select(a => a.FK_Pessoa);
         return Json(alunos);
        }

    }
}
