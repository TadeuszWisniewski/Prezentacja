using GalaSoft.MvvmLight.Messaging;
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
    public class WszystkieTypyNIPViewModel : WszystkieViewModel<TypNIPForView>
    {
        public TypNIPForView _WybranyT;
        public TypNIPForView WybranyT
        {
            set
            {
                if (WybranyT != value)
                {
                    _WybranyT = value;
                    Messenger.Default.Send(_WybranyT);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyT;
            }
        }
        #region Konstruktor
        public WszystkieTypyNIPViewModel()
           : base("Typy NIP")
        {
        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "IloscCyfr" };
        }
        public override void sort()
        {

            if (SortField == "IloscCyfr")
                List = new ObservableCollection<TypNIPForView>(List.OrderBy(item => item.IloscCyfr));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "IloscCyfr" };
        }
        public override void find()
        {
            if (FindField == "IloscCyfr")
                List = new ObservableCollection<TypNIPForView>(List.Where(item => item.IloscCyfr != null && item.IloscCyfr == int.Parse(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<TypNIPForView>
                (
                    from t in firmaSpawalniczaEntities.TypNips
                    select new TypNIPForView
                    {
                        Id = t.Id,
                        IloscCyfr = t.IloscCyfr,
                        Opis = t.Opis,
                        KiedyUtworzone = t.KiedyUtworzone,
                        Aktywny = t.Aktywny,
                    }
                );
        }
        #endregion

    }
}
