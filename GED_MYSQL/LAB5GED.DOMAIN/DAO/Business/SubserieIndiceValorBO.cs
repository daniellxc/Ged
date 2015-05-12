using LAB5GED.DOMAIN.Acessorio;
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
    public class SubserieIndiceValorBO
    {
        private class SubserieIndiceValorDAO : AbstracCrudDAO<SubserieIndiceValor>, ISubserieIndiceValorDAO
        {
            internal SubserieIndiceValorDAO()
            {

            }
        }


        SubserieIndiceValorDAO _DAO = new SubserieIndiceValorDAO();


        public SubserieIndiceValor GetByRegistro(int _registroSubserieIndiceValor)
        {
            return _DAO.Find(siv => siv.Registro == _registroSubserieIndiceValor).FirstOrDefault();

        }

        public void SalvarSubserieIndiceValor(SubserieIndiceValor _subserieIndiceValor)
        {
            try
            {
                
                if (_subserieIndiceValor.Registro == 0)
                {

                    _DAO.Add(_subserieIndiceValor);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_subserieIndiceValor, _subserieIndiceValor.Registro);
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

        public List<SubserieIndiceValor> GetIndexadoresDoDocumento(int _registroDocumento)
        {
            return _DAO.Find(idxv => idxv.Documento == _registroDocumento).ToList();
        }

        public bool DocumentoTemIndexacao(int _registroDocumento)
        {
            return GetIndexadoresDoDocumento(_registroDocumento).Count > 0;
        }

        public List<SubserieIndiceValor> GetIndexadoresDoIndex(int _registroSubserieIndice)
        {
            return _DAO.Find(idxv => idxv.Indice == _registroSubserieIndice).ToList();
        }

        public List<SubserieIndiceValor> GetIndexadoresObrigatoriosDoDocumento(int _registroDocumento)
        {
            return _DAO.Find(idxv => idxv.Documento == _registroDocumento && idxv.FK_SubserieIndice.Obrigatorio == true).ToList<SubserieIndiceValor>();
        }

        public SubserieIndiceValor GetValorDeUmIndexador(int _registroIndexador, int _registroDocumento)
        {
            try
            {
                return _DAO.Find(idxv => idxv.Indice == _registroIndexador && idxv.Documento == _registroDocumento).First();
            }
            catch
            {
                return null;
            }
        }


        public void ExcluirIndexadoresDeUmDocumento(int _registroDocumento)
        {
            try
            {
                foreach (SubserieIndiceValor idx in GetIndexadoresDoDocumento(_registroDocumento))
                    _DAO.Delete(idx);
            }
            catch
            {
                throw new Erros.ErroGeral("Erro ao excluir indexadores vinculados ao documento") ;
            }
        }



    }
}
