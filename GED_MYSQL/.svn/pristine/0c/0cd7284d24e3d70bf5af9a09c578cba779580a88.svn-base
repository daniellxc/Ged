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
    public class TipoDestinacaoSubserieBO
    {
        private class TipoDestinacaoSubserieDAO : AbstracCrudDAO<TipoDestinacaoSubserie>, ITipoDestinacaoSubserieDAO
        {
            public TipoDestinacaoSubserieDAO()
            {

            }

        }

        private TipoDestinacaoSubserieDAO _DAO = new TipoDestinacaoSubserieDAO();


        public void SalvarTipoDestinacaoSubserie(TipoDestinacaoSubserie _tipoDestinacaoSubserie)
        {
            try
            {
                if (_tipoDestinacaoSubserie.Registro == 0)
                {
                    _DAO.Add(_tipoDestinacaoSubserie);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_tipoDestinacaoSubserie, _tipoDestinacaoSubserie.Registro);
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


        public List<TipoDestinacaoSubserie> GetTiposDestinacaoSubserieAtivos()
        {
            return _DAO.Find(td => td.Ativo == true).OrderBy(td => td.Descricao).ToList<TipoDestinacaoSubserie>();
        }

    }
}
