using LAB5GED.DOMAIN.Acessorio;
using LAB5GED.DOMAIN.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace LAB5GED.DOMAIN.DAO.Business
{
    public class AcaoBO
    {
        private class AcaoDAO : AbstracCrudDAO<Acao>, IBaseCrudDAO<Acao>
        {
            public AcaoDAO()
            {

            }
        }

        AcaoDAO _DAO = new AcaoDAO();

        public void SalvarAcao(Acao _acao)
        {
            try
            {

                if (_acao.Registro == 0)
                {

                    _DAO.Add(_acao);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_acao, _acao.Registro);
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

        public void CadastrarAcaoGrupo(int _registroAcao, int _registroGrupo)
        {
            try
            {
                using (var _context = _DAO.GetContext)
                {
                    Acao _acao = new Acao();
                    _acao = _context.Acoes.Find(_registroAcao);
                    _acao.Grupos.Add(_context.Grupos.Find(_registroGrupo));
                    _DAO.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoverAcaoGrupo(int _registroAcao, int _registroGrupo)
        {
            try
            {
                using (var _context = _DAO.GetContext)
                {
                    Acao _acao = new Acao();
                    _acao = _context.Acoes.Find(_registroAcao);
                    _acao.Grupos.Remove(_context.Grupos.Find(_registroGrupo));
                    _DAO.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Acao GetByRegistro(int _registro)
        {
            return _DAO.Find(a => a.Registro.Equals(_registro)).First();
        }

        public List<Acao> GetAll()
        {
            return _DAO.GetAll().OrderBy(a => a.NomeAcao).ToList();
        }

        public List<Acao> GetAcoesDoGrupo(int _registroGrupo)
        {
            return new GrupoBO().GetByRegistro(_registroGrupo).Acoes; 

        }

        /// <summary>
        /// Grupo que acessam a ação
        /// </summary>
        /// <param name="_registroAcao"></param>
        /// <returns></returns>
        public List<Grupo> GruposComPermissao(int _registroAcao)
        {
            return GetByRegistro(_registroAcao).Grupos;
        }

        /// <summary>
        /// Grupos que NÃO acessa a ação
        /// </summary>
        /// <param name="_registroAcao"></param>
        /// <returns></returns>
        public List<Grupo> GruposSemPermissao(int _registroAcao)
        {
            var retorno = from grupo in _DAO.GetContext.Grupos
                          select grupo;
            return retorno.ToList<Grupo>().Except(GruposComPermissao(_registroAcao)).ToList<Grupo>();
        }


    }
}
