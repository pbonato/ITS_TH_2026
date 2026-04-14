using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TechnicalIssue.controller
{
    public class Intervento
    {
        public int IdIntervento { get; set; }
        public DateTime DataIntervento { get; set; }
        public string Descrizione { get; set; }
        public string Tecnico { get; set; }
        public string Stato { get; set; }
        public int IdCliente { get; set; }

        public static List<Intervento> GetInterventiByCliente(int idCliente)
        {
            List<Intervento> lista = new List<Intervento>();

            string connectionString = "SERVER=DESKTOP-BAVMQE9\\SQLEXPRESS;DATABASE=TestInterventiTecnici;INTEGRATED SECURITY=True;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Interventi WHERE IdCliente = @idCliente";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Intervento i = new Intervento();
                    i.IdIntervento = (int)reader["IdIntervento"];
                    i.DataIntervento = (DateTime)reader["DataIntervento"];
                    i.Descrizione = reader["Descrizione"].ToString();
                    i.Tecnico = reader["Tecnico"].ToString();
                    i.Stato = reader["Stato"].ToString();

                    lista.Add(i);
                }
            }

            return lista;
        }
        public static List<Intervento> GetInterventi()
        {
            List<Intervento> lista = new List<Intervento>();
            string connectionString = "SERVER=DESKTOP-BAVMQE9\\SQLEXPRESS;DATABASE=TestInterventiTecnici;INTEGRATED SECURITY=True;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Interventi";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Intervento i = new Intervento();
                    i.IdIntervento = (int)reader["IdIntervento"];  // Assicurati che ci sia!
                    i.IdCliente = (int)reader["IdCliente"];        // Serve per il dropdown clienti
                    i.DataIntervento = (DateTime)reader["DataIntervento"];
                    i.Descrizione = reader["Descrizione"].ToString();
                    i.Tecnico = reader["Tecnico"].ToString();
                    i.Stato = reader["Stato"].ToString();

                    lista.Add(i);
                }
            }
            return lista;
        }
    }
}