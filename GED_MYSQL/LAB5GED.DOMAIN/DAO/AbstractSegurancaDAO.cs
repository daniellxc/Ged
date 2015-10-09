﻿using LAB5GED.DOMAIN.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO
{
    public abstract class AbstractSegurancaDAO<T> where T : class
    {
        private SegurancaContexto _contexto = new SegurancaContexto();

        #region Métodos que utilizam Code First EF4

        public void Add(T pEntity)
        {
            _contexto.Set<T>().Add(pEntity);

        }



        public void Delete(T pEntity)
        {
            try
            {
                _contexto.Set<T>().Remove(pEntity);

                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public List<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return _contexto.Set<T>().Where(where).ToList<T>();

        }

        public List<T> GetAll()
        {

            return _contexto.Set<T>().ToList<T>();
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();

        }

        public void ExecuteComand(string command)
        {
            _contexto.Database.ExecuteSqlCommand(command);
        }



        public void Atualizar(T updateEntity, int key)
        {
            var original = _contexto.Set<T>().Find(key);
            if (original != null)
            {
                _contexto.Entry(original).CurrentValues.SetValues(updateEntity);
                _contexto.SaveChanges();
            }

        }

        #endregion
    }
}