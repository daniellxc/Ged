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
    public class CorredorBO
    {
        #region DAO
        private class CorredorDAO : AbstracCrudDAO<Corredor>, ICorredorDAO
        {
            public CorredorDAO()
            {

            }
        }

        CorredorDAO _DAO = new CorredorDAO();
        #endregion

        public void SalvarCorredor(Corredor _corredor)
        {
            try
            {
                if (_corredor.Registro == 0)
                {
                    _DAO.Add(_corredor);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_corredor, _corredor.Registro);
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

        public void ExcluirCorredor(Corredor _corredor)
        {
            try
            {
                _DAO.Delete(_corredor);
            }
            catch (DbUpdateException)
            {
                throw new Erros.ErroGeral("Não é possível excluir o prazo de guarda. Existem subséries utilizando-o.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Não é possível excluir o prazo de guarda." + ex.Message);
            }

        }


        public List<Corredor> GetAll()
        {
            return _DAO.GetAll().OrderBy(c => c.Numero).ToList<Corredor>();
        }

        public List<Corredor> GetCorredoresAtivos()
        {
            return _DAO.Find(c => c.Ativo == true).OrderBy(c => c.Numero).ToList<Corredor>();
        }


        public Corredor GetByRegistro(int registro)
        {
            return _DAO.Find(c => c.Registro == registro).First();
        }


    }
}
