//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkM2L
{
    using System;
    using System.Collections.Generic;
    
    public partial class DATEBENEVOLAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATEBENEVOLAT()
        {
            this.BENEVOLEs = new HashSet<BENEVOLE>();
        }
    
        public byte ID { get; set; }
        public System.DateTime DATEBENEVOLAT1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENEVOLE> BENEVOLEs { get; set; }
    }
}
