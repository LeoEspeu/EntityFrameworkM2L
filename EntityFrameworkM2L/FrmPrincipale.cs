// <copyright file="FrmPrincipale.cs" company="Maison des Ligues de Lorraine">
// Copyright (c) Maison des Ligues de Lorraine. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using ComposantNuite;

namespace EntityFrameworkM2L
{
    /// <summary>
    /// Classe FrmPrincipale.
    /// </summary>
    public partial class FrmPrincipale : MaterialForm
    {
        private Bdd uneConnexion;
        public static Exception ExceptionPayement;

        /// <summary>
        /// On crée le formulaire d'inscription et on remplie les objets graphiques.
        /// </summary>
        public FrmPrincipale()
        {
            InitializeComponent();

            //// Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //// Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

            //// On récupére les données de la Bdd, nécessaire pour effectuer le remplissage des objets graphiques.
            uneConnexion = new Bdd();
            var lesAteliers = uneConnexion.FindAtelier();
            var lesQualites = uneConnexion.FindQualite();
            Utilitaire.RemplirComboBox(lesQualites, this.CmbQualiteLicenciee);
            Utilitaire.RemplirListBox(lesAteliers, this.LsbAtelierLicencie);
            Utilitaire.CreerDesControles(this, uneConnexion, "restauration", "ChkRepasL_", PanRepasLicencie, "CheckBox");
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l'application ?", "Maison des ligues", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
                uneConnexion.FermerConnexion();
            }
        }

        /// <summary>
        /// Procédure qui gère la visibilité des contrôles du panel de choix de repas pour accompagnant de licencié.
        /// </summary>
        /// <param name="sender">Premier paramètre par défaut.</param>
        /// <param name="e">Deuxième paramètre par défaut.</param>
        private void RdbRepasLicencie_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Name == "RdbAccompagnantLicencieOui")
            {
                PanRepasLicencie.Visible = true;
                TxtMontantCheque2.Enabled = true;
                TxtNumeroCheque2.Enabled = true;
            }
            else
            {
                PanRepasLicencie.Visible = false;
                TxtMontantCheque2.Enabled = false;
                TxtNumeroCheque2.Enabled = false;
            }
        }

        /// <summary>
        /// Méthode qui permet d'afficher ou masquer le contrôle Panel permettant la saisie des nuités d'un licencié.
        /// S'il faut rendre visible le Panel, on teste si les nuitées possibles ont été chargées dans ce Panel. Si non, on les charge. 
        /// On charge ici autant de contrôles ResaNuit qu'il y a de nuits possibles.
        /// </summary>
        /// <param name="sender">Premier paramètre par défaut.</param>
        /// <param name="e">Deuxième paramètre par défaut.</param>
        private void RdbNuiteLicencie_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Name == "RdbNuiteLicencieOui")
            {
                PanNuiteeLicencie.Visible = true;
                if (PanNuiteeLicencie.Controls.Count == 0)
                {
                    Dictionary<Int16, String> lesNuitees = uneConnexion.ObtenirDatesNuites();
                    int i = 0;
                    foreach (KeyValuePair<Int16, String> uneNuitee in lesNuitees)
                    {
                        ComposantNuite.ResaNuite unResaNuit = new ResaNuite(uneConnexion.FindHotel(), uneConnexion.FindCategorie(), uneNuitee.Value, uneNuitee.Key);
                        unResaNuit.Left = 5;
                        unResaNuit.Top = 5 + (24 * i++);
                        unResaNuit.Visible = true;
                        PanNuiteeLicencie.Controls.Add(unResaNuit);
                    }
                }
            }
            else
            {
                PanNuiteeLicencie.Visible = false;
            }
        }

        /// <summary>
        /// Permet d'intercepter le click sur le bouton d'enregistrement d'un licencié.
        /// Cette méthode va appeler la méthode InscrireLicencie de la Bdd, après avoir mis en forme certains paramètres à envoyer.
        /// </summary>
        /// <param name="sender">Premier paramètre par défaut.</param>
        /// <param name="e">Deuxième paramètre par défaut.</param>
        private void BtnEnregistrerLicencie_Click(object sender, EventArgs e)
        {

            //// On récolte les ateliers selectionnés.
            Collection<short> ateliersSelectionnes = new Collection<short>();
            Collection<ListBox.SelectedObjectCollection> atelier = new Collection<ListBox.SelectedObjectCollection>();
            string typePaiement = "Tout";
            short nCheque2 = 0;
            decimal mCheque2 = 0;
            try
            {
                foreach (DataRowView unAtelier in LsbAtelierLicencie.SelectedItems)
                {
                    ateliersSelectionnes.Add(Convert.ToInt16(unAtelier.Row.ItemArray[0]));
                }
                if (ateliersSelectionnes.Count == 0) throw new Exception("Vous devez sélectionner au moins un atelier.");
                Utilitaire.ControleAtelier(ateliersSelectionnes, uneConnexion);
                long? numeroLicence;
                if (MskLicenceLicencie.MaskCompleted)
                {
                    numeroLicence = System.Convert.ToInt64(MskLicenceLicencie.Text);
                }
                else
                {
                    throw new Exception("Licence non complétée");
                }
                Collection<short> repasSelectionnes = new Collection<short>();
                Collection<short> nuitsSelectionnees = new Collection<short>();
                Collection<string> hotelsSelectionnes = new Collection<string>();
                Collection<string> categoriesSelectionnees = new Collection<string>();

                if (RdbNuiteLicencieOui.Checked)
                {
                    foreach (Control UnControl in PanNuiteeLicencie.Controls)
                    {
                        if (UnControl.GetType().Name == "ResaNuite" && ((ResaNuite)UnControl).GetNuitSelectionnee())
                        {
                            categoriesSelectionnees.Add(((ResaNuite)UnControl).GetTypeChambreSelectionnee());
                            hotelsSelectionnes.Add(((ResaNuite)UnControl).GetHotelSelectionne());
                            nuitsSelectionnees.Add(((ResaNuite)UnControl).IdNuite);
                        }
                    }
                }

                if (nuitsSelectionnees.Count == 0 && RdbNuiteLicencieOui.Checked)
                {
                    throw new Exception("Si vous avez sélectionné que l'accompagnant avait des nuitées,\n il faut qu'au moins une nuit soit sélectionnée.");
                }

                if (RdbAccompagnantLicencieOui.Checked)
                {
                    foreach (Control UnControl in PanRepasLicencie.Controls)
                    {
                        if (UnControl.GetType().Name == "MaterialCheckBox" && ((CheckBox)UnControl).Checked)
                        {
                            repasSelectionnes.Add(System.Convert.ToInt16((UnControl.Name.Split('_'))[1]));
                        }
                    }
                }

                if (repasSelectionnes.Count == 0 && RdbAccompagnantLicencieOui.Checked)
                {
                    throw new Exception("Si vous avez sélectionné que l'accompagnant avait des repas\n il faut qu'au moins un repas soit sélectionné.");
                }

                if (TxtMontantCheque2.Text != String.Empty && TxtNumeroCheque2.Text != String.Empty && repasSelectionnes.Count() != 0)
                {
                    nCheque2 = Convert.ToInt16(TxtNumeroCheque2.Text);
                    mCheque2 = Convert.ToDecimal(TxtMontantCheque2.Text);
                    typePaiement = "Insc";
                }

                if (repasSelectionnes.Count != 0 && nCheque2 !=0)
                {
                    if (Utilitaire.EstPayable(TxtMontantCheque.Text, TxtMontantCheque2.Text, typePaiement, repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees)) uneConnexion.InscrireLicencie(TxtNom.Text, TxtPrenom.Text, TxtAdr1.Text, TxtAdr2.Text != "" ? TxtAdr2.Text : null, TxtCp.Text, TxtVille.Text, txtTel.MaskCompleted ? txtTel.Text : null, TxtMail.Text != "" ? TxtMail.Text : null, numeroLicence, Convert.ToInt16(CmbQualiteLicenciee.SelectedValue), ateliersSelectionnes, Convert.ToInt16(TxtNumeroCheque.Text), Convert.ToDecimal(TxtMontantCheque.Text), typePaiement, repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees, nCheque2, mCheque2);
                    else throw ExceptionPayement;
                    MessageBox.Show("Inscription licencié terminée");
                }
                else
                {
                    if (Utilitaire.EstPayable(TxtMontantCheque.Text, "0", typePaiement, repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees))uneConnexion.InscrireLicencie(TxtNom.Text, TxtPrenom.Text, TxtAdr1.Text, TxtAdr2.Text != "" ? TxtAdr2.Text : null, TxtCp.Text, TxtVille.Text, txtTel.MaskCompleted ? txtTel.Text : null, TxtMail.Text != "" ? TxtMail.Text : null, numeroLicence, Convert.ToInt16(CmbQualiteLicenciee.SelectedValue), ateliersSelectionnes, Convert.ToInt16(TxtNumeroCheque.Text), Convert.ToDecimal(TxtMontantCheque.Text), typePaiement, repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees);
                    else throw ExceptionPayement;
                    MessageBox.Show("Inscription licencié terminée");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}