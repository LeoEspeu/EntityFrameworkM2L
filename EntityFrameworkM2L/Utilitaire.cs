using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using MaterialSkin;
using MaterialSkin.Controls;


namespace EntityFrameworkM2L
{
    public abstract class Utilitaire
    {
        /// <summary>
        /// Méthode permettant de remplir une ComboBox à partir d'une source de données.
        /// </summary>
        /// <param name="UneConnexion">L'objet connexion à utiliser pour la connexion à la BD</param>
        /// <param name="UneCombo"> La ComboBox que l'on doit remplir</param>
        /// <param name="UneSource">Le nom de la source de données qui va fournir les données. Il s'agit en fait d'une vue de type
        /// VXXXXOn ou XXXX représente le nom de la table à partir de laquelle la vue est créée. n représente un numéro de séquence</param>
        public static void RemplirComboBox(DataTable SourceRemplissage, ComboBox UneCombo)
        {
            UneCombo.DataSource = SourceRemplissage;
            UneCombo.DisplayMember = "libelle";
            UneCombo.ValueMember = "id";
        }

        /// <summary>
        /// Méthode permettant de remplir une ListBox à partir d'une source de données.
        /// </summary>
        /// <param name="UneConnexion"></param>
        /// <param name="UneList"></param>
        /// <param name="UneSource"></param>
        public static void RemplirListBox(DataTable SourceRemplissage, ListBox UneList)
        {
            UneList.DataSource = SourceRemplissage;
            UneList.DisplayMember = "libelle";
            UneList.ValueMember = "id";
        }

        /// <summary>
        /// Cette méthode crée des contrôles de type CheckBox ou RadioButton dans un contrôle de type Panel.
        /// Elle va chercher les données dans la base de données et crée autant de contrôles (les uns en-dessous des autres)
        /// qu'il y a de lignes renvoyées par la base de données.
        /// </summary>
        /// <param name="UneForme">Le formulaire concerné</param> 
        /// <param name="UneConnexion">L'objet connexion à utiliser pour la connexion à la BD</param> 
        /// <param name="pUneTable">Le nom de la source de données qui va fournir les données. Il s'agit en fait d'une vue de type
        /// VXXXXOn ou XXXX représente le nom de la table à partir de laquelle la vue est créée. n représente un numéro de séquence</param>  
        /// <param name="pPrefixe">les noms des contrôles sont standards : NomControle_XX
        ///                                         où XX est l'ID de l'enregistrement récupéré dans la vue qui
        ///                                         sert de source de données</param>
        /// <param name="UnPanel">Panel ou GroupBox dans lequel on va créer les contrôles</param>
        /// <param name="unTypeControle">Type de contrôle à créer : CheckBox ou RadioButton</param>
        public static void CreerDesControles(Form UneForme, Bdd UneConnexion, String pUneTable, String pPrefixe, ScrollableControl UnPanel, String unTypeControle)
        {
            DataTable UneTable = new DataTable();
            switch (pUneTable)
            {
                case "restauration":
                    UneTable = UneConnexion.FindRestauration();
                    break;
                default:
                    throw new Exception("Entité Innexistante");
            }
            //// On va récupérer les statuts dans un DataTable puis on va parcourir les lignes (rows) de ce DataTable pour 
            //// construire dynamiquement les boutons radio pour le statut de l'intervenant dans son atelier.
            Int16 i = 0;
            foreach (DataRow UneLigne in UneTable.Rows)
            {
                if (unTypeControle == "CheckBox")
                {
                    MaterialCheckBox UnControle = new MaterialCheckBox();
                    AffecterControle(UneForme, UnPanel, UnControle, pPrefixe, UneLigne, i++);
                }
                else if (unTypeControle == "RadioButton")
                {
                    MaterialRadioButton UnControle = new MaterialRadioButton();
                    AffecterControle(UneForme, UnPanel, UnControle, pPrefixe, UneLigne, i++);
                }
                i++;
            }
            UnPanel.Height = 20 * i + 5;
        }

        /// <summary>
        /// Cette méthode permet de renseigner les propriétés des contrôles à créer. C'est une partie commune aux 
        /// 3 types de participants : intervenant, licencié, bénévole.
        /// </summary>
        /// <param name="UneForme">Le formulaire concerné</param>  
        /// <param name="UnContainer">Le Panel ou leGgroupBox dans lequel on va placer les contrôles</param> 
        /// <param name="UnControleAPlacer">Le contrôle en cours de création</param>
        /// <param name="UnPrefixe">Les noms des contrôles sont standards : NomControle_XX
        ///                                         ou XX est l'ID de l'enregistrement récupéré dans la vue qui
        ///                                         sert de source de données</param> 
        /// <param name="UneLigne">Un enregistrement de la vue, celle pour laquelle on crée le contrôle</param> 
        /// <param name="i">Un compteur qui sert à positionner en hauteur le contrôle</param>   
        private static void AffecterControle(Form UneForme, ScrollableControl UnContainer, ButtonBase UnControleAPlacer, String UnPrefixe, DataRow UneLigne, Int16 i)
        {
            UnControleAPlacer.Name = UnPrefixe + UneLigne[0];
            UnControleAPlacer.Width = 320;
            UnControleAPlacer.Text = UneLigne[1].ToString();
            UnControleAPlacer.Left = 13;
            UnControleAPlacer.Top = 5 +(10 * i);
            UnControleAPlacer.Visible = true;                  
            System.Type UnType = UneForme.GetType();
            UnContainer.Controls.Add(UnControleAPlacer);
        }

        /// <summary>
        /// Fonction qui permet de tester si le réglement de la facture d'inscription pour un licencié est valable.
        /// </summary>
        /// <param name="pMontantCheque1">Montant du chèque 1</param>
        /// <param name="pMontantCheque2">Montant du chèque 2 (facultatif, si payement en 2 chèques, sinon à 0 par défaut)</param>
        /// <param name="pTypePayement">Type de paiement choisi (1 chèque/2 chèques)</param>
        /// <param name="pListeRepas">Tableau contenant les repas séletionnés pour chaque accompagnant du licencié</param>
        /// <param name="pCategoriesSelectionnees">Tableau contenant la catégorie de chambre pour chaque nuité à réserver</param>
        /// <param name="pHotelsSelectionnes">Tableau contenant l'hôtel pour chaque nuité à réserver</param>
        /// <param name="pNuitsSelectionnes">Tableau contenant l'ID de la date d'arrivée pour chaque nuité à réserver</param>
        /// <returns></returns>
        public static Boolean EstPayable(String pMontantCheque1, String pMontantCheque2 = "0", String pTypePayement = "Tout", Collection<Int16> pListeRepas = null, Collection<string> pCategoriesSelectionnees = null, Collection<string> pHotelsSelectionnes = null, Collection<Int16> pNuitsSelectionnes = null)
        {
            if (pTypePayement == "Tout")
            {
                if (pListeRepas == null && pCategoriesSelectionnees == null && pHotelsSelectionnes == null && pNuitsSelectionnes == null)
                {
                    if (!(Convert.ToDecimal(pMontantCheque1) >= 100))
                    {
                        String pBody = String.Empty;
                        pBody = "\nMontant du chèque 1 insuffisant, il manque " + Convert.ToString((100 - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                        FrmPrincipale.ExceptionPayement = new Exception(pBody);
                    }
                    return Convert.ToDecimal(pMontantCheque1) >= 100;
                }
                else
                {
                    Decimal pMontantDu = 100;
                    foreach (Int16 uneNuit in pNuitsSelectionnes)
                    {
                        if (pHotelsSelectionnes[pNuitsSelectionnes.IndexOf(uneNuit)] == "IBIS")
                        {
                            if (pCategoriesSelectionnees[pNuitsSelectionnes.IndexOf(uneNuit)] == "S")
                            {
                                pMontantDu += (Decimal)61.20;
                            }
                            else
                            {
                                pMontantDu += (Decimal)62.20;
                            }
                        }
                        else
                        {
                            if (pCategoriesSelectionnees[pNuitsSelectionnes.IndexOf(uneNuit)] == "S")
                            {
                                pMontantDu += (Decimal)112;
                            }
                            else
                            {
                                pMontantDu += (Decimal)122;
                            }
                        }
                    }
                    foreach (Int16 unRepas in pListeRepas)
                    {
                        pMontantDu += (Decimal)35;
                    }
                    if (!(Convert.ToDecimal(pMontantCheque1) >= pMontantDu))
                    {
                        String pBody = String.Empty;
                        pBody = "\nMontant du chèque 1 insuffisant, il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                        FrmPrincipale.ExceptionPayement = new Exception(pBody);
                    }
                    return Convert.ToDecimal(pMontantCheque1) >= pMontantDu;
                }
            }
            else
            {
                Decimal pMontantDu = 100;
                Decimal pMontantDuRepas = 0;
                foreach (Int16 uneNuit in pNuitsSelectionnes)
                {
                    if (pHotelsSelectionnes[pNuitsSelectionnes.IndexOf(uneNuit)] == "IBIS")
                    {
                        if (pCategoriesSelectionnees[pNuitsSelectionnes.IndexOf(uneNuit)] == "S")
                        {
                            pMontantDu += (Decimal)61.20;
                        }
                        else
                        {
                            pMontantDu += (Decimal)62.20;
                        }
                    }
                    else
                    {
                        if (pCategoriesSelectionnees[pNuitsSelectionnes.IndexOf(uneNuit)] == "S")
                        {
                            pMontantDu += (Decimal)112;
                        }
                        else
                        {
                            pMontantDu += (Decimal)122;
                        }
                    }
                }
                foreach (Int16 unRepas in pListeRepas)
                {
                    pMontantDuRepas += (Decimal)35;
                }
                if (!(Convert.ToDecimal(pMontantCheque1) >= pMontantDu && Convert.ToDecimal(pMontantCheque2) >= pMontantDuRepas))
                {
                    String pBody = String.Empty;
                    if (!(Convert.ToDecimal(pMontantCheque1) >= pMontantDu)) pBody = "\nMontant du chèque 1 insuffisant, il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                    if (!(Convert.ToDecimal(pMontantCheque2) >= pMontantDuRepas)) pBody += "\nMontant du chèque 2 insuffisant, il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque2)))) + " euros.";
                    FrmPrincipale.ExceptionPayement = new Exception(pBody);
                }
                return Convert.ToDecimal(pMontantCheque1) >= pMontantDu && Convert.ToDecimal(pMontantCheque2) >= pMontantDuRepas;
            }
        }

        /// <summary>
        /// Procédure qui modifie la liste des ateliers choisis par le participant en fonction des places disponibles par atelier.
        /// </summary>
        /// <param name="pAteliersSelectionnes">Les ateliers sélectionés par le participant</param>
        public static void ControleAtelier(Collection<Int16> pAteliersSelectionnes, Bdd uneConnexion)
        {
            String bodyMail = String.Empty;
            DataTable nbInscrits = uneConnexion.FindNbParAtelier();
            Collection<Int16> atelierASuprimmer = new Collection<Int16>();
            Collection<Int16> atelierAAjouter = new Collection<Int16>();
            String atelierSuppr = String.Empty;
            String atelierAjouté = String.Empty;
            foreach (Int16 id in pAteliersSelectionnes)
            {
                foreach (DataRow atelier in nbInscrits.Rows)
                {
                    if (Convert.ToInt16(atelier[0]) == id && !(Convert.ToInt16(atelier[1]) > 0))
                    {
                        atelierASuprimmer.Add(id);
                        atelierSuppr += " " + atelier[2] + ";";
                    }
                }
            }
            if (atelierASuprimmer.Count > 0)
            {
                foreach (Int16 suppr in atelierASuprimmer)
                {
                    pAteliersSelectionnes.RemoveAt(pAteliersSelectionnes.IndexOf(suppr));
                }
                int compteur = atelierASuprimmer.Count;
                foreach (DataRow atelier in nbInscrits.Rows)
                {
                    if (compteur > 0 && Convert.ToInt16(atelier[1]) > 0 && !pAteliersSelectionnes.Contains(Convert.ToInt16(atelier[0])))
                    {
                        pAteliersSelectionnes.Add(Convert.ToInt16(atelier[0]));
                        compteur -= 1;
                        atelierAjouté += " " + atelier[2] + ";";
                    }
                }
                bodyMail = "Malheuresement pour cause de surréservation, nous ne pouvons vous inscrire pour les/l'atelier(s) " + atelierSuppr;
                if (atelierAjouté != String.Empty) bodyMail += "vous êtes reportés sur les/l'atelier(s) " + atelierAjouté;
                bodyMail += "Veuillez nous en excusez.";
                MessageBox.Show(bodyMail);
            }
        }
    }
}