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
    public class WszystkieCenyViewModel : WszystkieViewModel<CenaForView>
    {
        private CenaForView _WybranaC;
        public CenaForView WybranaC
        {
            get
            {
                return _WybranaC;
            }
            set
            {
                if (_WybranaC != value)
                {
                    _WybranaC = value;
                    Messenger.Default.Send(_WybranaC);
                    OnRequestClose();
                }
            }
        }
        #region Konstruktor
        public WszystkieCenyViewModel()
           : base("Ceny")
        {
        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Wartosc" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<CenaForView>(List.OrderBy(item => item.Wartosc));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Wartosc" };
        }
        public override void find()
        {
            if (FindField == "Wartosc")
                List = new ObservableCollection<CenaForView>(List.Where(item => item.Wartosc != null && item.Wartosc == Decimal.Parse(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<CenaForView>
                (
                    from c in firmaSpawalniczaEntities.Cenas
                    select new CenaForView
                    {
                        Id = c.Id,
                        Wartosc = c.Wartosc,
                        KiedyUtworzono=c.KiedyUtworzono,
                        KiedyZmieniono=c.KiedyZmieniono,
                        Aktywny=c.Aktywny,
                    }
                );
        }
        #endregion

    }
}
