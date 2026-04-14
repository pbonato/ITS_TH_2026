using System;
using System.Data;
using System.Data.SqlClient;

using System;
using System.Data;
using System.Data.SqlClient;

namespace TechnicalIssue
{
    public partial class ModificaInterventi : System.Web.UI.Page
    {
        private static string connectionString =
            "Server=DESKTOP-GTS70T7\\SQLEXPRESS01;Database=TestInterventiTecnici;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CaricaInterventi();
        }

        private void CaricaInterventi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT IdIntervento, DataIntervento, Descrizione, Tecnico, Stato FROM Interventi",
                        conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvInterventi.DataSource = dt;
                    gvInterventi.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Errore durante il caricamento: " + ex.Message;
                lblMessage.CssClass = "text-danger fw-bold";
            }
        }

        protected void gvInterventi_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Elimina")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EliminaIntervento(id);
                CaricaInterventi();
            }
        }

        private void EliminaIntervento(int idIntervento)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Interventi WHERE IdIntervento = @id",
                        conn);

                    cmd.Parameters.AddWithValue("@id", idIntervento);

                    conn.Open();
                    int righe = cmd.ExecuteNonQuery();

                    if (righe > 0)
                    {
                        lblMessage.Text = "Intervento eliminato correttamente.";
                        lblMessage.CssClass = "text-success fw-bold";
                    }
                    else
                    {
                        lblMessage.Text = "Intervento non trovato.";
                        lblMessage.CssClass = "text-warning fw-bold";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Errore durante l'eliminazione: " + ex.Message;
                lblMessage.CssClass = "text-danger fw-bold";
            }
        }
    }
}