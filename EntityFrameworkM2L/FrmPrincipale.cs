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
    public partial class FrmPrincipale : MaterialForm
    {
        private bdd UneConnexion;
        public static Exception ExceptionPayement;

        /// <summary>
        /// On crée le formulaire d'inscription et on remplie les objets graphiques
        /// </summary>
        public FrmPrincipale()
        {
            InitializeComponent();

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

            //On récupére les données de la bdd pour ,nécessaire pour effectuer le remplissage des objets graphiques
            UneConnexion = new bdd();
            var lesAteliers = UneConnexion.FindAtelier();
            var lesQualites = UneConnexion.FindQualite();
            Utilitaire.RemplirComboBox(lesQualites, this.CmbQualiteLicenciee);
            Utilitaire.RemplirListBox(lesAteliers, this.LsbAtelierLicencie);
            Utilitaire.CreerDesControles(this, UneConnexion, "restauration", "ChkRepasL_", PanRepasLicencie, "CheckBox");
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l'application ?","Maison des ligues", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
                UneConnexion.FermerConnexion();
            }
        }

        /// <summary>
        /// Procédure qui gére la visibilité des contrôles du panel de choix de repas pour accompagnant de licencié 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Méthode qui permet d'afficher ou masquer le controle panel permettant la saisie des nuités d'un licencié.
        /// S'il faut rendre visible le panel, on teste si les nuités possibles ont été chargés dans ce panel. Si non, on les charges 
        /// On charge ici autant de contrôles ResaNuit qu'il y a de nuits possibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdbNuiteLicencie_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Name == "RdbNuiteLicencieOui")
            {
                PanNuiteLicencie.Visible = true;
                if (PanNuiteLicencie.Controls.Count == 0)
                {
                    Dictionary<Int16, String> LesNuites = UneConnexion.ObtenirDatesNuites();
                    int i = 0;
                    foreach (KeyValuePair<Int16, String> UneNuite in LesNuites)
                    {
                        ComposantNuite.ResaNuite unResaNuit = new ResaNuite(UneConnexion.FindHotel(), (UneConnexion.FindCategorie()), UneNuite.Value, UneNuite.Key);
                        unResaNuit.Left = 5;
                        unResaNuit.Top = 5 + (24 * i++);
                        unResaNuit.Visible = true;
                        PanNuiteLicencie.Controls.Add(unResaNuit);
                    }
                }
            }
            else
            {
                PanNuiteLicencie.Visible = false;
            }
        }

        /// <summary>
        /// Permet d'intercepter le click sur le bouton d'enregistrement d'un licencié.
        /// Cetteméthode va appeler la méthode InscrireLicencié de la Bdd, après avoir mis en forme certains paramètres à envoyer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnregistrerLicencie_Click(object sender, EventArgs e)
        {

            //On recolte les atelier selectionnés
            Collection<Int16> AteliersSelectionnes = new Collection<Int16>();
            Collection<ListBox.SelectedObjectCollection> Atelier = new Collection<ListBox.SelectedObjectCollection>();
            String TypePayement = "Tout";
            Int16 Ncheque2 = 0;
            Decimal Mcheque2 = 0;
            try
            {
                foreach (DataRowView unAtelier in LsbAtelierLicencie.SelectedItems)
                {
                    AteliersSelectionnes.Add(Convert.ToInt16(unAtelier.Row.ItemArray[0]));
                }
                if (AteliersSelectionnes.Count == 0) throw new Exception("Vous devez sélectionner au moins un atelier");
                Utilitaire.controleAtelier(AteliersSelectionnes,UneConnexion);
                Int64? NumeroLicence;
                if (MskLicenceLicencie.MaskCompleted)
                {
                    NumeroLicence = System.Convert.ToInt64(MskLicenceLicencie.Text);
                }
                else
                {
                    throw new Exception("Licence non complété");
                }
                Collection<Int16> RepasSelectionnes = new Collection<Int16>();
                Collection<Int16> NuitsSelectionnes = new Collection<Int16>();
                Collection<String> HotelsSelectionnes = new Collection<string>();
                Collection<String> CategoriesSelectionnees = new Collection<string>();

                if (RdbNuiteLicencieOui.Checked)
                {
                    foreach (Control UnControle in PanNuiteLicencie.Controls)
                    {
                        if (UnControle.GetType().Name == "ResaNuite" && ((ResaNuite)UnControle).GetNuitSelectionnee())
                        {
                            CategoriesSelectionnees.Add(((ResaNuite)UnControle).GetTypeChambreSelectionnee());
                            HotelsSelectionnes.Add(((ResaNuite)UnControle).GetHotelSelectionne());
                            NuitsSelectionnes.Add(((ResaNuite)UnControle).IdNuite);
                        }
                    }
                }
                if (NuitsSelectionnes.Count == 0 && RdbNuiteLicencieOui.Checked)
                {
                    throw new Exception("Si vous avez sélectionné que l'accompagnant avait des nuitées,\n il faut qu'au moins une nuit soit sélectionnée");
                }

                if (RdbAccompagnantLicencieOui.Checked)
                {
                    foreach (Control UnControle in PanRepasLicencie.Controls)
                    {
                        if (UnControle.GetType().Name == "MaterialCheckBox" && ((CheckBox)UnControle).Checked)
                        {
                            RepasSelectionnes.Add(System.Convert.ToInt16((UnControle.Name.Split('_'))[1]));
                        }
                    }
                }
               if (RepasSelectionnes.Count == 0 && RdbAccompagnantLicencieOui.Checked)
                {
                    throw new Exception("Si vous avez sélectionné que l'accompagnant avait des repas\n il faut qu'au moins un repas soit sélectionnée");
                }
                if (TxtMontantCheque2.Text != "" && TxtNumeroCheque2.Text != "" && RepasSelectionnes.Count() != 0)
                {
                    Ncheque2 = Convert.ToInt16(TxtNumeroCheque2.Text);
                    Mcheque2 = Convert.ToDecimal(TxtMontantCheque2.Text);
                    TypePayement = "Insc";
                }
                if (RepasSelectionnes.Count != 0 && Ncheque2 !=0)
                {
                    if (Utilitaire.EstPayable(TxtMontantCheque.Text, TxtMontantCheque2.Text, TypePayement, RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes)) UneConnexion.InscrireLicencie(TxtNom.Text, TxtPrenom.Text, TxtAdr1.Text, TxtAdr2.Text != "" ? TxtAdr2.Text : null, TxtCp.Text, TxtVille.Text, txtTel.MaskCompleted ? txtTel.Text : null, TxtMail.Text != "" ? TxtMail.Text : null, NumeroLicence, Convert.ToInt16(CmbQualiteLicenciee.SelectedValue), AteliersSelectionnes, Convert.ToInt16(TxtNumeroCheque.Text), Convert.ToDecimal(TxtMontantCheque.Text), TypePayement, RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes, Ncheque2, Mcheque2);
                    else throw ExceptionPayement;
                    MessageBox.Show("Inscription licencié terminée");
                }
                else
                {
                    if (Utilitaire.EstPayable(TxtMontantCheque.Text,"0", TypePayement, RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes))UneConnexion.InscrireLicencie(TxtNom.Text, TxtPrenom.Text, TxtAdr1.Text, TxtAdr2.Text != "" ? TxtAdr2.Text : null, TxtCp.Text, TxtVille.Text, txtTel.MaskCompleted ? txtTel.Text : null, TxtMail.Text != "" ? TxtMail.Text : null, NumeroLicence, Convert.ToInt16(CmbQualiteLicenciee.SelectedValue), AteliersSelectionnes, Convert.ToInt16(TxtNumeroCheque.Text), Convert.ToDecimal(TxtMontantCheque.Text), TypePayement, RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes);
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
