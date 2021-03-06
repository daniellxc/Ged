﻿using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.AppContext;
using LAB5GED.DOMAIN.DAO.Interfaces;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
    public class DocumentoBO
    {
        private class DocumentoDAO : AbstracCrudDAO<Documento>, IDocumentoDAO
        {
            public DocumentoDAO()
            {

            }
        }


        private DocumentoDAO _DAO = new DocumentoDAO();

        public List<Documento> GetAll()
        {
            return _DAO.GetAll();
        }

        public byte[] PrepararArquivo(string _caminhoArquivo)
        {
            try
            {
                FileStream fs = new FileStream(_caminhoArquivo, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] Arquivo = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                return Arquivo;
            }
            catch (IOException ex)
            {
                throw new Erros.ErroGeral("Ocorreu um erro ao manipular o arquivo. Detalhes: " + ex.Message);
            }
        }


        


 

        public Documento GetByRegistro(int _registro)
        {
            return _DAO.Find(d => d.Registro == _registro).First();
        }

        public void GerarPdfEmDiretorio(Documento _documento)
        {
            //FileStream Fs = new FileStream(@"C:\Pdf.pdf", FileMode.Create);
            //Fs.Write(_documento.Dados, 0, _documento.Dados.Length);
            //Process.Start(@"C:\Pdf.pdf");
            //Fs.Close();
        }

     


        public void SalvarDocumento(Documento _novoDocumento)
        {

            try
            {


                if (_novoDocumento.Registro == 0)
                {

                    _novoDocumento.DataCriacao = DateTime.Now;
                    _DAO.Add(_novoDocumento);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_novoDocumento, _novoDocumento.Registro);

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

        public void ArmazenarDocumento(int _registroDocumento, int _registroCaixa)
        {
            try
            {
                Documento _documentoArmazenado = GetByRegistro(_registroDocumento);
                _documentoArmazenado.Caixa = _registroCaixa;
                _DAO.Atualizar(_documentoArmazenado, _registroDocumento);


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
        
        public void ExluirDocumento(Documento _documento)
        {
            try
            {
                new DocumentoManipulacaoBO().ExcluirManipulacoesDoDocumento(_documento.Registro);
                new SubserieIndiceValorBO().ExcluirIndexadoresDeUmDocumento(_documento.Registro);
                _DAO.Delete(_documento);
            }

            catch (DbUpdateException dbex)
            {
                throw new Erros.ErroGeral("Não foi possível excluir o documento. Verifique se não há digitalizações vinculadas ao documento.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Erro ao excluir documento. Contate o administrador. "+ex.Message);
            }

        }

        public void SalvarInfoDocumento(Documento _documento)
        {
            try
            {
                if (_documento.Registro != 0)
                {

                    _DAO.Atualizar(_documento, _documento.Registro);
                }
                else
                {
                    throw new Erros.ErroGeral("Classe Documento incompleta");
                }
            }
            catch
            {
                throw;
            }
        }

        public bool DocumentoRevisado(int _registroDocumento)
        {
            try
            {
                return new DocumentoManipulacaoBO().ManipulacaoRevisaoDeUmDocumento(_registroDocumento) != null;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Retorna true se os indexadores obrigatórios foram informados e a indexação foi registrada
        /// </summary>
        /// <param name="_registroDocumento"></param>
        /// <returns></returns>
        public bool DocumentoIndexado(int _registroDocumento)
        {
            try

            {
               
                return 
                    new SubserieIndiceValorBO().GetIndexadoresObrigatoriosDoDocumento(_registroDocumento) != null 
                    &&
                    new DocumentoManipulacaoBO().ManipulacaoIndexacaoDeUmDocumento(_registroDocumento) != null;
            }
            catch
            {
                return false;
            }
        }

        #region REGISTRO DE MANIPULACOES
        public void RegistrarCadastroDocumento(int _registroDocumento, int _registroUsuario)
        {
            try
            {
                new DocumentoManipulacaoBO().RegistraManipulacaoDocumento(_registroDocumento, _registroUsuario, "CADASTRO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegistrarCapturaDocumento(int _registroDocumento, int _registroUsuario)
        {
            try
            {
                new DocumentoManipulacaoBO().RegistraManipulacaoDocumento(_registroDocumento, _registroUsuario, "CAPTURA");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegistrarIndexacaoDocumento(int _registroDocumento, int _registroUsuario)
        {
            try
            {
                new DocumentoManipulacaoBO().RegistraManipulacaoDocumento(_registroDocumento, _registroUsuario, "INDEXACAO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void RegistrarRevisaoDocumento(int _registroDocumento, int _registroUsuario)
        {
            try
            {
                new DocumentoManipulacaoBO().RegistraManipulacaoDocumento(_registroDocumento, _registroUsuario, "REVISAO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegistrarArmazenamentoDocumento(int _registroDocumento, int _registroUsuario)
        {
            try
            {
                new DocumentoManipulacaoBO().RegistraManipulacaoDocumento(_registroDocumento, _registroUsuario, "ARMAZENAMENTO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Consultas

        /// <summary>
        /// Retorna uma lista de documentos indexados à uma matrícula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public List<Documento> DocumentosDeUmaMatricula(string matricula)
        {
            var retorno = from documentos in _DAO.GetContext.Documentos
                          join subseries in _DAO.GetContext.Subseries
                          on documentos.Subserie equals subseries.Registro
                          join indices in _DAO.GetContext.SubserieIndices
                          on subseries.Registro equals indices.Subserie
                          join valorIndice in _DAO.GetContext.SubserieIndiceValores
                          on indices.Registro equals valorIndice.Indice
                          where valorIndice.Valor == matricula
                          && indices.NomeIndice.ToLower() == "matrícula"
                          && valorIndice.Documento == documentos.Registro
                          select documentos;
            return retorno.ToList<Documento>();
            
        }
        /// <summary>
        /// Retorna um lista com os documentos que não foram revisados
        /// </summary>
        /// <returns></returns>
        public List<Documento> GetDocumentosNaoRevisado()
        {
            Contexto _contexto = _DAO.GetContext;

            var retorno = from docs in _contexto.Documentos
                          where !(from revisoes in _contexto.DocumentoManipulacoes
                                  join tipoRevisao in _contexto.DocumentoTiposManipulacao
                                          on revisoes.TipoManipulacao equals tipoRevisao.Registro
                                  where tipoRevisao.DescricaoAcao.ToLower() == "revisao"
                                  select revisoes.Documento).Contains(docs.Registro)
                          select docs;
            return retorno.ToList<Documento>();

        }

        /// <summary>
        /// Retorna uma lista com os documentos que não estão em nenhuma caixa
        /// </summary>
        /// <returns></returns>
        public List<Documento> DocumentosNaoArmazenados()
        {
          return  _DAO.Find(d=>d.Caixa == null).ToList();

           
        }
        /// <summary>
        /// Pesquisa por documentos que façam referência a chave informada no parâmetro.
        /// Consulta índices e descrição do documento.
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        public List<Documento> Pesquisar(string chave)
        {
            Contexto contexto = _DAO.GetContext;

            var retorno = from valorIndice in contexto.SubserieIndiceValores
                          join indice      in contexto.SubserieIndices
                          on valorIndice.Indice equals indice.Registro
                          join subserie    in contexto.Subseries
                          on indice.Subserie    equals subserie.Registro
                          join documento   in contexto.Documentos
                          on subserie.Registro  equals documento.Subserie
                          where valorIndice.Documento == documento.Registro &&
                          valorIndice.Valor.Contains(chave) || documento.Descricao.Contains(chave)
                          select documento;

            return retorno.Distinct().ToList<Documento>();
        }


        public List<Documento> PesquisarDocumentosUsuario(string chave, int registroUsuario)
        {
            Contexto contexto = _DAO.GetContext;


            var retorno = from valorIndice in contexto.SubserieIndiceValores
                          join indice in contexto.SubserieIndices
                          on valorIndice.Indice equals indice.Registro
                          join subserie in contexto.Usuarios.Where(u=>u.Registro == registroUsuario).SelectMany(u=>u.Subseries)
                          on indice.Subserie equals subserie.Registro
                          join documento in contexto.Documentos
                          on subserie.Registro equals documento.Subserie
                          where valorIndice.Documento == documento.Registro &&
                          valorIndice.Valor.Contains(chave) || documento.Descricao.Contains(chave) 
                  
                          select documento;


            return retorno.Distinct().ToList<Documento>();
        }



 
        #endregion


    }
}
