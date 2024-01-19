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
    public class WszystkieTypyUmowOPraceViewModel : WszystkieViewModel<TypyUmowOPraceForView>
    {

        public TypyUmowOPraceForView _WybranaU;
        public TypyUmowOPraceForView WybranaU
        {
            set
            {
                if (_WybranaU != value)
                {
                    _WybranaU = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranaU);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaU;
            }
        }
        #region Konstruktor
        public WszystkieTypyUmowOPraceViewModel()
           : base("Typy umowy o prace")
        {
        }
        #endregion
        #region Command
        private Kontrahent _WybranyTypUmowy;
        public Kontrahent WybranyTypUmowy
        {
            set
            {
                if (_WybranyTypUmowy != value)
                {
                    _WybranyTypUmowy = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyTypUmowy);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyTypUmowy;
            }
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<TypyUmowOPraceForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.TypUmowyOpraces
                    from u in firmaSpawalniczaEntities.TypUmowyOpraces
                    select new TypyUmowOPraceForView
                    {
                        Id = u.Id,
                        Nazwa = u.Nazwa,
                        Opis = u.Opis,
                        KiedyUtworzone = u.KiedyUtworzone,
                        Aktywny = u.Aktywny
                    }
                );
        }
        #endregion

    }
}
