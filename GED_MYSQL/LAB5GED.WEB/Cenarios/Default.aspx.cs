using LAB5GED.DOMAIN.DAO.Business;
using LAB5GED.DOMAIN.Entidades;
using LAB5GED.WEB.Acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5GED.WEB.Cenarios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Classe classe = new Classe();
                classe.Ativo = true;
                classe.Id_classe = "001";
                classe.Rotulo = "Classe Teste";

                new ClasseBO().SalvarClasse(classe);

                MetodosUsoGeral.MensagemDeSucesso("SUCESSO",Response);
            }
            catch (Exception ex)
            {
                MetodosUsoGeral.MensagemDeErro(ex.Message, Response);
            }
        }
    }
}