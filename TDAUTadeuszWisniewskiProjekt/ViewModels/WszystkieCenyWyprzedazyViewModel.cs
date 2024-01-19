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
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<CenaWyprzedazyForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.Cenas
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
