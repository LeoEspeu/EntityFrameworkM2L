﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class M2LEntitie : DbContext
    {
        public M2LEntitie()
            : base("name=M2LEntitie")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ATELIER> ATELIERs { get; set; }
        public virtual DbSet<BENEVOLE> BENEVOLEs { get; set; }
        public virtual DbSet<CATEGORIECHAMBRE> CATEGORIECHAMBREs { get; set; }
        public virtual DbSet<CONTENUHEBERGEMENT> CONTENUHEBERGEMENTs { get; set; }
        public virtual DbSet<DATEBENEVOLAT> DATEBENEVOLATs { get; set; }
        public virtual DbSet<DATENUITE> DATENUITEs { get; set; }
        public virtual DbSet<HOTEL> HOTELs { get; set; }
        public virtual DbSet<INSCRIRE> INSCRIREs { get; set; }
        public virtual DbSet<INTERVENANT> INTERVENANTs { get; set; }
        public virtual DbSet<LICENCIE> LICENCIEs { get; set; }
        public virtual DbSet<PAIEMENT> PAIEMENTs { get; set; }
        public virtual DbSet<PARTICIPANT> PARTICIPANTs { get; set; }
        public virtual DbSet<PARTICIPER> PARTICIPERs { get; set; }
        public virtual DbSet<PROPOSER> PROPOSERs { get; set; }
        public virtual DbSet<QUALITE> QUALITEs { get; set; }
        public virtual DbSet<RESTAURATION> RESTAURATIONs { get; set; }
        public virtual DbSet<STATUT> STATUTs { get; set; }
        public virtual DbSet<THEME> THEMEs { get; set; }
        public virtual DbSet<VACATION> VACATIONs { get; set; }
        public virtual DbSet<PARAMETRE> PARAMETRES { get; set; }
        public virtual DbSet<VCATEGORIECHAMBRE01> VCATEGORIECHAMBRE01 { get; set; }
        public virtual DbSet<VDATENUITE01> VDATENUITE01 { get; set; }
        public virtual DbSet<VHOTEL01> VHOTEL01 { get; set; }
        public virtual DbSet<VRESTAURATION01> VRESTAURATION01 { get; set; }
    }
}
