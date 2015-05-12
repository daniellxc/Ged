using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.MVC.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB5GED.MVC.Controllers
{
    public class PermissaoController : CustomController
    {
        //
        // GET: /Permissao/
        [PermissaoFiltro("Controlar Permissão")]
        public ActionResult Index()
        {
            return View(new AcaoBO().GetAll());
        }

        public ActionResult AdicionaGrupo(int _registroAcao)
        {
            return View(new AcaoBO().GetByRegistro(_registroAcao));
        }

        public ActionResult ConfigurarPermissao(int _registroAcao, int _registroGrupo, bool _adiciona)
        {
            try
            {
                Grupo _grupo = new GrupoBO().GetByRegistro(_registroGrupo);
                Acao  _acao = new AcaoBO().GetByRegistro(_registroAcao);
                if (_adiciona)
                {
                    new AcaoBO().CadastrarAcaoGrupo(_registroAcao, _registroGrupo);
                    Logador.LogAcao(Logador.LogAcoes.Configuração, "ADICIONAR PERMISSÃO: AÇÃO:" + _acao.NomeAcao + " GRUPO:" + _grupo.NomeGrupo);
                }
                else
                {
                    new AcaoBO().RemoverAcaoGrupo(_registroAcao, _registroGrupo);
                    Logador.LogAcao(Logador.LogAcoes.Configuração, "REMOVER PERMISSÃO: AÇÃO:" + _acao.NomeAcao + " GRUPO:" + _grupo.NomeGrupo);
                }

                return View("AdicionaGrupo", _acao);

            }
            catch(Exception ex)
            {
                
                return RedirectToAction("AdicionarGrupo").ComMensagemDeErro("Não foi possivel configurar esta permissão. Erro:" + ex.Message);
            }
            
        }

    }
}
