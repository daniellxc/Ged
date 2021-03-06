﻿using LAB5GED.DOMAIN.Acessorio;
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
    public class ClasseBO
    {
        private class ClasseDAO:AbstracCrudDAO<Classe>,IClasseDAO
        {
            public ClasseDAO()
            {

            }
        }


        private ClasseDAO _DAO = new ClasseDAO();

        public Classe GetByRegistro(int _registro)
        {
            return _DAO.Find(c => c.Registro == _registro).First();
        }

        public void SalvarClasse(Classe _classe)
        {
            try
            {
                _classe.Id_classe = TratarIDClasse(_classe.Id_classe);
                if (_classe.Registro == 0)
                {
                    _classe.DataAbertura = DateTime.Now;
                    _DAO.Add(_classe);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_classe, _classe.Registro);

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


        public void ExcluirClasse(Classe _classe)
        {
            try
            {
                _DAO.Delete(_classe);
            }
            catch (DbUpdateException dbex)
            {
                throw new Erros.ErroGeral("A Classe não pode ser excluída. Existem subclasses vinculadas a esta Classe.");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string TratarIDClasse(string id)
        {
            int id_aux;
            if (int.TryParse(id, out id_aux))
            {
                if ((id_aux >= 0 && id_aux <= 9) || (ValidaRange(id)))
                    return id_aux.ToString().PadRight(3, '0');
                else throw new Erros.ErroGeral("ID Inválido. Apenas números entre 1 e 9 são permitidos.");
            }
            else throw new Erros.ErroGeral("ID Inválido. Apenas números entre 1 e 9 são permitidos.");

        }

        private bool ValidaRange(string id)
        {
            bool retorno = true;

            retorno = id == "100" || id == "200" || id == "300" || id == "400" || id == "500" || id == "600" || id == "700" || id == "800" || id == "900";

            return retorno;
        }




        public List<Classe> GetAll()
        {
            return _DAO.GetAll();
        }

        public List<Classe> GetClassesAtivas()
        {
            return _DAO.Find(cl => cl.Ativo == true);
        }


        public List<Classe> GetClassesAtivasComID()
        {
            var source = from s in this.GetClassesAtivas()
                         select new Classe { Registro = s.Registro, Rotulo = s.Id_classe + " - " + s.Rotulo };
            return source.ToList<Classe>();

        }
    }
}
