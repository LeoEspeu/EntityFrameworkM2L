using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Reflection;


namespace EntityFrameworkM2L
{
    internal abstract class Utilitaire
    {
        public static void RemplirComboBox(Object SourceRemplissage, ComboBox UneCombo)
        {
            UneCombo.DataSource = SourceRemplissage;
            UneCombo.DisplayMember = "libellequalite";
            UneCombo.ValueMember = "id";
        }
    }
}
