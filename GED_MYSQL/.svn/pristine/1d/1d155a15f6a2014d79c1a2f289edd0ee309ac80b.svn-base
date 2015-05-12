using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5GED.WEB.Acessorio
{
    public class MetodosUsoGeral
    {
        public static void LimparCampos(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;


                LimparCampos(ctrl.Controls);
            }
        }

        public static void MensagemDeErro(string mensagem, HttpResponse response)
        {
            response.Write("<div style='background-color:red;'>" + mensagem + "</div>");

        }

        public static void MensagemDeSucesso(string mensagem, HttpResponse response)
        {
            response.Write("<div style='background-color:green;'>" + mensagem + "</div>");

        }
    }
}