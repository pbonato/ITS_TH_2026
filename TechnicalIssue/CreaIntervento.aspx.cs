using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnicalIssue
{
    public partial class CreaIntervento : System.Web.UI.Page
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["TechincalIssueDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopolaClienti(); //Riempire il dropdown con i clienti esistenti
            }
        }

        private void PopolaClienti()
        {
            ddlRagioneSociale.Items.Clear();

            const string sql = "SELECT IdCliente, RagioneSociale FROM Clienti ORDER BY RagioneSociale"; //query per ottenere i clienti ordinati alfabeticamente

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = null;

                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader["IdCliente"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCliente"]);
                        string ragione = reader["RagioneSociale"] == DBNull.Value ? string.Empty : reader["RagioneSociale"].ToString();

                        ddlRagioneSociale.Items.Add(new ListItem(ragione, id.ToString()));//primo parametro è il testo cioè la ragione sociale, secondo è il valore effettivo da mettere nel database cioè l'idCliente
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (reader != null && !reader.IsClosed) reader.Close();
                    con.Close();
                }
            }
        }

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaInterventi.aspx");//ritorna alla pagina di ListaInterventi senza salvare nulla
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ddlRagioneSociale.SelectedValue) ||
                !int.TryParse(ddlRagioneSociale.SelectedValue, out int idCliente) ||
                !DateTime.TryParse(txtDataIntervento.Text, out DateTime dataIntervento) ||
                string.IsNullOrWhiteSpace(txtTecnico.Text) ||
                string.IsNullOrWhiteSpace(txtDescrizione.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "err", "alert('Dati non validi. Compilare tutti i campi obbligatori.');", true);
                return; //se i dati non sono validi, mostra un messaggio di errore e non procedere con l'inserimento
            }

            string descrizione = txtDescrizione.Text.Trim();
            string tecnico = txtTecnico.Text.Trim();
            string stato = ddlStato.SelectedValue ?? "Aperto";

            const string insertSql = "INSERT INTO Interventi (DataIntervento, Descrizione, Tecnico, Stato, IdCliente) " +
                                     "VALUES (@DataIntervento, @Descrizione, @Tecnico, @Stato, @IdCliente)";
            //query per inserire nella tabella interventi i dati raccolti dal form, usando parametri per evitare SQL injection e gestire correttamente i tipi di dato
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertSql, con))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@DataIntervento", dataIntervento);
                    cmd.Parameters.AddWithValue("@Descrizione", descrizione);
                    cmd.Parameters.AddWithValue("@Tecnico", tecnico);
                    cmd.Parameters.AddWithValue("@Stato", stato);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Response.Redirect("ListaInterventi.aspx");//se l'inserimento è riuscito, torna alla pagina ListaInterventi
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "err", "alert('Inserimento non riuscito.');", true);
                    }
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "err", "alert('Errore durante il salvataggio.');", true);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}