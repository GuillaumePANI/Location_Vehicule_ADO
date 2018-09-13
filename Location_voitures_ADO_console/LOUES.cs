using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_voitures_ADO_console.EDMX
{
    partial class LOUE
    {
        public override string ToString()
        {
            return $"Location #{ID_LOCATION}, Client #{ID_CLIENT}, Distance parcourue : {NB_KM}km du {DATE_DEBUT.ToShortDateString()} au {DATE_FIN.ToShortDateString()}, avec le vehicule #{VEHICULE_ID}";
        }

    }
}
