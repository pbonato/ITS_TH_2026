using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalIssue
{
    public class lista_inteventi

    {
        private static String connectionString = "SERVER=CICCIOCAPUTO\\SQLExpress;DATABASE=TestInterventiTecnici;INTEGRATED SECURITY=True;";

        public int IdCliente { get; set; }

        public string RagioneSociale { get; set; }
        public string Descrizione { get; set; }
    }

    { public static List<lista_inteventi> GetIntXCLi()
    {
        List<lista_inteventi> IntXCLi = new List<lista_inteventi>();
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM vW_ClientiOrdini order by RagioneSociale", con);
        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListaIntXCli tmpIntXCLi = new lista_();
                
                tmpIntXCLi.RagioneSociale = (string)reader["RagioneSociale"];
                tmpIntXCLi.Descrizione = (string)reader["Descrizione"];
                IntXCLi.Add(tmpIntXCLi);
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

        return IntXCLi;
    }
}