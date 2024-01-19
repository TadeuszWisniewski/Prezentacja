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
    public class WszystkieTypyStawkiViewModel : WszystkieViewModel<TypStawkiForView>
    {
        public TypStawkiForView _WybranyT;
        public TypStawkiForView WybranyT
        {
            set
            {
                if (_WybranyT != value)
                {
                    _WybranyT = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyT);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyT;
            }
        }
        #region Konstruktor
        public WszystkieTypyStawkiViewModel()
           : base("Typy stawki")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<TypStawkiForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.TypStawkis
                    from t in firmaSpawalniczaEntities.TypStawkis
                    select new TypStawkiForView
                    {
                        Id = t.Id,
                        Nazwa = t.Nazwa,
                        Opis = t.Opis,
                        KiedyUtworzono = t.KiedyUtworzono,
                        Aktywny = t.Aktywny
                    }
                );
        }
        #endregion

    }
}
