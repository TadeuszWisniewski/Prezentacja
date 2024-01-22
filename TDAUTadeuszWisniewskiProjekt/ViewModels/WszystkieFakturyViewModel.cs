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
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForView>
    {
        #region Wybrany
        public FakturaForView _WybranaF;
        public FakturaForView WybranaF
        {
            set
            {
                if (_WybranaF != value)
                {
                    _WybranaF = value;
                    Messenger.Default.Send(_WybranaF);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaF;
            }
        }

        #endregion
        #region Konstruktor
        public WszystkieFakturyViewModel()
           : base("Faktury")
        {

        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa kontrahenta", "Numer" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa kontrahenta")
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.NazwaKontrahenta));
            if (SortField == "Numer")
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.Numer));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa kontrahenta", "Numer" };
        }
        public override void find()
        {
            if (FindField == "Nazwa kontrahenta")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.NazwaKontrahenta != null && item.NazwaKontrahenta.StartsWith(FindTextBox)));
            if (FindField == "Numer")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.Numer != null && item.Numer.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<FakturaForView>
                (
                    from faktura in firmaSpawalniczaEntities.Fakturas
                    select new FakturaForView
                    {
                        Id = faktura.Id,
                        Numer = faktura.Numer,
                        NazwaKontrahenta= faktura.IdKontrahentaNavigation.Bazwa,
                        WartoscPoRabacie =faktura.WartoscPoRabacie,
                        KiedyUtworzono=faktura.KiedyUtworzono,
                        KiedyZmieniono=faktura.KiedyZmieniono,
                        Aktywny=faktura.Aktywny
                    }
                ) ;
        }
        #endregion
    }
}
