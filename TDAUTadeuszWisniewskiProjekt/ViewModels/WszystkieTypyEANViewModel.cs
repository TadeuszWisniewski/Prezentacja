using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieTypyEANViewModel : WszystkieViewModel<Eantyp>
    {
        #region Konstruktor
        public WszystkieTypyEANViewModel()
           : base("EAN Typy")
        {
        }
        #endregion
        #region Pomocniczy
        //nie robię wyszukiwania i sortowania bo nie wyświetlam tej tabeli.
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "" };
        }
        public override void sort()
        {
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { ""};
        }
        public override void find()
        {
        }
        public override void load()
        {
            List = new ObservableCollection<Eantyp>
                (
                    firmaSpawalniczaEntities.Eantyps
                );
        }
        #endregion

    }
}
