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
    public class PrateleiraBO
    {
        #region DAO
        private class PrateleiraDAO : AbstracCrudDAO<Prateleira>, IPrateleiraDAO
        {
            public PrateleiraDAO()
            {

            }
        }

        PrateleiraDAO _DAO = new PrateleiraDAO();
        #endregion

        public void SalvarPrateleira(Prateleira _prateleira)
        {
            try
            {
                if (_prateleira.Registro == 0)
                {
                    _DAO.Add(_prateleira);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_prateleira, _prateleira.Registro);
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

        public void ExcluirPrateleira(Prateleira _prateleira)
        {
            try
            {
                _DAO.Delete(_prateleira);
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


        public List<Prateleira> GetAll()
        {
            return _DAO.GetAll().OrderBy(p => p.Numero).ToList<Prateleira>();
        }

        public List<Prateleira> GetPrateleirasAtivos()
        {
            return _DAO.Find(p => p.Ativo == true).OrderBy(p => p.Numero).ToList<Prateleira>();
        }


        public Prateleira GetByRegistro(int registro)
        {
            return _DAO.Find(p => p.Registro == registro).First();
        }
    }
}
