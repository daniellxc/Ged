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

    public class UsuarioController : CustomController
    {
        //
        // GET: /Usuario/
        private UsuarioBO _DAO = new UsuarioBO();

        [PermissaoFiltro("Controlar Usuário")]
        public ActionResult Index()
        {
            MetodosUtilidadeGeral.LimparSessaoEdicao(Session); 
            return View(_DAO.GetAll());
        }

        public ActionResult Cadastrar(Usuario _usuario)
        {
            return View(_usuario);
        }

        public ActionResult Editar(int _registroUsuario)
        {
            Session["id"] = _registroUsuario;
            return View("Cadastrar",_DAO.GetByRegistro(_registroUsuario));
        }

        public ActionResult CadastrarUsuario(Usuario _novoUsuario)
        {
            if (!ModelState.IsValid)
                return View("Cadastrar", _novoUsuario);
            {
                try
                {

                    Salvar(_novoUsuario);
                    Logador.LogEntidade(Logador.LogAcoes.Salvar, _novoUsuario);
                    return RedirectToAction("Index","Usuario").ComMensagemDeSucesso("Usuário cadastrado com sucesso!");

                }
                catch (Exception ex)
                {
                   
                    return View("Cadastrar", _novoUsuario).ComMensagemDeErro(ex.Message);

                }
            }

        }

        public void Salvar(Usuario _novoUsuario)
        {
            try
            {

                if (Session["id"] != null) _novoUsuario.Registro = int.Parse(Session["id"].ToString());
                else
                    _novoUsuario.Senha = new Seguranca().getMD5Hash(_novoUsuario.Senha);
                _DAO.SalvarUsuario(_novoUsuario);
                Logador.LogAcao(Logador.LogAcoes.Configuração, "ALTERAR SENHA. USUÁRIO: " + _novoUsuario.Login);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Excluir(string Id)
        {
            try
            {
                Usuario _usuario = _DAO.GetByRegistro(int.Parse(Id));
                _DAO.ExcluirUsuario(_usuario);
                Logador.LogEntidade(Logador.LogAcoes.Excluir, _usuario);
                return RedirectToAction("Index","Usuario");
            }
            catch (Exception ex)
            {
               
                return RedirectToAction("Index").ComMensagemDeErro(ex.Message);
            }
        }

        [PermissaoFiltro("Alterar Senha")]
        public ActionResult AlterarSenha(Usuario _usuarioAlterar)
        {
            Session["id"] = _usuarioAlterar.Registro;
            return View(_usuarioAlterar);
        }


        public ActionResult ExecutaAlterarSenha(Usuario _usuario)
        {
            try
            {
                _usuario.DataCadastro = _DAO.GetByRegistro(_usuario.Registro).DataCadastro;
                _usuario.Senha = new Seguranca().getMD5Hash(_usuario.Senha);
                Salvar(_usuario);
                Logador.LogAcao(Logador.LogAcoes.Configuração, "ALTERAR SENHA. USUÁRIO: " + _usuario.Login);
                return RedirectToAction("Index", "Home").ComMensagemDeSucesso("Senha alterada com sucesso!");
                
            }
            catch (Exception ex)
            {
               
                return RedirectToAction("AlterarSenha", _usuario).ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult AdicionarAoGrupo(int _registroUsuario)
        {
            return View(_DAO.GetByRegistro(_registroUsuario));
        }


        public ActionResult MeuPerfil(int _registroUsuario)
        {
            return View(_DAO.GetByRegistro(_registroUsuario));
        }

        public ActionResult AlterarPerfil(Usuario _usuario)
        {
            if (!ModelState.IsValid)
                return View("MeuPerfil", _usuario);
            {
                try
                {

                    Salvar(_usuario);
                    Logador.LogEntidade(Logador.LogAcoes.Editar, _usuario);
                    return RedirectToAction("Index", "Home").ComMensagemDeSucesso("Perfil alterado com sucesso!");

                }
                catch (Exception ex)
                {
                    
                    return RedirectToAction("MeuPerfil", new {_registroUsuario = _usuario.Registro}).ComMensagemDeErro(ex.Message);

                }
            }
            
        }
   

        public ActionResult ConfigurarPerfil(int _registroUsuario, int _registroGrupo, bool _adiciona)
        {
            try
            {
                Grupo _grupo = new GrupoBO().GetByRegistro(_registroGrupo);
                Usuario _usuario = new UsuarioBO().GetByRegistro(_registroUsuario);

                if (_adiciona)
                    {
                    _DAO.CadastrarUsuarioGrupo(_registroUsuario, _registroGrupo);
                    Logador.LogAcao(Logador.LogAcoes.Configuração, "ADICIONAR USUÁRIO AO GRUPO: USUÁRIO:"+_usuario.Login + " GRUPO:"+ _grupo.NomeGrupo);
                    }
                else
                {
                    _DAO.RemoverUsuarioGrupo(_registroUsuario, _registroGrupo);
                    Logador.LogAcao(Logador.LogAcoes.Configuração, "REMOVER USUÁRIO DO GRUPO: USUÁRIO:"+_usuario.Login + " GRUPO:"+_grupo.NomeGrupo);
                }

                return View("AdicionarAoGrupo",_usuario);
            }
            catch (Exception ex)
            {
              
                return View("AdicionarAoGrupo", _registroUsuario).ComMensagemDeErro(ex.Message);
            }

        }
    }
}
