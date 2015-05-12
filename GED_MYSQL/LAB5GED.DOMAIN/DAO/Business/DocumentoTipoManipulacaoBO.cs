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
    public class DocumentoTipoManipulacaoBO
    {
        private class DocumentoTipoManipulacaoDAO : AbstracCrudDAO<DocumentoTipoManipulacao>, IDocumentoTipoManipulacaoDAO
        {
            public DocumentoTipoManipulacaoDAO()
            {

            }
        }

        private DocumentoTipoManipulacaoDAO _DAO = new DocumentoTipoManipulacaoDAO();


        public  DocumentoTipoManipulacao GetByDescricao(string _descricao)
        {
            return _DAO.Find(dtm => dtm.DescricaoAcao.Equals(_descricao)).FirstOrDefault();
        }

        public void SalvarDocumentoTipoManipulacao(DocumentoTipoManipulacao _novoDocTipoManipulacao)
        {

            try
            {


                if (_novoDocTipoManipulacao.Registro == 0)
                {
                    _DAO.Add(_novoDocTipoManipulacao);
                    _DAO.SaveChanges();
                }
                else
                {
                    _DAO.Atualizar(_novoDocTipoManipulacao, _novoDocTipoManipulacao.Registro);

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
    }
}
