using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TechnicalIssue
{
    public class Intervento
    {
        public int IdIntervento { get; set; }
        public DateTime DataIntervento { get; set; }
        public string Descrizione { get; set; }
        public string Tecnico { get; set; }
        public string Stato { get; set; }
        public int IdCliente { get; set; }

        private string connString = @"Server=DESKTOP-B6PIEOF\SQLEXPRESS;Database=TestInterventiTecnici;Trusted_Connection=True;";

        //Tutti gli interventi di un cliente
        public List<Intervento> GetInterventiByCliente(int cliente)
        {
            List<Intervento> lista = new List<Intervento>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM Interventi WHERE IdCliente=@IdCliente";
                SqlCommand cmd = new SqlCommand (query, conn);
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Intervento
                    {
                        IdIntervento = (int)reader["IdIntervento"],
                        DataIntervento = (DateTime)reader["DataIntervento"],
                        Descrizione = reader["Descrizione"].ToString(),
                        Tecnico = reader["Tecnico"].ToString(),
                        Stato = reader["Stato"].ToString(),
                        IdCliente = (int)reader["IdCliente"]
                    });
                }
            }
            return lista;
        }

        //Tutti gli interventi 
        public List<Intervento> GetInterventi()
        {
            List<Intervento> lista = new List<Intervento>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM Interventi";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Intervento
                    {
                        IdIntervento = (int)reader["IdIntervento"],
                        DataIntervento = (DateTime)reader["DataIntervento"],
                        Descrizione = reader["Descrizione"].ToString(),
                        Tecnico = reader["Tecnico"].ToString(),
                        Stato = reader["Stato"].ToString(),
                        IdCliente = (int)reader["IdCliente"]
                    });
                }
            }

            return lista;
        }

    }
}