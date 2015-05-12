using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    public class DocumentoDigitalizacaoController : CustomController
    {
        //
        // GET: /DocumentoDigitalizacao/

        private DocumentoDigitalizacaoBO _DAO = new DocumentoDigitalizacaoBO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VinculacaoImagem(int _registroDocumento)
        {
           
            return View(new DocumentoBO().GetByRegistro(_registroDocumento));

        }

        public ActionResult EdicaoVinculacaoImagem(int _registroDocumento)
        {

            return View(new DocumentoBO().GetByRegistro(_registroDocumento));

        }

        public ActionResult ConcluirEdicaoVinculacao(int _registroDocumento)
        {
          

            return RedirectToAction("Revisar", "Documento", new {_registroDocumento=_registroDocumento });

        }

        


        public ActionResult ImportarDigitalizacao(HttpPostedFileBase imagemSelecionada, string _registroDocumento, string ordem, string invoker)
        {            
            try
            {

                 ImportarArquivo(imagemSelecionada, _registroDocumento, ordem);
      
                 return RedirectToAction(invoker,"DocumentoDigitalizacao", new { _registroDocumento = int.Parse(_registroDocumento) });
           

            }
            catch (Exception ex)
            {

                return RedirectToAction(Request.UrlReferrer.Segments[2], new { _registroDocumento = int.Parse(_registroDocumento) }).ComMensagemDeErro(ex.Message);
            }
          
            
        }

       


        public void ImportarArquivo(HttpPostedFileBase imagemSelecionada, string _registroDocumento, string ordem)
        {
            if (imagemSelecionada != null)
            {
                if (Path.GetExtension(imagemSelecionada.FileName).Contains("pdf"))
                {
                    SalvarArquivo(int.Parse(_registroDocumento), imagemSelecionada, ordem);
                    new DocumentoBO().RegistrarCapturaDocumento(int.Parse(_registroDocumento), Seguranca.UsuarioLogado().Registro);
                }
                else
                    throw new Exception("O arquivo selecionado deve possuir a exentensão .pdf");
   
            }
            else
                throw new Exception("Nenhum arquivo selecionado.");

        }


        public void SalvarArquivo(int _registroDocumento, HttpPostedFileBase _file, string ordem)
        {
            try
            {
                DocumentoDigitalizacao _digitalizacao = new DocumentoDigitalizacao();
                _digitalizacao.Documento = _registroDocumento;
                _digitalizacao.Extensao = Path.GetExtension(_file.FileName);
                _digitalizacao.Nome = "doc" + _registroDocumento.ToString() +"_"+ _file.FileName;
                _digitalizacao.Ordem = ordem;
                
                _DAO.SalvarDocumentoDigitalizacao(_digitalizacao, _file.InputStream);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult ExcluirDigitalizacao(int _registroDocumentoDigitalizacao)
        {
            try
            {
                DocumentoDigitalizacao _digitalizacao = _DAO.GetByRegistro(_registroDocumentoDigitalizacao);
                int _registroDocumento = _digitalizacao.Documento;
                _DAO.ExcluirDocumentoDigitalizacao(_digitalizacao);
                return RedirectToAction(Request.UrlReferrer.Segments[2], new { _registroDocumento = _registroDocumento });
            }
            catch (Exception ex)
            {
                return RedirectToAction(Request.UrlReferrer.Segments[2], new { _registroDocumento = _DAO.GetByRegistro(_registroDocumentoDigitalizacao).Documento }).ComMensagemDeErro(ex.Message);

            }

        }


        public ActionResult ListarDigitalizacoesArmazenadas(int _registroDocumento)
        {

            return View(new DocumentoBO().GetByRegistro(_registroDocumento));
        }

        public FileResult VisualizarDigitalizacao(int _registroDocumentoDigitalizacao)
        {
              DocumentoDigitalizacao _digitalizacao = _DAO.GetByRegistro(_registroDocumentoDigitalizacao);
              return File(_DAO.GetStreamDocumento(_digitalizacao).ToArray(), "application/pdf");

        }

      
        


    }
}
