using LAB5GED.DOMAIN.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LAB5GED.MVC.Acessorio
{
    public class Logador
    {
        private  static Logger _registrador;


        public enum LogAcoes
        {
            Salvar,
            Editar,
            Excluir,
            Acesso,
            Configuração

        }


        public static void GravarEmLog(LogAcoes _acao,string _entidade, string _mensagem)
        {
            try
            {
                _registrador = new Logger();

                string usuario = "";
                try
                {
                    usuario = Seguranca.UsuarioLogado().Login;
                }
                catch { }

                _registrador.Gravar(_acao.ToString(), _entidade, usuario, _mensagem);

            }
            catch{}

        }

        public static void LogAcao(LogAcoes _nomeAcao, string _mensagem)
        {
            GravarEmLog(_nomeAcao, null,_mensagem);
        }

        public static void LogEntidade(LogAcoes _acao,Object _entidade)
        {
            string dados = "";

            foreach (PropertyInfo pi in _entidade.GetType().GetProperties())
            {
                dados += pi.Name + "="+Convert.ToString(pi.GetValue(_entidade,null))+"|";
            }
            GravarEmLog(_acao,_entidade.GetType().Name, dados);
        }
    }
}