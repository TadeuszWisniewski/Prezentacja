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
    public class WszystkieKrajeViewModel : WszystkieViewModel<KrajForView>
    {
        #region Wybrany
        private KrajForView _WybranyKraj;
        public KrajForView WybranyKraj
        {
            get
            {
                return _WybranyKraj;
            }
            set
            {
                if (_WybranyKraj != value)
                {
                    _WybranyKraj = value;
                    Messenger.Default.Send(_WybranyKraj);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieKrajeViewModel()
           : base("Kraje")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            List = new ObservableCollection<KrajForView>
                (
                    from kraj in firmaSpawalniczaEntities.Krajs
                    select new KrajForView
                    {
                        Id = kraj.Id,
                        Nazwa = kraj.Nazwa,
                        KiedyUtworzone = kraj.KiedyUtworzone,
                        KiedyZmieniono = kraj.KiedyZmieniono,
                        Aktywny = kraj.Aktywny
                    }
                );
        }
        #endregion

    }
}
