//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Location_voitures_ADO_console
{
    using System;
    using System.Collections.Generic;
    
    public partial class CATEGORIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIE()
        {
            this.VEHICULE = new HashSet<VEHICULE>();
        }
    
        public int CATEGORIE_ID { get; set; }
        public string LIBELLE { get; set; }
        public int PRIX_KM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICULE> VEHICULE { get; set; }
    }
}
