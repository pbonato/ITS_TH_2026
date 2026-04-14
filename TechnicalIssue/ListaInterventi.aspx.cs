using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnicalIssue
{
    public partial class ListaInterventi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Intervento> Listcli = Intervento.GetInterventiByCliente();
            gvInterventi.DataSource = Listcli;
            gvInterventi.DataBind();

        }

        protected System.Void Btn_aggiungi_click(System.Object sender, System.EventArgs e)  //nome del  bottone da cambiare quando verra creato
        {
            responce.redirect("CreaIntervento.aspx");
        }

        protected System.Void Button1_Click(System.Object sender, System.EventArgs e)  //nome del  bottone da cambiare quando verra creato
        {
            responce.redirect("Default.aspx");
        }
    }
}
