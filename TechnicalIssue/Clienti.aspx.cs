using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnicalIssue
{
    public partial class Clienti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CaricaClienti();
            }
        }

        private void CaricaClienti()
        {
            List<Cliente> clienti = Cliente.GetClienti();
            gvClienti.DataSource = clienti;
            gvClienti.DataBind();
        }

        protected void btnTornaHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}