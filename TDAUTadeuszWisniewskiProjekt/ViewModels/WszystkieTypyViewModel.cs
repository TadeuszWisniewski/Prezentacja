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
    public class WszystkieTypyViewModel : WszystkieViewModel<TypForView>
    {
        private TypForView _WybranyT;
        public TypForView WybranyT
        {
            get
            {
                return _WybranyT;
            }
            set
            {
                if(_WybranyT != value)
                {
                    _WybranyT = value;
                    Messenger.Default.Send(_WybranyT);
                    OnRequestClose();
                }
            }
        }
        #region Konstruktor
        public WszystkieTypyViewModel()
           : base("Typy")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<TypForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    from t in firmaSpawalniczaEntities.Typs
                    select new TypForView
                    {
                        Id=t.Id,
                        Nazwa=t.Nazwa,
                        Opis=t.Opis,
                        KiedyUtworzono=t.KiedyUtworzono,
                        KiedyZmieniono=t.KiedyZmieniono,
                        Aktywny=t.Aktywny
                    }
                );
        }
        #endregion

    }
}
