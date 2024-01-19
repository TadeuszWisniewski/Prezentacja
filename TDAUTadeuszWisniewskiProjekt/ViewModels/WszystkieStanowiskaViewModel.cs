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
    public class WszystkieStanowiskaViewModel : WszystkieViewModel<StanowiskoForView>
    {
        public StanowiskoForView _WybraneS;
        public StanowiskoForView WybraneS
        {
            set
            {
                if (_WybraneS != value)
                {
                    _WybraneS = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybraneS);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybraneS;
            }
        }
        #region Konstruktor
        public WszystkieStanowiskaViewModel()
           : base("Stanowiska")
        {

        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<StanowiskoForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.Stanowiskos
                    from s in firmaSpawalniczaEntities.Stanowiskos
                    select new StanowiskoForView
                    {
                        Id = s.Id,
                        Nazwa = s.Nazwa,
                        Opis = s.Opis,
                        KiedyUtworzone = s.KiedyUtworzone,
                        Aktywny = s.Aktywny
                    }
                );
        }
        #endregion

    }
}
