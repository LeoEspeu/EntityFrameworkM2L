using System;
using System.Collections.Generic;
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
            Utilitaire.RemplirComboBox(lesQualites, this.CmbQualiteLicenciee,"qualite");
            Utilitaire.RemplirListBox(lesAteliers, this.LsbAtelierLicencie, "atelier");
            Utilitaire.CreerDesControles(this, UneConnexion, "restauration", "ChkRepasL_", PanRepasLicencie, "CheckBox");
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l'application ?","Maison des ligues", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
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
    }
}
