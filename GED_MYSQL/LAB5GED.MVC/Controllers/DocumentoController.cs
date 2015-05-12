using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{

    public class DocumentoController : CustomController
    {
        //
        // GET: /Documento/

        DocumentoBO _DAO = new DocumentoBO();
       [PermissaoFiltro("Listar Todos Documentos")]
        public ActionResult Index()
        {
           
            return View(_DAO.GetAll().OrderByDescending(d=>d.Registro).ToList());
        }

        /// <summary>
        /// NÃO PERMITE EDIÇÃO!!!
        /// </summary>
        /// <returns></returns>
        [PermissaoFiltro("Cadastrar Documento")]
        public ActionResult Cadastrar()
        {
            return View(new Documento());
        }

        [PermissaoFiltro("Iniciar Revisão")]
        public ActionResult IniciarRevisao()
        {
            return View();
        }

        [PermissaoFiltro("Listar Documentos Não Revisados")]
        public ActionResult ListarDocumentosNaoRevisados(int _registroCaixa)
        {
            return View(new CaixaBO().GetDocumentosNaoRevisadosDaCaixa(_registroCaixa));

        }

        public ActionResult Editar(int _registroDocumento)
        {

            return View(_DAO.GetByRegistro(_registroDocumento));
        }

        public ActionResult EditarInfoDocumento(Documento _documento)
        {
            try
            {
                if(SubserieDiferente(_documento))
                    ApagarIndexacao(_documento);

                _DAO.SalvarInfoDocumento(_documento);
                Logador.LogEntidade(Logador.LogAcoes.Editar, _documento);
                return RedirectToAction("Revisar", "Documento", new  {_registroDocumento = _documento.Registro }).ComMensagemDeSucesso("Documento atualizado com sucesso");
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Editar",_documento).ComMensagemDeErro(ex.Message);
            }
        }

        private void ApagarIndexacao(Documento _documento)
        {
            try
            {
                new SubserieIndiceValorBO().ExcluirIndexadoresDeUmDocumento(_documento.Registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SubserieDiferente(Documento _documentoNovo)
        {
            Documento _documentoOld = _DAO.GetByRegistro(_documentoNovo.Registro);

            return _documentoNovo.Subserie != _documentoOld.Subserie;
        }

        [PermissaoFiltro("Revisão")]
        public ActionResult Revisar(int _registroDocumento)
        {
            try
            {
                return View(_DAO.GetByRegistro(_registroDocumento));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Revisar", _registroDocumento).ComMensagemDeErro(ex.Message);
               
            }
        }


        public ActionResult Detalhar(int _registroDocumento)
        {
            return View(_DAO.GetByRegistro(_registroDocumento));
        }

   
        public ActionResult CadastrarDocumento(Documento _novoDocumento)
        {
            try
            {
                    _DAO.SalvarDocumento(_novoDocumento);
                    Logador.LogAcao(Logador.LogAcoes.Salvar, "CADASTRO DE DOCUMENTO (REGISTRO " + _novoDocumento.Registro.ToString() + ")");
                    _DAO.RegistrarCadastroDocumento(_novoDocumento.Registro, Seguranca.UsuarioLogado().Registro);   
            }
            catch (Exception ex)
            {
                return RedirectToAction("Cadastrar").ComMensagemDeErro(ex.Message);      
            }

            return RedirectToAction("VinculacaoImagem", "DocumentoDigitalizacao", new { _registroDocumento = _novoDocumento.Registro });
       
        }


        [PermissaoFiltro("Excluir Documento")]
        public ActionResult ExcluirDocumento(string Id)
        {
            try
            {
                Documento _doc = _DAO.GetByRegistro(int.Parse(Id));

                try
                {
                    new DocumentoDigitalizacaoBO().ExcluirDigitalizacoesDoDocumento(_doc);
                    _DAO.ExluirDocumento(_doc);
                    Logador.LogEntidade(Logador.LogAcoes.Excluir, _doc);
                    return RedirectToAction("Index", "Documento");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Documento").ComMensagemDeErro(ex.Message);
                   // return View("ListarDocumentosNaoRevisados", new CaixaBO().GetDocumentosNaoRevisadosDaCaixa(_doc.Caixa)).ComMensagemDeErro(ex.Message);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home").ComMensagemDeErro("Erro ao acessar o documento. Exclusão não realizada!");
            }

        }

     

        public ActionResult ConcluirCaptura(int _registroDocumento)
        {
            return View(_registroDocumento);
        }


        
        public ActionResult ArmazenarDocumento(int _registroDocumento, int _registroCaixa)
        {
           
            bool sucesso = false;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    _DAO.ArmazenarDocumento(_registroDocumento, _registroCaixa);
                    _DAO.RegistrarArmazenamentoDocumento(_registroDocumento, Seguranca.UsuarioLogado().Registro);
                    sucesso = true;
                  
                }
                catch (Exception ex)
                {
                    MetodosUtilidadeGeral.MensagemDeErro(ex.Message, Response);
                    
                }

                if (sucesso)
                {
                    scope.Complete();
                    return RedirectToAction("DocumentosNaoArmazenados").ComMensagemDeSucesso("Documento armazenado com sucesso!");
                }
                return RedirectToAction("ArmazenarDocumento");
            }

        }

        public ActionResult RevisarDocumento(int _registroDocumento)
        {
            try
            {
                if (!_DAO.DocumentoRevisado(_registroDocumento))
                {
                    _DAO.RegistrarRevisaoDocumento(_registroDocumento, Seguranca.UsuarioLogado().Registro);
                }
                return RedirectToAction("ListarDocumentosNaoRevisados", "Documento", new {_registroCaixa = _DAO.GetByRegistro(_registroDocumento).Caixa }).ComMensagemDeSucesso("Revisão concluída!");
            }
            catch (Exception ex)
            {
               
                return View("Revisar", new { _registroDocumento = _registroDocumento }).ComMensagemDeErro(ex.Message);
            }

        }

        public ActionResult DocumentosNaoArmazenados()
        {
            return View(_DAO.DocumentosNaoArmazenados());
        }

  

        #region JSons

        public JsonResult GetCaixasAbertasSubserie(string id)
        {
            if (id == "")
                id = "0";
                    return Json(new SelectList(new CaixaBO().GetCaixasAbertasPorSubserie(int.Parse(id)), "Registro", "IdCaixa"));
           
        }

        #endregion


    }

    
}
