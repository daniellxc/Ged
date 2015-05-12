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
    public class PrazoGuardaBO
    {
        private class PrazoGuardaDAO : AbstracCrudDAO<PrazoGuarda>, IPrazoGuardaDAO
        {
            public PrazoGuardaDAO()
            {

            }

        }

        private PrazoGuardaDAO _DAO = new PrazoGuardaDAO();


        public void SalvarPrazoGuarda(PrazoGuarda _prazoGuarda)
        {
            try
            {
                if (_prazoGuarda.Registro == 0)
                {
                    _DAO.Add(_prazoGuarda);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_prazoGuarda,_prazoGuarda.Registro);
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

        public void ExcluirPrazoGuarda(PrazoGuarda _prazoGuarda)
        {
            try
            {
                _DAO.Delete(_prazoGuarda);
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


        public List<PrazoGuarda> GetAll()
        {
            return _DAO.GetAll().OrderBy(pg => pg.Subserie).ToList<PrazoGuarda>();
        }

        public List<PrazoGuarda> GetPrazosGuardaAtivos()
        {
            return _DAO.Find(pg => pg.Ativo == true).OrderBy(pg => pg.Subserie).ToList<PrazoGuarda>();
        }


        public PrazoGuarda GetByRegistro(int registro)
        {
            return _DAO.Find(pg => pg.Registro == registro).First();
        }
        /// <summary>
        /// Retorna os prazos de guarda ativos para uma subseire
        /// </summary>
        /// <param name="registroSubserie"></param>
        /// <returns></returns>
        public List<PrazoGuarda> GerPrazoGuardaSubserie(int registroSubserie)
        {
            return _DAO.Find(pg => pg.Subserie == registroSubserie && pg.Ativo == true).ToList();
        }
    }
}
