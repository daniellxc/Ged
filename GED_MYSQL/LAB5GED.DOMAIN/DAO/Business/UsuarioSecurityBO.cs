using LAB5GED.DOMAIN.Entidades.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
   public class UsuarioSecurityBO
    {
       private class UsuarioSecurityDAO : AbstractSegurancaDAO<Usuario>
       {
           public UsuarioSecurityDAO()
           {
                
           }
       }


       private UsuarioSecurityDAO _DAO = new UsuarioSecurityDAO();

       public Usuario GetUsuario(string _login, string _senha)
       {
           return _DAO.Find(u => u.Login == _login && u.Senha == _senha).FirstOrDefault();
       }

    }
}
