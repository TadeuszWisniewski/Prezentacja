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
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranaC);
                    //zamyka okno
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
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<CenaForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.Cenas
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
