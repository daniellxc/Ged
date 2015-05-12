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
    public class GrupoBO
    {
        private class GrupoDAO : AbstracCrudDAO<Grupo>, IGrupoDAO
        {
            public GrupoDAO()
            {

            }
        }

        GrupoDAO _DAO = new GrupoDAO();


        public void SalvarGrupo(Grupo _grupo)
        {
            try
            {
                if (_grupo.Registro == 0)
                {
                    _DAO.Add(_grupo);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_grupo, _grupo.Registro);
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

        public void ExcluirGrupo(Grupo _grupo)
        {
            try
            {
                _DAO.Delete(_grupo);
            }
            catch (DbUpdateException)
            {
                throw new Erros.ErroGeral("Não foi possível excluir o grupo " + _grupo.NomeGrupo + ". Verique se o grupo está em uso.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Não foi possível excluir o grupo. " + ex.Message);
            }


        }


        public List<Grupo> GetAll()
        {
            return _DAO.GetAll().OrderBy(g=>g.NomeGrupo).ToList<Grupo>();
        }

        public List<Grupo> GetGruposAtivos()
        {
            return _DAO.Find(pg => pg.Ativo == true).OrderBy(g=>g.NomeGrupo).ToList<Grupo>();
        }


        public Grupo GetByRegistro(int _registro)
        {
            return _DAO.Find(g => g.Registro == _registro).First();
        }
    }
}
