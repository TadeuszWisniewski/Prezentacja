using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieCenyWyprzedazyViewModel:WszystkieViewModel<CenaWyprzedazyForView>
    {
        private CenaWyprzedazyForView _WybranaC;
        public CenaWyprzedazyForView WybranaC
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
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranaC);
                    //zamyka okno
                    OnRequestClose();
                }
            }
        }
        #region Konstruktor
        public WszystkieCenyWyprzedazyViewModel()
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
                List = new ObservableCollection<CenaWyprzedazyForView>(List.OrderBy(item => item.Wartosc));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Wartosc" };
        }
        public override void find()
        {
            if (FindField == "Wartosc")
                List = new ObservableCollection<CenaWyprzedazyForView>(List.Where(item => item.Wartosc != null && item.Wartosc == Decimal.Parse(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<CenaWyprzedazyForView>
                (
                    from c in firmaSpawalniczaEntities.Cenas
                    select new CenaWyprzedazyForView
                    {
                        Id = c.Id,
                        Wartosc = c.Wartosc,
                        KiedyUtworzono = c.KiedyUtworzono,
                        KiedyZmieniono=c.KiedyZmieniono,
                        Aktywny = c.Aktywny,
                    }
                );
        }
        #endregion
    }
}
