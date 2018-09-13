using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_voitures_ADO_console.EDMX
{
    partial class CLIENT
    {
        public override string ToString()
        {
            return $"Client #{ID_CLIENT}, {NOM} {PRENOM}, né le {DATE_DE_NAISSANCE.ToShortDateString()}, domicilié au {ADRESSE} {CODE_POSTAL} {VILLE} {PAYS}";
        }
    }
}
