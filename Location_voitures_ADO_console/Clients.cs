using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_voitures_ADO_console
{
    public class Clients
    {
        public int Id_client { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adresse { get; set; }
        public int Codep { get; set; }
        public string Ville { get; set; }

        public override string ToString()
        {
            return $"ID Client : {Id_client}, Nom : {Nom}, Prénom : {Prenom}, né le : {Birthdate.ToShortDateString()}, domicilé au {Adresse} {Codep} {Ville}";
        }
    }
}
