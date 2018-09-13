using Location_voitures_ADO_console.EDMX;
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
            //MENU PRINCIPAL
            while (AffichageMenuPrincipal() != "q")
                switch (choix)
                {

                    case "1":
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
                                        int clientID;
                                        while (!Int32.TryParse(GetInfo("Quelle Entrée souhaitez vous modifier ? Renseigner l'ID_Client"), out clientID))
                                            Console.WriteLine("Erreur, l'ID_Client est incorrect");
                                        CLIENT clt = CreationClient();
                                        clt.ID_CLIENT = clientID;
                                        controler.UpdateBDD(clt);

                                        break;



                                    case "4":
                                        while (!Int32.TryParse(GetInfo("Quelle Entrée souhaitez vous supprimer ? Renseigner l'ID_Client"), out clientID))
                                            Console.WriteLine("Erreur, l'ID_Client est incorrect");
                                        controler.DeleteBdd(clientID);

                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez réessayer");
                                        break;


                                }
                            break;
                        }

                    case "2":
                        {
                            //MENU CRUD LOCATION
                            while (AffichageMenuLoc() != "q")
                                switch (choix)
                                {
                                    case "1":
                                        var loc = CreationLOC();
                                        controler.WriteLoc(loc);
                                        break;


                                    case "2":
                                        LectureLoc();
                                        break;



                                    case "3":
                                        int locID;
                                        while (!Int32.TryParse(GetInfo("Quelle Entrée souhaitez vous modifier ? Renseigner l'ID_Location"), out locID))
                                            Console.WriteLine("Erreur, l'ID_Loc est incorrect");
                                        loc = CreationLOC();
                                        loc.ID_LOCATION = locID;
                                        controler.UpdateBDDLoc(loc);

                                        break;



                                    case "4":
                                        while (!Int32.TryParse(GetInfo("Quelle Entrée souhaitez vous supprimer ? Renseigner l'ID_Location"), out locID))
                                            Console.WriteLine("Erreur, l'ID_Client est incorrect");
                                        controler.DeleteBddLoc(locID);

                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez réessayer");
                                        break;


                                }
                            break;
                        }

                    default:
                        Console.WriteLine("Erreur, veuillez recommencer"); break;
                }

        }

        public static string GetInfo(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine().ToUpper();
        }

        public static string AffichageMenuPrincipal()
        {
            Console.WriteLine("Sur quel fichier voulez vous travailler ?");
            Console.WriteLine("-1- Fichier Client");
            Console.WriteLine("-2- Fichier Location");
            Console.WriteLine("-Q- Quitter");
            return choix = Console.ReadLine();
        }







        #region Manipulation BddCLIENT

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


        public static CLIENT CreationClient()
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
            CLIENT client = new CLIENT();
            client.NOM = nom; client.PRENOM = prenom; client.DATE_DE_NAISSANCE = birthdate; client.ADRESSE = adresse; client.CODE_POSTAL = codeP; client.VILLE = ville; ;
            return client;
        }
        public static void Ecrire_new_client(CLIENT client)
        {
            if (save == "O")
            {
                controler.WriteClient(client);
            }
        }

        public static void LectureListe()
        {
            string MessageClientID = "Quelle entrée client souhaitez vous consulter ? Renseignez l'ID_CLIENT";
            int clientID;
            while (!Int32.TryParse(GetInfo(MessageClientID), out clientID))
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

        #endregion


        #region  Manipulation BddLocation

        public static string AffichageMenuLoc()
        {
            Console.WriteLine("Veuillez faire un choix");
            Console.WriteLine("-1- Creation d'une nouvelle Location");
            Console.WriteLine("-2- Lecture du fichier Location");
            Console.WriteLine("-3- Mise à jour du fichier Location");
            Console.WriteLine("-4- Suppression d'une Location");
            Console.WriteLine("-Q- Revenir au menu précédent");
            return choix = Console.ReadLine();
        }
        public static LOUE CreationLOC()
        {

            #region variables location
            string MessageIdClient = "Veuillez renseigner l'ID_Client du conducteur";
            string MessageIdVehicule = "Veuillez renseigner l'ID_Vehicule du véhicule loué";
            string MessageNbKm = "Veuillez renseigner la distance parcourue";
            string MessageDebut = "Veuillez renseigner la date de début de la location (JJ/MM/AAAA)";
            string MessageFin = "Veuillez renseigner  la date de fin de la location (JJ/MM/AAAA)";
            #endregion

            int IdClient;
            while(!Int32.TryParse(GetInfo(MessageIdClient), out IdClient))
                Console.WriteLine("Erreur, l'ID_Client doit être uniquement composé de chiffres");  //récupère l'ID_Client
            int IdVehicule;
            while (!Int32.TryParse(GetInfo(MessageIdVehicule), out IdVehicule))
                Console.WriteLine("Erreur, l'ID_Vehicule doit être uniquement composé de chiffres");  //récupère l'ID_Vegicule
            int nbKm;
            while (!Int32.TryParse(GetInfo(MessageNbKm), out nbKm))
                Console.WriteLine("Erreur, le kilometrage doit être uniquement composé de chiffres");

            DateTime dateDebut;
            while (!DateTime.TryParse(GetInfo(MessageDebut), out dateDebut)) //récupère la date de début
                Console.WriteLine("La date n'est pas au bon format");
            DateTime dateFin;
            while (!DateTime.TryParse(GetInfo(MessageFin), out dateFin)) //récupère la date de début
                Console.WriteLine("La date n'est pas au bon format");

            LOUE loc = new LOUE();
            loc.ID_CLIENT = IdClient; loc.VEHICULE_ID = IdVehicule; loc.NB_KM = nbKm; loc.DATE_DEBUT = dateDebut; loc.DATE_FIN = dateFin;
            return loc;
        }
        public static void LectureLoc()
        {
            string MessageLocID = "Quelle entrée location souhaitez vous consulter ? Renseignez l'ID_Location";
            int locID;
            while (!Int32.TryParse(GetInfo(MessageLocID), out locID))
                Console.WriteLine("Erreur, ID Client non reconnue");
            Console.WriteLine(controler.LectureLoc(locID));


        }


    #endregion
    }



}