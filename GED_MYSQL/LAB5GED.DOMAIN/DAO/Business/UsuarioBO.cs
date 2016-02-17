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

        public List<Subserie> GetSubseriesDisponiveis(int _registroUsuario)
        {
            var retorno = from subsereies in _DAO.GetContext.Subseries
                          select subsereies;
            return retorno.ToList<Subserie>().Except(GetByRegistro(_registroUsuario).Subseries).ToList();
        }

        public List<Classe> GetClassesAtivasUsuario(int _registroUsuario)
        {
            Contexto contexto = _DAO.GetContext;

            var query = from subseries in GetSubseriesAtivas(_registroUsuario)
                        join series in contexto.Series
                        on subseries.Serie equals series.Registro
                        join subclasses in contexto.Subclasses
                        on series.Subclasse equals subclasses.Registro
                        join classes in contexto.Classes
                        on subclasses.Classe equals classes.Registro
                        where classes.Ativo == true
                        select classes;

            return query.Distinct().ToList<Classe>();

        }


        public List<Subclasse> GetSubclassesAtivasUsuario(int _registroUsuario)
        {
            Contexto context = _DAO.GetContext;

            var query = from series in GetSeriesAtivasUsuario(_registroUsuario)
                        join subclasses in context.Subclasses
                        on series.Subclasse equals subclasses.Registro
                        where subclasses.Ativo == true
                        select subclasses;

            return query.Distinct().ToList<Subclasse>();

        }

        public List<Serie> GetSeriesAtivasUsuario(int _registroUsuario)
        {
            Contexto context = _DAO.GetContext;
         
            

            var query = from subseries in GetSubseriesAtivas(_registroUsuario)
                        join series in context.Series
                        on subseries.Serie equals series.Registro
                        where series.Ativo == true
                        select series;
                        
                 
      
         return query.Distinct().ToList<Serie>();

        }

        public List<Subserie> GetSubseriesAtivas(int _registroUsuario)
        {
            Contexto context = _DAO.GetContext;
          
                var query = from subseries in GetByRegistro(_registroUsuario).Subseries
                            where subseries.Ativo == true
                            select new Subserie { Registro = subseries.Registro, Rotulo_subserie = subseries.Id_subserie + '-' + subseries.Rotulo_subserie, Serie = subseries.Serie };

            
            return query.ToList();
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

                _usuario.Grupos.RemoveAll(g => g.Registro != 0);
                _DAO.Delete(_usuario);
            }
            catch (DbUpdateException)
            {
                throw new Erros.ErroGeral("Não foi possível excluir o usuário pois o mesmo está em uso.");
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

        public void AdicionarUsuarioSubserie(int _registroUsuario, int _registroSubserie, bool _inserir)
        {
            try
            {
                Contexto _context = _DAO.GetContext;
                
                    Usuario _usuario = _context.Usuarios.Find(_registroUsuario);
                    if(_inserir)
                        _usuario.Subseries.Add(_context.Subseries.Find(_registroSubserie));
                    else
                        _usuario.Subseries.Remove(_usuario.Subseries.Where(ss=>ss.Registro == _registroSubserie).First());

                    _DAO.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       
    }
}
