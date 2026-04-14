using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TechnicalIssue
{
    public class Cliente
    {
        // Variabili private di classe
        private static String connectionString = "SERVER=DESKTOP-SKKJ6EJ\\SQLEXPRESS;DATABASE=TestInterventiTecnici;INTEGRATED SECURITY=True;";

        // Proprietà pubbliche di classe
        public int IdCliente { get; set; }
        public string RagioneSociale { get; set; }
        public string Citta { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Metodi pubblici di classe
        public static List<Cliente> GetClienti()
        {
            List<Cliente> clienti = new List<Cliente>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Clienti", con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente tmpCliente = new Cliente();
                    tmpCliente.IdCliente = (int)reader["IdCliente"];
                    tmpCliente.RagioneSociale = (string)reader["RagioneSociale"];
                    tmpCliente.Citta = (string)reader["Citta"];
                    tmpCliente.Telefono = (string)reader["Telefono"];
                    tmpCliente.Email = (string)reader["Email"];
                    clienti.Add(tmpCliente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            return clienti;
        }

        /*
        // Metodo gestione cliente tramite IdCliente
        public static Cliente GetClienteById(int id)
        {
            Cliente cliente = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Clienti WHERE IdCliente = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = (int)reader["IdCliente"],
                        RagioneSociale = (string)reader["RagioneSociale"],
                        Citta = (string)reader["Citta"],
                        Telefono = (string)reader["Telefono"],
                        Email = (string)reader["Email"]
                    };
                }
            }

            return cliente;
        }
        */
    }
}