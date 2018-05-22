using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.ObjectModel;

namespace EntityFrameworkM2L.Tests
{
    [TestClass()]
    public class UtilitaireTests
    {
        
        [TestMethod()]
        public void EstPasPayableToutTest()
        {
            Collection<Int16> repasSelectionnes = new Collection<Int16>();
            Collection<Int16> nuitsSelectionnees = new Collection<Int16>();
            Collection<String> hotelsSelectionnes = new Collection<string>();
            Collection<String> categoriesSelectionnees = new Collection<string>();
            hotelsSelectionnes.Add("IBIS");
            hotelsSelectionnes.Add("NOVO");
            categoriesSelectionnees.Add("S");
            categoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                repasSelectionnes.Add(i);
                if (i < 3)
                {
                    nuitsSelectionnees.Add(i);
                }
            }
            Assert.AreEqual(false, Utilitaire.EstPayable("200", "500", "Tout", repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees), "Montant insuffisant");
        }

        [TestMethod()]
        public void EstPasPayableTest()
        {
            Collection<Int16> repasSelectionnes = new Collection<Int16>();
            Collection<Int16> nuitsSelectionnees = new Collection<Int16>();
            Collection<String> hotelsSelectionnes = new Collection<string>();
            Collection<String> categoriesSelectionnees = new Collection<string>();
            hotelsSelectionnes.Add("IBIS");
            hotelsSelectionnes.Add("NOVO");
            categoriesSelectionnees.Add("S");
            categoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                repasSelectionnes.Add(i);
                if (i < 3)
                {
                    nuitsSelectionnees.Add(i);
                }
            }
            Assert.AreEqual(false, Utilitaire.EstPayable("100", "500", "Insc", repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees), "Montant insuffisant");
        }

        [TestMethod()]
        public void EstPayableTest()
        {
            Collection<Int16> repasSelectionnes = new Collection<Int16>();
            Collection<Int16> nuitsSelectionnees = new Collection<Int16>();
            Collection<String> hotelsSelectionnes = new Collection<string>();
            Collection<String> categoriesSelectionnees = new Collection<string>();
            hotelsSelectionnes.Add("IBIS");
            hotelsSelectionnes.Add("NOVO");
            categoriesSelectionnees.Add("S");
            categoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                repasSelectionnes.Add(i);
                if (i < 3)
                {
                    nuitsSelectionnees.Add(i);
                }
            }
            Assert.AreEqual(true, Utilitaire.EstPayable("400", "500", "Insc", repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees), "Montant insuffisant");
        }

        [TestMethod()]
        public void EstPayableToutTest()
        {
            Collection<Int16> repasSelectionnes = new Collection<Int16>();
            Collection<Int16> nuitsSelectionnees = new Collection<Int16>();
            Collection<String> hotelsSelectionnes = new Collection<string>();
            Collection<String> categoriesSelectionnees = new Collection<string>();
            hotelsSelectionnes.Add("IBIS");
            hotelsSelectionnes.Add("NOVO");
            categoriesSelectionnees.Add("S");
            categoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                repasSelectionnes.Add(i);
                if (i < 3)
                {
                    nuitsSelectionnees.Add(i);
                }
            }
            Assert.AreEqual(true, Utilitaire.EstPayable("400", "500", "Tout", repasSelectionnes, categoriesSelectionnees, hotelsSelectionnes, nuitsSelectionnees), "Montant insuffisant");
        }
    }
}