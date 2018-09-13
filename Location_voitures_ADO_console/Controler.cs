using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_voitures_ADO_console
{
    class Controler
    {
        public static string strConnexion = @"Data Source=(localdb)\MSSQLLocalDB; Integrated Security=SSPI;Initial Catalog=LOCATION";
        public int nbRows;



        public void WriteClient(Client client)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
                {
                    SqlCommand sqlCommand = new SqlCommand($"insert into CLIENT VALUES ('{client.Nom}','{client.Prenom}', '{client.Birthdate.ToString("yyyy-MM-dd")}', '{client.Adresse}', '{client.Codep}', '{client.Ville}')", sqlConnection);
                    sqlConnection.Open();
                    nbRows = sqlCommand.ExecuteNonQuery();
                }
            }//sqlConnection.Close();

            catch (Exception e) { Console.WriteLine("Erreur :" + e.Message); }
        }


        public Client LectureBDD(int clientId)
        {
            Client client = new Client();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
                {
                    SqlCommand sqlCommand = new SqlCommand($"select * from CLIENT where ID_CLIENT = {clientId}", sqlConnection);



                    sqlConnection.Open();
                   

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                         client = new Client { Id_client = sqlDataReader.GetInt32(0), Nom = sqlDataReader.GetString(1), Prenom = sqlDataReader.GetString(2), Birthdate = sqlDataReader.GetDateTime(3), Adresse = sqlDataReader.GetString(4), Codep = sqlDataReader.GetInt32(5), Ville = sqlDataReader.GetString(6) };

                    }
                } //sqlConnection.Close();
            }
            catch (Exception e) { Console.WriteLine("Erreur :" + e.Message); }
            return client;
        }

        public void UpdateBDD(int idClient, Client client)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
                {
                    SqlCommand sqlCommand = new SqlCommand($"Update into CLIENT " +
                        $"set NOM = '{client.Nom}', PRENOM = '{client.Prenom}', DATE_DE_NAISSANCE = '{client.Birthdate}', ADRESSE = '{client.Adresse}', CODE_POSTAL = {client.Codep}, VILLE = '{client.Ville}' " +
                        $"where ID_CLIENT = {idClient}", sqlConnection);
                    sqlConnection.Open();
                    nbRows = sqlCommand.ExecuteNonQuery();


                } //sqlConnection.Close();
            }
            catch (Exception e) { Console.WriteLine("Erreur :" + e.Message); }
        }
    }
}