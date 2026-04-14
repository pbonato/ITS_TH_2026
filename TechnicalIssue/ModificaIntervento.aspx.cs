using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechnicalIssue.controller;

namespace TechnicalIssue
{
    public partial class ModificaIntervento : System.Web.UI.Page
    {
        private int IdIntervento
        {
            get { return ViewState["IdIntervento"] != null ? (int)ViewState["IdIntervento"] : 0; }
            set { ViewState["IdIntervento"] = value; }
        }

        private void CaricaClienti()
        {
            ddlClienti.DataTextField = "RagioneSociale";
            ddlClienti.DataValueField = "IdCliente";
            ddlClienti.DataBind();
        }

        private void CaricaTecnici()
        {
            string connStr = "SERVER=DESKTOP-BAVMQE9\\SQLEXPRESS;DATABASE=TestInterventiTecnici;INTEGRATED SECURITY=True;";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT DISTINCT Tecnico FROM Interventi";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlTecnico.Items.Add(reader["Tecnico"].ToString());
                }
            }
        }

        private void CaricaIntervento(int id)
        {
            var intervento = Intervento.GetInterventiByCliente(0).Find(i => i.IdIntervento == id); // qui puoi creare anche una funzione GetById
            if (intervento != null)
            {
                ddlClienti.SelectedValue = intervento.IdCliente.ToString();
                txtData.Text = intervento.DataIntervento.ToString("yyyy-MM-dd");
                txtDescrizione.Text = intervento.Descrizione;
                ddlTecnico.SelectedValue = intervento.Tecnico;
                ddlStato.SelectedValue = intervento.Stato;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(ddlClienti.SelectedValue);
            DateTime data = DateTime.ParseExact(txtData.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string descrizione = txtDescrizione.Text;
            string tecnico = ddlTecnico.SelectedValue;
            string stato = ddlStato.SelectedValue;

            string connStr = "SERVER=DESKTOP-BAVMQE9\\SQLEXPRESS;DATABASE=TestInterventiTecnici;INTEGRATED SECURITY=True;";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE Interventi SET DataIntervento=@data, Descrizione=@descrizione, Tecnico=@tecnico, Stato=@stato, IdCliente=@idCliente " +
                               "WHERE IdIntervento=@idIntervento";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@descrizione", descrizione);
                cmd.Parameters.AddWithValue("@tecnico", tecnico);
                cmd.Parameters.AddWithValue("@stato", stato);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idIntervento", IdIntervento);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("ElencoInterventi.aspx");
        }

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElencoInterventi.aspx");
        }
    }
}