using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace EntityFrameworkM2L
{
    class bdd
    {
        private M2LEntities M2LContexte;
        public bdd()
        {
            M2LContexte = new M2LEntities();
        }

        public object FindAtelier()
        {
            var requete = from ATELIER in M2LContexte.ATELIERs select ATELIER;
            var lesAteliers = requete.ToList();
            return lesAteliers;
        }

        public object FindQualite()
        {
            var requete = from QUALITE in M2LContexte.QUALITEs select QUALITE;
            var lesQualites = requete.ToList();
            return lesQualites;
        }

        public object FindNbParAtelier()
        {
            var requete = from atelier in M2LContexte.INSCRIREs
                          group atelier by atelier.IDATELIER into groupeParticipant
                          select new
                          {
                              Atelier = groupeParticipant.Key,
                              Nombre = groupeParticipant.Count()
                          };
            var NbParticipantAtelier = requete.OrderBy(atelier => atelier.Atelier).ToList();
            return NbParticipantAtelier;
        }

        public object FindRestauration()
        {
            var requete = from VRESTAURATION01 in M2LContexte.VRESTAURATION01 select VRESTAURATION01;
            var LesRestaurations = requete.ToList();
            return LesRestaurations;
        }

        public void FermerConnexion()
        {
            M2LContexte.Dispose();
        }
    }
}
