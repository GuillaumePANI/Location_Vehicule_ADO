using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_voitures_ADO_console
{
    class Program
    {
        static string choix = "";
        static string save = "";
        public static Controler controler = new Controler();
       

        static void Main(string[] args)
        {

            //MENU CRUD CLIENT
            while (AffichageMenuClient() != "q")
                switch (choix)
                {
                    case "1":
                   var client = CreationClient();
                        Ecrire_new_client(client);
                        break;


                    case "2":
                        LectureListe();
                        break;



                    case "3":
                        var idclient = GetIdClient();
                        var clt = CreationClient();
                        controler.UpdateBDD(idclient, clt);
                        
                        break;



                    case "4":

                        break;

                    default:
                        Console.WriteLine("Erreur, veuillez réessayer");
                        break;


                }









        }




        public static string AffichageMenuClient()
        {
            Console.WriteLine("Veuillez faire un choix");
            Console.WriteLine("-1- Creation d'un nouveau client");
            Console.WriteLine("-2- Lecture du fichier client");
            Console.WriteLine("-3- Mise à jour du fichier client");
            Console.WriteLine("-4- Suppression d'un client");
            Console.WriteLine("-Q- Revenir au menu précédent");
            return choix = Console.ReadLine();
        }

        public static string GetInfo(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine().ToUpper();
        }

        public static Client CreationClient()
        {
            
            #region variables Client
            string MessageNom = "Veuillez renseigner le NOM puis valider en appuyant sur entrée";
            string MessagePrenom = "Veuillez renseigner le PRENOM puis valider en appuyant sur entrée";
            string MessageNaissance = "Veuillez renseigner la DATE DE NAISSANCE au format JJ/MM/AAAA puis valider en appuyant sur entrée";
            string MessageAdresse = "Veuillez renseigner l'ADRESSE (numéro et nom de rue) puis valider en appuyant sur entrée";
            string MessagePostal = "Veuillez renseigner le CODE POSTAL puis valider en appuyant sur entrée";
            string MessageVille = "Veuillez renseigner la VILLE puis valider en appuyant sur entrée";

            DateTime birthdate;
            int codeP;

            #endregion

            string nom = GetInfo(MessageNom).ToUpper(); //récupère le nom en majuscule
            string prenom = GetInfo(MessagePrenom).ToUpper(); //récupère le prénom
            while (!DateTime.TryParse(GetInfo(MessageNaissance).ToUpper(), out birthdate)) //récupère la date
                Console.WriteLine("La date n'est pas au bon format");

            string adresse = GetInfo(MessageAdresse).ToUpper(); //récupère l'adresse

            while (!Int32.TryParse(GetInfo(MessagePostal), out codeP)) //récupère le code postal
                Console.WriteLine("Le code postal ne doit contenir que des chiffres");

            string ville = GetInfo(MessageVille).ToUpper(); //récupère la ville en majuscule

            Console.WriteLine($"Voulez vous ajouter à la base de donnée le client Nom : {nom}, Prénom : {prenom}, né le : {birthdate.ToString("dd/MM/yyyy")}, domicilié au {adresse} {codeP} {ville}");
            Console.WriteLine("O / N");
            save = Console.ReadLine().ToUpper();
            Client client = new Client();
            client.Nom = nom; client.Prenom = prenom; client.Birthdate = birthdate; client.Adresse = adresse; client.Codep = codeP; client.Ville = ville; ;
            return client;
        }
        public static void Ecrire_new_client(Client client)
        {         if (save == "O")
            {
                controler.WriteClient(client);
                Console.WriteLine(controler.nbRows + "Client créé");
            }
        }

        public static void LectureListe()
        {
            string MessageClientID = "Quelle entrée client souhaitez vous consulter ? Renseignez l'ID_CLIENT";
            int clientID;
            while (! Int32.TryParse(GetInfo(MessageClientID), out clientID))
                Console.WriteLine("Erreur, ID Client non reconnue");
            Console.WriteLine(controler.LectureBDD(clientID));
            

        }

        public static int GetIdClient()
        {
            string MessageClient = "Quel client souhaitez vous modifier ? Renseigner l'ID_Client";
            int idclient;
            while (!Int32.TryParse(GetInfo(MessageClient), out idclient))
                Console.WriteLine("Erreur, l'ID_Client n'est pas connu");

            return idclient;
        }




        




    }




}