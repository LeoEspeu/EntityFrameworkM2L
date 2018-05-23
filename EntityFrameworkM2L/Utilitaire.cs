// <copyright file="Utilitaire.cs" company="Maison des Ligues de Lorraine">
// Copyright (c) Maison des Ligues de Lorraine. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EntityFrameworkM2L
{
    /// <summary>
    /// Classe Utilitaire.
    /// </summary>
    public abstract class Utilitaire
    {
        /// <summary>
        /// Méthode permettant de remplir une ComboBox à partir d'une source de données.
        /// </summary>
        /// <param name="UneConnexion">L'objet connexion à utiliser pour la connexion à la BD</param>
        /// <param name="UneCombo"> La ComboBox que l'on doit remplir</param>
        public static void RemplirComboBox(DataTable sourceRemplissage, ComboBox UneCombo)
        {
            UneCombo.DataSource = sourceRemplissage;
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
        /// <param name="unForm">Le formulaire concerné</param> 
        /// <param name="uneConnexion">L'objet connexion à utiliser pour la connexion à la BD</param> 
        /// <param name="pUneTable">Le nom de la source de données qui va fournir les données. Il s'agit en fait d'une vue de type
        /// VXXXXOn ou XXXX représente le nom de la table à partir de laquelle la vue est créée. n représente un numéro de séquence</param>  
        /// <param name="pPrefixe">les noms des contrôles sont standards : NomControle_XX
        ///                                         où XX est l'ID de l'enregistrement récupéré dans la vue qui
        ///                                         sert de source de données</param>
        /// <param name="UnPanel">Panel ou GroupBox dans lequel on va créer les contrôles</param>
        /// <param name="unTypeControle">Type de contrôle à créer : CheckBox ou RadioButton</param>
        public static void CreerDesControles(Form unForm, Bdd uneConnexion, string pUneTable, string pPrefixe, ScrollableControl UnPanel, string unTypeControle)
        {
            DataTable uneTable = new DataTable();
            switch (pUneTable)
            {
                case "restauration":
                    uneTable = uneConnexion.FindRestauration();
                    break;
                default:
                    throw new Exception("Entité Innexistante");
            }

            //// On va récupérer les statuts dans un DataTable puis on va parcourir les lignes (rows) de ce DataTable pour 
            //// construire dynamiquement les boutons radio pour le statut de l'intervenant dans son atelier.
            short i = 0;
            foreach (DataRow uneLigne in uneTable.Rows)
            {
                if (unTypeControle == "CheckBox")
                {
                    MaterialCheckBox UnControle = new MaterialCheckBox();
                    AffecterControle(unForm, UnPanel, UnControle, pPrefixe, uneLigne, i++);
                }
                else if (unTypeControle == "RadioButton")
                {
                    MaterialRadioButton UnControle = new MaterialRadioButton();
                    AffecterControle(unForm, UnPanel, UnControle, pPrefixe, uneLigne, i++);
                }
                i++;
            }

            UnPanel.Height = 20 * i + 5;
        }

        /// <summary>
        /// Cette méthode permet de renseigner les propriétés des contrôles à créer. C'est une partie commune aux 
        /// 3 types de participants : intervenant, licencié, bénévole.
        /// </summary>
        /// <param name="unForm">Le formulaire concerné</param>  
        /// <param name="UnContainer">Le Panel ou leGgroupBox dans lequel on va placer les contrôles</param> 
        /// <param name="UnControleAPlacer">Le contrôle en cours de création</param>
        /// <param name="unPrefixe">Les noms des contrôles sont standards : NomControle_XX
        ///                                         ou XX est l'ID de l'enregistrement récupéré dans la vue qui
        ///                                         sert de source de données</param> 
        /// <param name="uneLigne">Un enregistrement de la vue, celle pour laquelle on crée le contrôle</param> 
        /// <param name="i">Un compteur qui sert à positionner en hauteur le contrôle</param>   
        private static void AffecterControle(Form unForm, ScrollableControl UnContainer, ButtonBase UnControleAPlacer, string unPrefixe, DataRow uneLigne, short i)
        {
            UnControleAPlacer.Name = unPrefixe + uneLigne[0];
            UnControleAPlacer.Width = 320;
            UnControleAPlacer.Text = uneLigne[1].ToString();
            UnControleAPlacer.Left = 13;
            UnControleAPlacer.Top = 5 +(10 * i);
            UnControleAPlacer.Visible = true;                  
            System.Type unType = unForm.GetType();
            UnContainer.Controls.Add(UnControleAPlacer);
        }

        /// <summary>
        /// Fonction qui permet de tester si le réglement de la facture d'inscription pour un licencié est valable.
        /// </summary>
        /// <param name="pMontantCheque1">Montant du chèque 1</param>
        /// <param name="pMontantCheque2">Montant du chèque 2 (facultatif, si payement en 2 chèques, sinon à 0 par défaut)</param>
        /// <param name="pTypePaiement">Type de paiement choisi (1 chèque/2 chèques)</param>
        /// <param name="pListeRepas">Tableau contenant les repas séletionnés pour chaque accompagnant du licencié</param>
        /// <param name="pCategoriesSelectionnees">Tableau contenant la catégorie de chambre pour chaque nuité à réserver</param>
        /// <param name="pHotelsSelectionnes">Tableau contenant l'hôtel pour chaque nuité à réserver</param>
        /// <param name="pNuitsSelectionnees">Tableau contenant l'ID de la date d'arrivée pour chaque nuité à réserver</param>
        /// <returns></returns>
        public static bool EstPayable(string pMontantCheque1, string pMontantCheque2 = "0", string pTypePaiement = "Tout", Collection<short> pListeRepas = null, Collection<string> pCategoriesSelectionnees = null, Collection<string> pHotelsSelectionnes = null, Collection<short> pNuitsSelectionnees = null)
        {
            if (pTypePaiement == "Tout")
            {
                if (pListeRepas == null && pCategoriesSelectionnees == null && pHotelsSelectionnes == null && pNuitsSelectionnees == null)
                {
                    if (!(Convert.ToDecimal(pMontantCheque1) >= 100))
                    {
                        string pBody = String.Empty;
                        pBody = "\nMontant du chèque 1 insuffisant, il manque " + Convert.ToString((100 - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                        FrmPrincipale.ExceptionPayement = new Exception(pBody);
                    }
                    return Convert.ToDecimal(pMontantCheque1) >= 100;
                }
                else
                {
                    decimal pMontantDu = 100;
                    foreach (short uneNuit in pNuitsSelectionnees)
                    {
                        if (pHotelsSelectionnes[pNuitsSelectionnees.IndexOf(uneNuit)] == "IBIS")
                        {
                            if (pCategoriesSelectionnees[pNuitsSelectionnees.IndexOf(uneNuit)] == "S")
                            {
                                pMontantDu += (decimal)61.20;
                            }
                            else
                            {
                                pMontantDu += (decimal)62.20;
                            }
                        }
                        else
                        {
                            if (pCategoriesSelectionnees[pNuitsSelectionnees.IndexOf(uneNuit)] == "S")
                            {
                                pMontantDu += (decimal)112;
                            }
                            else
                            {
                                pMontantDu += (decimal)122;
                            }
                        }
                    }

                    foreach (short unRepas in pListeRepas)
                    {
                        pMontantDu += (decimal)35;
                    }

                    if (!(Convert.ToDecimal(pMontantCheque1) >= pMontantDu))
                    {
                        string pBody = String.Empty;
                        pBody = "\nMontant du chèque 1 insuffisant, il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                        FrmPrincipale.ExceptionPayement = new Exception(pBody);
                    }

                    return Convert.ToDecimal(pMontantCheque1) >= pMontantDu;
                }
            }
            else
            {
                decimal pMontantDu = 100;
                decimal pMontantDuRepas = 0;
                foreach (short uneNuit in pNuitsSelectionnees)
                {
                    if (pHotelsSelectionnes[pNuitsSelectionnees.IndexOf(uneNuit)] == "IBIS")
                    {
                        if (pCategoriesSelectionnees[pNuitsSelectionnees.IndexOf(uneNuit)] == "S")
                        {
                            pMontantDu += (decimal)61.20;
                        }
                        else
                        {
                            pMontantDu += (decimal)62.20;
                        }
                    }
                    else
                    {
                        if (pCategoriesSelectionnees[pNuitsSelectionnees.IndexOf(uneNuit)] == "S")
                        {
                            pMontantDu += (decimal)112;
                        }
                        else
                        {
                            pMontantDu += (decimal)122;
                        }
                    }
                }

                foreach (short unRepas in pListeRepas)
                {
                    pMontantDuRepas += (decimal)35;
                }

                if (!(Convert.ToDecimal(pMontantCheque1) >= pMontantDu && Convert.ToDecimal(pMontantCheque2) >= pMontantDuRepas))
                {
                    string pBody = String.Empty;
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
        public static void ControleAtelier(Collection<short> pAteliersSelectionnes, Bdd uneConnexion)
        {
            string bodyMail = String.Empty;
            DataTable nbInscrits = uneConnexion.FindNbParAtelier();
            Collection<short> atelierASuprimmer = new Collection<short>();
            Collection<short> atelierAAjouter = new Collection<short>();
            string atelierSuppr = String.Empty;
            string atelierAjouté = String.Empty;
            foreach (short id in pAteliersSelectionnes)
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
                foreach (short suppr in atelierASuprimmer)
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
                if (atelierAjouté != String.Empty)
                {
                    bodyMail += "vous êtes reportés sur les/l'atelier(s) " + atelierAjouté;
                }

                bodyMail += "Veuillez nous en excusez.";
                MessageBox.Show(bodyMail);
            }
        }
    }
}