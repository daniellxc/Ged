﻿using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Interfaces;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
   public class DocumentoManipulacaoBO
    {
       private class DocumentoManipulacaoDAO : AbstracCrudDAO<DocumentoManipulacao>, IDocumentoManipulacaoDAO
       {
           public DocumentoManipulacaoDAO()
           {

           }
       }

       private DocumentoManipulacaoDAO _DAO = new DocumentoManipulacaoDAO();


       public void SalvarDocumentoManipulacao(DocumentoManipulacao _novoDocManipulacao)
       {

           try
           {

               if (_novoDocManipulacao.Registro == 0)
               {
                   _DAO.Add(_novoDocManipulacao);
                   _DAO.SaveChanges();
               }
               else
               {
                   _DAO.Atualizar(_novoDocManipulacao, _novoDocManipulacao.Registro);

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
       /// <summary>
       /// Lista todas as manipulações de um documento
       /// </summary>
       /// <param name="_registroDocumento"></param>
       /// <returns></returns>
       public List<DocumentoManipulacao> ManipulacoesDeUmDocumento(int _registroDocumento)
       {
           return _DAO.Find(md => md.Documento == _registroDocumento).ToList();
       }


       public void ExcluirManipulacoesDoDocumento(int _registroDocumento)
       {
           List<DocumentoManipulacao> _mnps = ManipulacoesDeUmDocumento(_registroDocumento);
           foreach (DocumentoManipulacao dm in _mnps)
               _DAO.Delete(dm);
       }

       public DocumentoManipulacao ManipulacaoCapturaDeUmDocumento(int _registroDocumento)
       {
           try
           {
               return ManipulacoesDeUmDocumento(_registroDocumento).Where(md => md.FK_TipoManipulacao.DescricaoAcao.ToLower() == "captura").First();
           }
           catch
           {
               return null;
               //throw new Erros.ErroGeral("Nenhum registro de manipulação do tipo CAPTURA foi localizado para este documento. Verifique o documento e os tipos de manipulações existentes");
           }
       }

       public DocumentoManipulacao ManipulacaoIndexacaoDeUmDocumento(int _registroDocumento)
       {
           try
           {
               return ManipulacoesDeUmDocumento(_registroDocumento).Where(md => md.FK_TipoManipulacao.DescricaoAcao.ToLower() == "indexacao").First();
           }
           catch
           {
               return null;
               //throw new Erros.ErroGeral("Nenhum registro de manipulação do tipo INDEXACAO foi localizado para este documento. Verifique o documento e os tipos de manipulações existentes");
           }
       }

       public DocumentoManipulacao ManipulacaoRevisaoDeUmDocumento(int _registroDocumento)
       {
           try
           {
               return ManipulacoesDeUmDocumento(_registroDocumento).Where(md => md.FK_TipoManipulacao.DescricaoAcao.ToLower() == "revisao").First();
           }
           catch
           {
               return null;
              // throw new Erros.ErroGeral("Nenhum registro de manipulação do tipo REVISAO foi localizado para este documento. Verifique o documento e os tipos de manipulações existentes");
           }
       }

       public DocumentoManipulacao ManipulacaoArmazenamentoDeUmDocumento(int _registroDocumento)
       {
           try
           {
               return ManipulacoesDeUmDocumento(_registroDocumento).Where(md => md.FK_TipoManipulacao.DescricaoAcao.ToLower() == "armazenamento").First();
           }
           catch
           {
               return null;
               // throw new Erros.ErroGeral("Nenhum registro de manipulação do tipo REVISAO foi localizado para este documento. Verifique o documento e os tipos de manipulações existentes");
           }
       }

       public List<DocumentoManipulacao> ManipulacoesDeRevisao()
       {

           return _DAO.Find(md => md.FK_TipoManipulacao.DescricaoAcao.ToLower() == "revisao").ToList();

       }

       public void RegistraManipulacaoDocumento(int _registroDocumento, int _registroUsuario, string _nomeManipulacao)
       {
           if (_registroUsuario == 0) throw new Erros.ErroGeral("Não existe usuário logado.");
           int _regAcaoCaptura = new DocumentoTipoManipulacaoBO().GetByDescricao(_nomeManipulacao).Registro;

           if (_regAcaoCaptura != 0)
           {
               DocumentoManipulacao _novaManipulacao = new DocumentoManipulacao();
               _novaManipulacao.Documento = _registroDocumento;
               _novaManipulacao.Data = DateTime.Now;
               _novaManipulacao.TipoManipulacao = _regAcaoCaptura;
               _novaManipulacao.Usuario = _registroUsuario;
               SalvarDocumentoManipulacao(_novaManipulacao);

           }
           else throw new Erros.ErroGeral("Ainda não existe a ação " + _nomeManipulacao + " no sistema. Consulte o administrador.");

       }
    }
}
