using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.Acessorio
{
    public class Logger
    {
        public  void Gravar(string _acao, string _entidade,string _usuario,string _mensagem)
        {
            LogBO _logger = new LogBO();
          
            Log _log = new Log(_acao,_entidade,_usuario, _mensagem);

            _logger.SalvarLog(_log);
        }

        

   


    }
}
