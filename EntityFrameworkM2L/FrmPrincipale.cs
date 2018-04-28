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
            Utilitaire.RemplirComboBox(lesQualites, this.CmbQualiteLicenciee);

            //On remplit les Objets graphiques (listbox,combobox) avec les données de la bdd
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l'application ?","Maison des ligues", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
