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
    class Controler
    {
        public static string strConnexion = @"Data Source=(localdb)\MSSQLLocalDB; Integrated Security=SSPI;Initial Catalog=LOCATION";
       

        LOCATIONEntities Context = new LOCATIONEntities();

        #region Table client
        public void WriteClient(CLIENT client)
        {
            Context.CLIENT.Add(client);
            Context.SaveChanges();
        }


        public CLIENT LectureBDD(int clientId)
        {
            CLIENT client = Context.CLIENT.FirstOrDefault(a => a.ID_CLIENT == clientId);

            return client;
        }

        public void UpdateBDD(CLIENT client)
        {
            CLIENT bDClient = Context.CLIENT.FirstOrDefault(a => a.ID_CLIENT == client.ID_CLIENT);
            bDClient.NOM = client.NOM;
            bDClient.PRENOM = client.PRENOM;
            bDClient.DATE_DE_NAISSANCE = client.DATE_DE_NAISSANCE;
            bDClient.ADRESSE = client.ADRESSE;
            bDClient.CODE_POSTAL = client.CODE_POSTAL;
            bDClient.VILLE = client.VILLE;
            Context.SaveChanges();
        }

        public void DeleteBdd(int idClient)
        {
            CLIENT client = Context.CLIENT.Find(idClient);
            Context.CLIENT.Remove(client);
            Context.SaveChanges();
        }

        #endregion

        #region table LOUE

        public void WriteLoc(LOUE loc)
        {
            Context.LOUE.Add(loc);
            Context.SaveChanges();
        }
        public LOUE LectureLoc(int locID)
        {
            LOUE loc = Context.LOUE.FirstOrDefault(a => a.ID_LOCATION == locID);
            return loc;
        }

        public void UpdateBDDLoc(LOUE loc)
        {
            LOUE bDloc = Context.LOUE.FirstOrDefault(a => a.ID_LOCATION == loc.ID_LOCATION);
            bDloc.ID_CLIENT = loc.ID_CLIENT;
            bDloc.VEHICULE_ID = loc.VEHICULE_ID;
            bDloc.NB_KM = loc.NB_KM;
            bDloc.DATE_DEBUT = loc.DATE_DEBUT;
            bDloc.DATE_FIN = loc.DATE_FIN;
            Context.SaveChanges();
        }
        public void DeleteBddLoc(int idLoc)
        {
            LOUE loc = Context.LOUE.Find(idLoc);
            Context.LOUE.Remove(loc);
            Context.SaveChanges();
        }



        #endregion
    }
}