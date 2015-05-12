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
    public class SubclasseBO
    {
        private class SubclasseDAO : AbstracCrudDAO<Subclasse>, ISubclasseDAO
        {
            public SubclasseDAO()
            {

            }
        }

        private SubclasseDAO _DAO = new SubclasseDAO();


        public void SalvarSubclasse(Subclasse _subclasse)
        {
            try
            {
                _subclasse.Id_subclasse = TratarIDSubclasse(_subclasse.Id_subclasse, new ClasseBO().GetByRegistro(_subclasse.Classe).Id_classe);

                if (_subclasse.Registro == 0)
                {
                    _DAO.Add(_subclasse);
                    _DAO.SaveChanges();
                }
                else
                    _DAO.Atualizar(_subclasse, _subclasse.Registro);
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


        public void ExlcuirSubclasse(Subclasse _subclasse)
        {
            try
            {
                _DAO.Delete(_subclasse);
            }
            catch (DbUpdateException)
            {
                throw new Erros.ErroGeral("A Subclasse não pode ser excluída pois existe(m) série(s) vinculada(s) a ela.");
            }
            catch (Exception ex)
            {
                throw new Exception("A operação não pode ser concluída. "+ ex.Message);
            }

        }
        public List<Subclasse> GetAll()
        {
            return _DAO.GetAll();
        }

        public List<Subclasse> GetSubclassesAtivas()
        {
            return _DAO.Find(s => s.Ativo == true).OrderBy(s => s.Classe).OrderBy(s => s.Id_subclasse).ToList<Subclasse>();
        }

        public List<Subclasse> GetSubClassesAtivasComRegistro()
        {
            var source = from s in GetSubclassesAtivas()
                         select new Subclasse { Registro = s.Registro, Rotulo_subclasse = s.Id_subclasse + " - " + s.Rotulo_subclasse };
            return source.ToList<Subclasse>();
        }
        

        public Subclasse GetByRegistro(int registro)
        {
            return _DAO.Find(sc => sc.Registro == registro).First<Subclasse>();
        }

        private string TratarIDSubclasse(string id, string idClasse)
        {
            int aux = 0;
                if(id[0] != idClasse[0]) throw new Erros.ErroGeral("Id da subclasse inválido. O id da subclasse deve iniciar com "+ idClasse[0]+".");
                
                if(int.TryParse(id.Substring(1,1), out aux))
                {
                    if (aux >= 1 && aux <= 9)
                        return (idClasse[0] + aux.ToString()).PadRight(3, '0');
                    else
                        throw new Erros.ErroGeral("Id da subclasse inválido. Consulte as regras de identificação de subclasses.");
                }
                else
            
                    throw new Erros.ErroGeral("Id da subclasse inválido. Consulte as regras de identificação de subclasses.");
            
        }




       
    }
}
