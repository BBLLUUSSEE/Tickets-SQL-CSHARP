using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class TicketsDemo
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ticketing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void StampaInOrdineCronologico()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessione stabilita verso il DATABASE");
                }
                else
                {
                    Console.WriteLine("Connessione non stabilita verso il DATABASE");
                }

                string query = "SELECT * FROM Tickets ORDER BY Data DESC";
                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;

                SqlDataReader reader = comando.ExecuteReader();

                Console.WriteLine("Tickets");
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var descrizione = (string)reader["Descrizione"];
                    var data = (DateTime)reader["Data"];
                    var utente = (string)reader["Utente"];
                    var stato = (string)reader["Stato"];

                    Console.WriteLine($"{id} - {descrizione} - {data} - {utente} - {stato}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        internal static void InsertConParametriDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessione stabilita verso il DATABASE");
                }
                else
                {
                    Console.WriteLine("Connessione non stabilita verso il DATABASE");
                }

                //chiediamo all'utente di inserire nome e descrizione del nuovo ticket
                string nuovaDescrizione = "questa è una descrizione";
                string nuovaData = "2022-05-24 12:30";
                string nuovoUtente = "Denise";
                string nuovoStato = "OnGoing";

                string insertSQL = $"INSERT INTO Tickets VALUES (@nuovaDescrizione, @nuovaData, @nuovoUtente, @nuovoStato)";

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;
                insertCommand.Parameters.AddWithValue("@nuovaDescrizione", nuovaDescrizione);
                insertCommand.Parameters.AddWithValue("@nuovaData", nuovaData);
                insertCommand.Parameters.AddWithValue("@nuovoUtente", nuovoUtente);
                insertCommand.Parameters.AddWithValue("@nuovoStato", nuovoStato);

                int righeInserite = insertCommand.ExecuteNonQuery();
                if (righeInserite >= 1)
                {
                    Console.WriteLine($"{righeInserite} riga/righe inserite correttamente");
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto!!");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        public static void DeleteConParametriDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessione stabilita verso il DATABASE");
                }
                else
                {
                    Console.WriteLine("Connessione non stabilita verso il DATABASE");
                }

                //richiesta all'utente dell'id da eliminare
                int idDaEliminare = 10;

                string deleteSQL = "DELETE FROM Tickets WHERE ID = @id";

                SqlCommand deleteCommand = connessione.CreateCommand();
                deleteCommand.CommandText = deleteSQL;
                deleteCommand.Parameters.AddWithValue("@id", idDaEliminare);

                int righeCancellate = deleteCommand.ExecuteNonQuery();
                if (righeCancellate >= 1)
                {
                    Console.WriteLine($"{righeCancellate} riga/righe eliminate correttamente");
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto!!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }
    }
}
