using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace EntityFrameworkM2L
{
    public class bdd
    {
        /// <summary>
        /// Objet Etity Framework
        /// </summary>
        private M2LEntitie M2LContexte;

        /// <summary>
        /// Constructeur de la classe bdd
        /// </summary>
        public bdd()
        {
            M2LContexte = new M2LEntitie();
        }

        /// <summary>
        /// Fonctions permettant de retourner tous les ateliers de la conventions
        /// </summary>
        /// <returns>DataTable contenant la liste des ateliers</returns>
        public DataTable FindAtelier()
        {
            var requete = from ATELIER in M2LContexte.ATELIERs select ATELIER;
            var lesAteliers = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("libelle");
            foreach (var unAtelier in lesAteliers)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = unAtelier.ID;
                toInsert[1] = unAtelier.LIBELLEATELIER;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions permettant de retourner tous les types de qualités d'un licencié
        /// </summary>
        /// <returns>DataTable contenant la liste des qualités</returns>
        public DataTable FindQualite()
        {
            var requete = from QUALITE in M2LContexte.QUALITEs select QUALITE;
            var lesQualites = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("libelle");
            foreach (var uneQualite in lesQualites)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = uneQualite.ID;
                toInsert[1] = uneQualite.LIBELLEQUALITE;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions retournant le nombre de places disponibles par atelier
        /// </summary>
        /// <returns>DataTable contenant la liste des ateliers avec le nombre de places disponibles</returns>
        public DataTable FindNbParAtelier()
        {
            var requete = from VINSCRIT01 in M2LContexte.VINSCRIT01 select VINSCRIT01;
            var lesInscrits = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("nombre");
            table.Columns.Add("libelle");
            foreach (var uneListe in lesInscrits)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = uneListe.ID;
                toInsert[1] = uneListe.NBPLACESDISPO;
                toInsert[2] = uneListe.LIBELLEATELIER;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions permettant de retourner les dates de restauration de la convention
        /// </summary>
        /// <returns>DataTable contenant la liste des restaurations</returns>
        public DataTable FindRestauration()
        {
            var requete = from VRESTAURATION01 in M2LContexte.VRESTAURATION01 select VRESTAURATION01;
            var LesRestaurations = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("libelle");
            foreach (var uneRestauration in LesRestaurations)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = uneRestauration.ID;
                toInsert[1] = uneRestauration.LIBELLE;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions permettant de retourner les hotels disponibles pour les nuités de la convention
        /// </summary>
        /// <returns>DataTable contenant la liste des hotels</returns>
        public DataTable FindHotel()
        {
            var requete = from VHOTEL01 in M2LContexte.VHOTEL01 select VHOTEL01;
            var LesHotels = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("libelle");
            foreach (var unHotel in LesHotels)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = unHotel.ID;
                toInsert[1] = unHotel.LIBELLE;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions permettant de retourner les catégories de chambre des hotels
        /// </summary>
        /// <returns>DataTable contenant la liste des catégories de chambre</returns>
        public DataTable FindCategorie()
        {
            var requete = from VCATEGORIECHAMBRE01 in M2LContexte.VCATEGORIECHAMBRE01 select VCATEGORIECHAMBRE01;
            var LesCategories = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("libelle");
            foreach (var uneCategorie in LesCategories)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = uneCategorie.ID;
                toInsert[1] = uneCategorie.LIBELLE;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions permettant de retourner les dates de nuités de la convention
        /// </summary>
        /// <returns>DataTable contenant la liste des dates de nuités</returns>
        public DataTable FindDateNuitee()
        {
            var requete = from VDATENUITE01 in M2LContexte.VDATENUITE01 select VDATENUITE01;
            var LesNuits = requete.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("libelle");
            foreach (var uneNuit in LesNuits)
            {
                DataRow toInsert = table.NewRow();
                toInsert[0] = uneNuit.ID;
                toInsert[1] = uneNuit.LIBELLE;
                table.Rows.Add(toInsert);
            }
            return table;
        }

        /// <summary>
        /// Fonctions permettant de retourner les dates de nuités de la convention
        /// </summary>
        /// <returns>Collection contenant la liste des dates de nuités</returns>
        public Dictionary<Int16, String> ObtenirDatesNuites()
        {
            Dictionary<Int16, String> LesDatesARetourner = new Dictionary<Int16, String>();
            DataTable LesDatesNuites = this.FindDateNuitee();
            foreach (DataRow UneLigne in LesDatesNuites.Rows)
            {
                LesDatesARetourner.Add(System.Convert.ToInt16(UneLigne["id"]), UneLigne["libelle"].ToString());
            }
            return LesDatesARetourner;
        }

        /// <summary>
        /// Fonctions permettant de retourner une valeur pour l'id d'un nouveau participant (cette fonction fait office de séquence pour la table participant)
        /// </summary>
        /// <returns>Nouvelle id du participant</returns>
        public Int16 NewId()
        {
            var requete = from PARTICIPANT in M2LContexte.PARTICIPANTs select PARTICIPANT;
            var leParticipant = requete.OrderByDescending(c => c.ID).FirstOrDefault();
            if (leParticipant == null) return 1;
            else return leParticipant.ID += 1;
        }

        /// <summary>
        /// Fonctions permettant de retourner une valeur pour l'id d'un nouveau paiement (cette fonction fait office de séquence pour la table paiement)
        /// </summary>
        /// <returns>Nouvelle id du paiement</returns>
        public int NewIdPaiement()
        {
            var requete = from PAIEMENT in M2LContexte.PAIEMENTs select PAIEMENT;
            var lePaiement = requete.OrderByDescending(c => c.ID).FirstOrDefault();
            if (lePaiement == null) return 1;
            else return lePaiement.ID + 1;
        }

        /// <summary>
        /// Procédure pour inscrire un licencié avec repas et/ou nuits d'hotel
        /// </summary>
        /// <param name="pNom">nom du participant</param>
        /// <param name="pPrenom">prénom du participant</param>
        /// <param name="pAdresse1">adresse1 du participant</param>
        /// <param name="pAdresse2">adresse2 du participant</param>
        /// <param name="pCp">cp du participant</param>
        /// <param name="pVille">ville du participant</param>
        /// <param name="pTel">téléphone du participant</param>
        /// <param name="pMail">mail du participant</param>
        /// <param name="pLicence">Numéro de licence du licencié</param>
        /// <param name="pQualité">Qualité du licencié</param>
        /// <param name="pLesAteliers">Liste d'ateliers ou est inscrit le licencié</param>
        /// <param name="pNumCheque">Numéro du chèque</param>
        /// <param name="pMontantChèque">Montant du chèque</param>
        /// <param name="pTypePayement">Type de payement du licencié (tout ou en 2 chèque)</param>
        /// <param name="pListeRepas">Liste des repas pour l'accompagnant du licencié</param>
        /// <param name="pLesCategories">tableau contenant la catégorie de chambre pour chaque nuité à réserver</param>
        /// <param name="pLesHotels">tableau contenant l'hôtel pour chaque nuité à réserver</param>
        /// <param name="pLesNuits">tableau contenant l'id de la date d'arrivée pour chaque nuité à réserver</param>
        /// <param name="pNumCheque2">Numéro de chèque 2</param>
        /// <param name="pMontantChèque2">Montant de chèque 2</param>
        public void InscrireLicencie(String pNom, String pPrenom, String pAdresse1, String pAdresse2, String pCp, String pVille, String pTel, String pMail, Int64? pLicence, Int16 pQualité, Collection<Int16> pLesAteliers, Int16 pNumCheque, Decimal pMontantChèque, String pTypePayement, Collection<Int16> pListeRepas, Collection<string> pLesCategories, Collection<string> pLesHotels, Collection<Int16> pLesNuits, Int16 pNumCheque2 = 0, Decimal pMontantChèque2 = 0)
        {
            String MessageErreur = "";
            try
            {
                short idPaye = Convert.ToInt16(this.NewIdPaiement());
                short id = this.NewId();
                M2LEntitie m2L = new M2LEntitie();
                PARTICIPANT unNouveauParticipant = new PARTICIPANT();
                unNouveauParticipant.NOMPARTICIPANT = pNom;
                unNouveauParticipant.PRENOMPARTICIPANT = pPrenom;
                unNouveauParticipant.ADRESSEPARTICIPANT1 = pAdresse1;
                unNouveauParticipant.ADRESSEPARTICIPANT2 = pAdresse2;
                unNouveauParticipant.CPPARTICIPANT = pCp;
                unNouveauParticipant.VILLEPARTICIPANT = pVille;
                unNouveauParticipant.TELPARTICIPANT = pTel;
                unNouveauParticipant.MAILPARTICIPANT = pMail;
                unNouveauParticipant.DATEINSCRIPTION = DateTime.Now;
                unNouveauParticipant.ID = id;

                LICENCIE unLicencie = new LICENCIE();
                unLicencie.IDQUALITE = Convert.ToByte(pQualité);
                unLicencie.NUMEROLICENCE = Convert.ToInt64(pLicence);
                unLicencie.IDLICENCIE = id;

                foreach (Int16 unAtelier in pLesAteliers)
                {
                    INSCRIRE uneInscription = new INSCRIRE();
                    uneInscription.IDPARTICIPANT = id;
                    uneInscription.IDATELIER = unAtelier;
                    unLicencie.INSCRIREs.Add(uneInscription);
                }

                

                foreach (Int16 unRepas in pListeRepas)
                {
                    var uneRestauration = m2L.RESTAURATIONs.Find(unRepas);
                    unLicencie.RESTAURATIONs.Add(uneRestauration);
                }

                short ordre = 1;
                for (int i = 0; i < pLesCategories.Count; i++)
                {
                    CONTENUHEBERGEMENT hebergement = new CONTENUHEBERGEMENT();
                    hebergement.IDPARTICIPANT = id;
                    hebergement.NUMORDRE = ordre;
                    hebergement.IDCATEGORIE = pLesCategories[i];
                    hebergement.IDDATEARRIVEENUITEE = Convert.ToByte(pLesNuits[i]);
                    hebergement.CODEHOTEL = pLesHotels[i];
                    unNouveauParticipant.CONTENUHEBERGEMENTs.Add(hebergement);
                    ordre++;
                }

                if (pTypePayement == "Tout")
                {
                    PAIEMENT unPaiement = new PAIEMENT();
                    unPaiement.ID = idPaye;
                    unPaiement.IDLICENCIE = id;
                    unPaiement.MONTANTCHEQUE = pMontantChèque;
                    unPaiement.NUMEROCHEQUE = pNumCheque;
                    unPaiement.TYPEPAIEMENT = "Tout";
                    unLicencie.PAIEMENTs.Add(unPaiement);
                }
                else
                {
                    PAIEMENT unPaiement = new PAIEMENT();
                    unPaiement.ID = idPaye;
                    unPaiement.IDLICENCIE = id;
                    unPaiement.MONTANTCHEQUE = pMontantChèque;
                    unPaiement.NUMEROCHEQUE = pNumCheque;
                    unPaiement.TYPEPAIEMENT = "Insc";

                    idPaye++;
                    PAIEMENT unAutrePaiement = new PAIEMENT();
                    unAutrePaiement.ID = idPaye;
                    unAutrePaiement.IDLICENCIE = id;
                    unAutrePaiement.MONTANTCHEQUE = pMontantChèque2;
                    unAutrePaiement.NUMEROCHEQUE = pNumCheque2;
                    unAutrePaiement.TYPEPAIEMENT = "Acco";

                    unLicencie.PAIEMENTs.Add(unPaiement);
                    unLicencie.PAIEMENTs.Add(unAutrePaiement);
                }
                unNouveauParticipant.LICENCIE = unLicencie;
                m2L.PARTICIPANTs.Add(unNouveauParticipant);
                m2L.SaveChanges();
                m2L.Dispose();
            }
            catch (Exception ex)
            {
                MessageErreur = ex.Message;
            }
            finally
            {
                if (MessageErreur.Length > 0)
                {
                    // Déclenchement de l'exception
                    throw new Exception(MessageErreur);
                }
            }
        }

        /// <summary>
        /// Procédure pour détruire l'objet courant Entity Framework
        /// </summary>
        public void FermerConnexion()
        {
            M2LContexte.Dispose();
        }
    }
}
