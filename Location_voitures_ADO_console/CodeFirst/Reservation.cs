using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_voitures_ADO_console.CodeFirst
{
    public class Reservation
    {
        [Key]
        public int Id_Location { get; set; }


        public virtual Customer Customer { get; set; }
        public int IdCustomer { get; set; }

        public int Id_Vehicule { get; set; }

        public int Distance { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }





    }
}
