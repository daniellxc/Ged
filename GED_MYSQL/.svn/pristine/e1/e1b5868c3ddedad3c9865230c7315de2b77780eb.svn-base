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
    public class UsuarioBO
    {

        private class UsuarioDAO : AbstracCrudDAO<Usuario>, IUsuarioDAO
        {

            public UsuarioDAO()
            {

            }
        }



        private UsuarioDAO _DAO = new UsuarioDAO();

        public List<Usuario> GetAll()
        {
            return _DAO.GetAll();
        }

        public Usuario GetUsuario(string _login, string _senha)
        {
            return _DAO.Find(u => u.Login == _login && u.Senha == _senha).FirstOrDefault();
        }

        public Usuario GetUsuario(string _login)
        {
            return _DAO.Find(u => u.Login == _login).FirstOrDefault();
        }

        public Usuario GetByRegistro(int _registro)
        {
            return _DAO.Find(u => u.Registro == _registro).FirstOrDefault();
        }

        public List<Grupo> GetGruposDisponiveis(int _registroUsuario)
        {
            var retorno = from grupos in _DAO.GetContext.Grupos
                          select grupos;
            return retorno.ToList<Grupo>().Except(GetByRegistro(_registroUsuario).Grupos).ToList();
                       
        }

        public void SalvarUsuario(Usuario _usuario)
        {
            try
            {
                
                if (_usuario.Registro == 0)
                {
                    _usuario.DataCadastro = DateTime.Now;
                    _DAO.Add(_usuario);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_usuario, _usuario.Registro);

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

        public void ExcluirUsuario(Usuario _usuario)
        {
            try
            {


                _usuario.Grupos.RemoveAll(g=>g.Registro!=0);
                _DAO.Delete(_usuario);
            }
            catch (Exception ex)
            {
                throw new Erros.ErroGeral("Não foi possível excluir o usuário. " + ex.Message);
            }

        }

        public void CadastrarUsuarioGrupo(int _registroUsuario, int _registroGrupo)
        {
            try
            {
                using (var _context = _DAO.GetContext)
                {
                    Usuario _usuario = new Usuario();
                    _usuario = _context.Usuarios.Find(_registroUsuario);
                    _usuario.Grupos.Add(_context.Grupos.Find(_registroGrupo));
                    _DAO.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverUsuarioGrupo(int _registroUsuario, int _registroGrupo)
        {
            try
            {
                using (var _context = _DAO.GetContext)
                {
                    Usuario _usuario = new Usuario();
                    _usuario = _context.Usuarios.Find(_registroUsuario);
                    _usuario.Grupos.Remove(_context.Grupos.Find(_registroGrupo));
                    _DAO.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
