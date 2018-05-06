using System;
using System.Collections.Generic;
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
    }
}
