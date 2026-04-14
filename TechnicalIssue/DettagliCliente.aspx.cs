using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnicalIssue
{
    public partial class DettagliCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdCliente"] != null)
                {
                    int idCliente = int.Parse(Request.QueryString["IdCliente"]);
                    CaricaCliente(idCliente);
                    CaricaInterventiCliente(idCliente);
                }
                else
                {
                    Response.Redirect("Clienti.aspx");
                }
            }
        }

        private void CaricaCliente(int id)
        {
            Cliente c = Cliente.GetClienteById(id); // metodo da implementare in Cliente.cs
            if (c != null)
            {
                lblRagioneSociale.Text = c.RagioneSociale;
                lblCitta.Text = c.Citta;
                lblTelefono.Text = c.Telefono;
                lblEmail.Text = c.Email;
            }
        }

        private void CaricaInterventiCliente(int id)
        {
            Intervento intervento = new Intervento();
            List<Intervento> interventi = intervento.GetInterventiByCliente(id); // metodo da implementare in Intervento.cs
            gvInterventiCliente.DataSource = interventi;
            gvInterventiCliente.DataBind();
        }

        protected void btnTornaClienti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clienti.aspx");
        }
    }
}