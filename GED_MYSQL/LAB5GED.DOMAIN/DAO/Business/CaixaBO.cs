using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.AppContext;
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
   public class CaixaBO
    {
       private class CaixaDAO : AbstracCrudDAO<Caixa>, ICaixaDAO
       {
           public CaixaDAO()
           {

           }
       }

       private CaixaDAO _DAO = new CaixaDAO();

       #region Métodos
       public void SalvarCaixa(Caixa _caixa)
       {
           try
           {

               if (_caixa.Registro == 0)
               {

                   _DAO.Add(_caixa);
                   _DAO.SaveChanges();
               }
               else
               {
                   _DAO.Atualizar(_caixa, _caixa.Registro);
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

       public void ExlcuirCaixa(Caixa _caixa)
       {
           try
           {
               if (_caixa.Documentos.Count == 0)
               {
                   _DAO.Delete(_caixa);
               }
               else
                   throw new Exception("Não foi possível excluir. Esta caixa possui documentos.");


           }
           catch (Exception ex)
           {
               throw ex;
               
           }

       }

       public List<Caixa> GetAll()
       {
           return _DAO.GetAll();
       }

       public Caixa GetByRegistro(int _registroCaixa)
       {
           return _DAO.Find(c => c.Registro == _registroCaixa).FirstOrDefault();
       }

       public List<Caixa> GetCaixasAbertas()
       {
           return _DAO.Find(c => c.Aberta).ToList();
       }

       public List<Caixa> GetCaixasAbertasPorSubserie(int _registroSubserie)
       {
           return _DAO.Find(c => c.Aberta == true && c.Subserie == _registroSubserie).ToList();
       }

       public List<Caixa> GetCaixasComDocumentosNaoRevisados()
       {

               Contexto _context = _DAO.GetContext;
         

               var retorno = from caixa in _context.Caixas
                             join doc in  _context.Documentos
                             on caixa.Registro equals doc.Caixa
                             where !(from revisao in _context.DocumentoManipulacoes where revisao.FK_TipoManipulacao.DescricaoAcao.Equals("REVISAO")
                                     select revisao.Documento).Contains(doc.Registro)
                             select caixa;

               return retorno.Distinct().ToList();

    

       }


       public List<Documento> GetDocumentosNaoRevisadosDaCaixa(int _registroCaixa)
       {
           Contexto _context = _DAO.GetContext;


           var retorno = from caixa in _context.Caixas
                         join doc in _context.Documentos
                         on caixa.Registro equals doc.Caixa
                         where !(from revisao in _context.DocumentoManipulacoes
                                 where revisao.FK_TipoManipulacao.DescricaoAcao.Equals("REVISAO")
                                 select revisao.Documento).Contains(doc.Registro)
                        where caixa.Registro == _registroCaixa
                         select doc;

           return retorno.ToList();
       }




     

       #endregion

    }
}
