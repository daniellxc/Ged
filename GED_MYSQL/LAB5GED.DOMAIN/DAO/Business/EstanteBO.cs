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
    public class EstanteBO
    {
        #region DAO
        private class EstanteDAO : AbstracCrudDAO<Estante>, IEstanteDAO
        {
            public EstanteDAO()
            {

            }
        }

        EstanteDAO _DAO = new EstanteDAO();
        #endregion

        public void SalvarEstante(Estante _estante)
        {
            try
            {
                if (_estante.Registro == 0)
                {
                    _DAO.Add(_estante);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_estante, _estante.Registro);
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

        public void ExcluirEstante(Estante _estante)
        {
            try
            {
                _DAO.Delete(_estante);
            }
            catch (DbUpdateException)
            {
                throw new Erros.ErroGeral("Não é possível excluir a estante pois a mesma está em uso.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Não é possível excluir a estante." + ex.Message);
            }

        }


        public List<Estante> GetAll()
        {
            return _DAO.GetAll().OrderBy(c => c.Numero).ToList<Estante>();
        }

        public List<Estante> GetEstantesAtivos()
        {
            return _DAO.Find(e => e.Ativo == true).OrderBy(e => e.Numero).ToList<Estante>();
        }


        public Estante GetByRegistro(int registro)
        {
            return _DAO.Find(e => e.Registro == registro).First();
        }

    }
}
