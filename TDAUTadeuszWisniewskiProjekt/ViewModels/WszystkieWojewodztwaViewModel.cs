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
    public class WszystkieWojewodztwaViewModel : WszystkieViewModel<WojewodztwoForView>
    {
        #region Wybrany
        private WojewodztwoForView _WybraneWojewodztwo;
        public WojewodztwoForView WybraneWojewodztwo
        {
            set
            {
                if (_WybraneWojewodztwo != value)
                {
                    _WybraneWojewodztwo = value;
                    Messenger.Default.Send(_WybraneWojewodztwo);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybraneWojewodztwo;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieWojewodztwaViewModel()
           : base("Wojewodztwa")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            List = new ObservableCollection<WojewodztwoForView>
                (
                    from woj in firmaSpawalniczaEntities.Wojewodztwos
                    select new WojewodztwoForView
                    {
                        Id = woj.Id,
                        Nazwa = woj.Nazwa,
                        DataUtworzenia = woj.KiedyUtworzono,
                        DataModyfikacji = woj.KiedyZmieniono,
                        Aktywny = woj.Aktywny
                    }
                );
        }
        #endregion

    }
}
