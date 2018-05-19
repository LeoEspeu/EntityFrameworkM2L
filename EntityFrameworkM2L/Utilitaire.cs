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
    internal abstract class Utilitaire
    {
        public static void RemplirComboBox(DataTable SourceRemplissage, ComboBox UneCombo)
        {
            UneCombo.DataSource = SourceRemplissage;
            UneCombo.DisplayMember = "libelle";
            UneCombo.ValueMember = "id";
        }

        public static void RemplirListBox(DataTable SourceRemplissage, ListBox UneList)
        {
            UneList.DataSource = SourceRemplissage;
            UneList.DisplayMember = "libelle";
            UneList.ValueMember = "id";
        }

        public static void CreerDesControles(Form UneForme, bdd UneConnexion, String pUneTable, String pPrefixe, ScrollableControl UnPanel, String unTypeControle)
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
            // on va récupérer les statuts dans un datatable puis on va parcourir les lignes(rows) de ce datatable pour 
            // construire dynamiquement les boutons radio pour le statut de l'intervenant dans son atelier
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
        /// <param name="pMontantCheque2">Montant du chèque 2 (facultatif ,si payement en 2 chèques ,sinon à 0 par défaut)</param>
        /// <param name="pTypePayement">Type de payement choisis (1chèque/2 chèques)</param>
        /// <param name="pListeRepas">tableau contenant les repas séletionnés pour chaque accompagnant du licencié</param>
        /// <param name="pCategoriesSelectionnees">tableau contenant la catégorie de chambre pour chaque nuité à réserver</param>
        /// <param name="pHotelsSelectionnes">tableau contenant l'hôtel pour chaque nuité à réserver</param>
        /// <param name="pNuitsSelectionnes">tableau contenant l'id de la date d'arrivée pour chaque nuité à réserver</param>
        /// <returns></returns>
        public static Boolean EstPayable(String pMontantCheque1, String pMontantCheque2 = "0", String pTypePayement = "Tout", Collection<Int16> pListeRepas = null, Collection<string> pCategoriesSelectionnees = null, Collection<string> pHotelsSelectionnes = null, Collection<Int16> pNuitsSelectionnes = null)
        {
            if (pTypePayement == "Tout")
            {
                if (pListeRepas == null && pCategoriesSelectionnees == null && pHotelsSelectionnes == null && pNuitsSelectionnes == null)
                {
                    if (!(Convert.ToDecimal(pMontantCheque1) >= 100))
                    {
                        String pBody = "";
                        pBody = "\nMontant du chèque 1 insuffisant ,il manque " + Convert.ToString((100 - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                        throw new Exception(pBody);
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
                        String pBody = "";
                        pBody = "\nMontant du chèque 1 insuffisant ,il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                        throw new Exception(pBody);
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
                    String pBody = "";
                    if (!(Convert.ToDecimal(pMontantCheque1) >= pMontantDu)) pBody = "\nMontant du chèque 1 insuffisant ,il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque1)))) + " euros.";
                    if (!(Convert.ToDecimal(pMontantCheque2) >= pMontantDuRepas)) pBody += "\nMontant du chèque 2 insuffisant ,il manque " + Convert.ToString((pMontantDu - (Convert.ToDecimal(pMontantCheque2)))) + " euros.";
                    throw new Exception(pBody);
                }
                return Convert.ToDecimal(pMontantCheque1) >= pMontantDu && Convert.ToDecimal(pMontantCheque2) >= pMontantDuRepas;
            }
        }
    }
}
