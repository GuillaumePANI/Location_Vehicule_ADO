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
    
    public partial class VEHICULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VEHICULE()
        {
            this.LOUE = new HashSet<LOUE>();
        }
    
        public int ID_VEHICULE { get; set; }
        public string IMMATRICULATION { get; set; }
        public string COULEUR { get; set; }
        public System.DateTime DATE_DE_MISE_EN_SERVICE { get; set; }
        public Nullable<int> MARQUE_ID { get; set; }
        public Nullable<int> CATEGORIE_ID { get; set; }
    
        public virtual CATEGORIE CATEGORIE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOUE> LOUE { get; set; }
        public virtual MARQUE MARQUE { get; set; }
    }
}