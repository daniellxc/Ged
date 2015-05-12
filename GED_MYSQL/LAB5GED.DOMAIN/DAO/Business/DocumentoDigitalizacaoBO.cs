using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Interfaces;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
    public class DocumentoDigitalizacaoBO
    {
        #region DAO

        private class DocumentoDigitalizacaoDAO:AbstracCrudDAO<DocumentoDigitalizacao>,IDocumentoDigitalizacaoDAO
        {
            public DocumentoDigitalizacaoDAO()
            {

            }

        }

        private DocumentoDigitalizacaoDAO _DAO = new DocumentoDigitalizacaoDAO();


        public DocumentoDigitalizacao GetByRegistro(int _registroDigitalizacao)
        {
            return _DAO.Find(dg => dg.Registro == _registroDigitalizacao).First();

        }


        public MemoryStream GetStreamDocumento(DocumentoDigitalizacao _digitalizacao)
        {
            MemoryStream ms = new MemoryStream(_digitalizacao.Dados, 0, _digitalizacao.Dados.Length);
            return ms;
        }

        public void SalvarDocumentoDigitalizacao(DocumentoDigitalizacao _novaDigitalizacao, Stream strm)
        {

            try
            {
                _novaDigitalizacao.Dados = GerarStreamBytes(strm);

                if (ArquivoExistente(_novaDigitalizacao)) throw new Erros.ErroGeral("Este arquivo já existe");

                if (_novaDigitalizacao.Registro == 0)
                {

                   
                    _DAO.Add(_novaDigitalizacao);
                    _DAO.SaveChanges();
                  
                }
                else
                {
                    _DAO.Atualizar(_novaDigitalizacao, _novaDigitalizacao.Registro);

                }

            }
            catch (DbEntityValidationException dbex)
            {
                throw new Erros.ErroDeValidacao(dbex);
            }
            catch (DbUpdateException dbuex)
            {
                throw new Erros.ErroGeral("Não foi possível concluir a operação. Verifique se o item não foi cadastrado previamente.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Erro inesperado. " + ex.Message);
            }
        }

        public void ExcluirDocumentoDigitalizacao(DocumentoDigitalizacao _documentoDigitalizacao)
        {
            try
            {
                _DAO.Delete(_documentoDigitalizacao);
            }
            catch (DbUpdateException dbex)
            {
                throw new Erros.ErroGeral("Não foi possível excluir a digitalização. Verifique se o arquivo não está em uso. Detalhes:" + dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Erro ao excluir. Contate o administrador." + ex.Message);
            }

        }

        public void ExcluirDigitalizacoesDoDocumento(Documento _documento)
        {
            try
            {
                List<DocumentoDigitalizacao> _digitalizacoesDocumento = this.PegarDigitalizacoesDeUmDocumento(_documento.Registro);
                foreach (DocumentoDigitalizacao d in _digitalizacoesDocumento)
                    _DAO.Delete(d);
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Erro ao excluir as digitalizações do documento.");
            }

        }

        public byte[] GerarStreamBytes(Stream _streamArquivo)
        {
            try
            {

                BinaryReader br = new BinaryReader(_streamArquivo);
                byte[] Arquivo = br.ReadBytes((int)_streamArquivo.Length);
                br.Close();


                return Arquivo;
            }
            catch (IOException ex)
            {
                throw new Erros.ErroGeral("Ocorreu um erro ao manipular o arquivo. Detalhes: " + ex.Message);
            }
        }


        #endregion

        #region Consultas

        public List<DocumentoDigitalizacao> PegarDigitalizacoesDeUmDocumento(int _registroDocumento)
        {
            return _DAO.Find(dd => dd.Documento == _registroDocumento).OrderBy(dd=>dd.Ordem).ToList();

        }

        public bool ArquivoExistente(DocumentoDigitalizacao _digitalizacao)
        {
            if (_digitalizacao.Dados != null)

                return _DAO.Find(dd => dd.Dados == _digitalizacao.Dados && dd.Documento == _digitalizacao.Documento).Count > 0;
            else
                throw new Erros.ErroGeral("Não há um arquivo vinculado a digitalização");
        }

        #endregion
    }
}
