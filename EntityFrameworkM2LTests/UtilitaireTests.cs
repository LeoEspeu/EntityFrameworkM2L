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
            Collection<Int16> RepasSelectionnes = new Collection<Int16>();
            Collection<Int16> NuitsSelectionnes = new Collection<Int16>();
            Collection<String> HotelsSelectionnes = new Collection<string>();
            Collection<String> CategoriesSelectionnees = new Collection<string>();
            HotelsSelectionnes.Add("IBIS");
            HotelsSelectionnes.Add("NOVO");
            CategoriesSelectionnees.Add("S");
            CategoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                RepasSelectionnes.Add(i);
                if (i < 3)
                {
                    NuitsSelectionnes.Add(i);
                }
            }
            Assert.AreEqual(false, Utilitaire.EstPayable("200", "500", "Tout", RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes), "Montant insuffisant");
        }

        [TestMethod()]
        public void EstPasPayableTest()
        {
            Collection<Int16> RepasSelectionnes = new Collection<Int16>();
            Collection<Int16> NuitsSelectionnes = new Collection<Int16>();
            Collection<String> HotelsSelectionnes = new Collection<string>();
            Collection<String> CategoriesSelectionnees = new Collection<string>();
            HotelsSelectionnes.Add("IBIS");
            HotelsSelectionnes.Add("NOVO");
            CategoriesSelectionnees.Add("S");
            CategoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                RepasSelectionnes.Add(i);
                if (i < 3)
                {
                    NuitsSelectionnes.Add(i);
                }
            }
            Assert.AreEqual(false, Utilitaire.EstPayable("100", "500", "Insc", RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes), "Montant insuffisant");
        }

        [TestMethod()]
        public void EstPayableTest()
        {
            Collection<Int16> RepasSelectionnes = new Collection<Int16>();
            Collection<Int16> NuitsSelectionnes = new Collection<Int16>();
            Collection<String> HotelsSelectionnes = new Collection<string>();
            Collection<String> CategoriesSelectionnees = new Collection<string>();
            HotelsSelectionnes.Add("IBIS");
            HotelsSelectionnes.Add("NOVO");
            CategoriesSelectionnees.Add("S");
            CategoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                RepasSelectionnes.Add(i);
                if (i < 3)
                {
                    NuitsSelectionnes.Add(i);
                }
            }
            Assert.AreEqual(true, Utilitaire.EstPayable("400", "500", "Insc", RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes), "Montant insuffisant");
        }

        [TestMethod()]
        public void EstPayableToutTest()
        {
            Collection<Int16> RepasSelectionnes = new Collection<Int16>();
            Collection<Int16> NuitsSelectionnes = new Collection<Int16>();
            Collection<String> HotelsSelectionnes = new Collection<string>();
            Collection<String> CategoriesSelectionnees = new Collection<string>();
            HotelsSelectionnes.Add("IBIS");
            HotelsSelectionnes.Add("NOVO");
            CategoriesSelectionnees.Add("S");
            CategoriesSelectionnees.Add("D");
            for (Int16 i = 1; i < 4; i++)
            {
                RepasSelectionnes.Add(i);
                if (i < 3)
                {
                    NuitsSelectionnes.Add(i);
                }
            }
            Assert.AreEqual(true, Utilitaire.EstPayable("400", "500", "Tout", RepasSelectionnes, CategoriesSelectionnees, HotelsSelectionnes, NuitsSelectionnes), "Montant insuffisant");
        }
    }
}