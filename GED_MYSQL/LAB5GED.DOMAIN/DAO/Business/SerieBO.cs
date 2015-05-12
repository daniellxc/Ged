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
    public class SerieBO
    {
        private class SerieDAO : AbstracCrudDAO<Serie>, ISerieDAO
        {
            public SerieDAO()
            {

            }
        }

        private SerieDAO _DAO = new SerieDAO();

        public void SalvarSerie(Serie _serie)
        {
            try
            {
                _serie.Id_serie = TratarIDSerie(_serie.Id_serie, new SubclasseBO().GetByRegistro(_serie.Subclasse));
                if (_serie.Registro == 0)
                {

                    _DAO.Add(_serie);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_serie, _serie.Registro);
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

        private string TratarIDSerie(string id, Subclasse _subClasse)
        {
          int aux;

          if (id.Substring(0, id.Length - 1) != _subClasse.Id_subclasse.Substring(0, _subClasse.Id_subclasse.Length - 1)) throw new Erros.ErroGeral("ID da série inválido. Consulte as regras de identificação de séries."); 
          
              if (int.TryParse(id[2].ToString(), out aux))
              {
                  if (aux > 0 && aux <= 9)
                      return id;
                  else
                      throw new Erros.ErroGeral("O dígito identificador deve estar entre 1 e 9");
              }
              else
                  throw new Erros.ErroGeral("O dígito identificador inválido");
          
          

        }

        public void ExcluirSerie(Serie _serie)
        {
            try
            {
                _DAO.Delete(_serie);
            }
            catch (DbUpdateException)
            {
                throw new Erros.ErroGeral("A Série não pode ser excluída pois existem Subséries vinculadas a ela.");
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("A operação não pode ser concluída. " + ex.Message);
            }

        }

        public List<Serie> GetAll()
        {
            return _DAO.GetAll();
        }

        public List<Serie> GetSeriesAtivas()
        {
            return _DAO.Find(s => s.Ativo == true).OrderBy(s=>s.Subclasse).OrderBy(s=>s.Id_serie).ToList<Serie>();
        }

        public List<Serie> GetSeriesAtivasComRegistro()
        {
            var source = from s in GetSeriesAtivas()
                         select new Serie { Registro = s.Registro, Rotulo_serie = s.Id_serie + " - " + s.Rotulo_serie };
            return source.ToList<Serie>();
        }

        public List<Serie> GetSeriesAtivasComRegistroComItemNulo()
        {
            List<Serie> source = GetSeriesAtivasComRegistro();
            source.Add(new Serie("selecione"));
            return source;
        }

        public Serie  GetByRegistro(int registro)
        {
            return _DAO.Find(s => s.Registro == registro).First<Serie>();
        }
    }
}
