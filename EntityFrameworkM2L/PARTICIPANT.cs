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
    
    public partial class PARTICIPANT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTICIPANT()
        {
            this.CONTENUHEBERGEMENTs = new HashSet<CONTENUHEBERGEMENT>();
        }
    
        public short ID { get; set; }
        public string NOMPARTICIPANT { get; set; }
        public string PRENOMPARTICIPANT { get; set; }
        public string ADRESSEPARTICIPANT1 { get; set; }
        public string ADRESSEPARTICIPANT2 { get; set; }
        public string CPPARTICIPANT { get; set; }
        public string VILLEPARTICIPANT { get; set; }
        public string TELPARTICIPANT { get; set; }
        public string MAILPARTICIPANT { get; set; }
        public System.DateTime DATEINSCRIPTION { get; set; }
        public Nullable<System.DateTime> DATEENREGISTREMENTARRIVEE { get; set; }
        public string CLEWIFI { get; set; }
    
        public virtual BENEVOLE BENEVOLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTENUHEBERGEMENT> CONTENUHEBERGEMENTs { get; set; }
        public virtual INTERVENANT INTERVENANT { get; set; }
        public virtual LICENCIE LICENCIE { get; set; }
    }
}
