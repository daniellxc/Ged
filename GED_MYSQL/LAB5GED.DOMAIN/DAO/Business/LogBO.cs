using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.DAO.Interfaces;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
    public class LogBO
    {
        private class LogDAO : AbstracCrudDAO<Log>, ILogDAO
        {
            public LogDAO()
            {

            }
        }

        private LogDAO _DAO = new LogDAO();


        public void SalvarLog(Log _log)
        {
            try
            {
                _DAO.Add(_log);
                _DAO.SaveChanges();
            }
            catch
            {
                throw new Erros.ErroGeral("Não foi possivel registrar o log no banco");
            }

        }
    }
}
