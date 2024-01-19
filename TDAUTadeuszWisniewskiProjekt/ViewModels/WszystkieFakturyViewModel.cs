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
        public override void load()
        {
            List = new ObservableCollection<FakturaForView>
                (
                    from faktura in firmaSpawalniczaEntities.Fakturas
                    select new FakturaForView
                    {
                        Id = faktura.Id,
                        Numer = faktura.Numer,
                        WartoscPoRabacie=faktura.WartoscPoRabacie,
                        KiedyUtworzono=faktura.KiedyUtworzono,
                        KiedyZmieniono=faktura.KiedyZmieniono,
                        Aktywny=faktura.Aktywny
                    }
                ) ;
        }
        #endregion
    }
}
