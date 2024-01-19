using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieWymiaryEtatuViewModel : WszystkieViewModel<WymiarEtatuForView>
    {
        public WymiarEtatuForView _WybranyW;
        public WymiarEtatuForView WybranyW
        {
            set
            {
                if (_WybranyW != value)
                {
                    _WybranyW = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyW);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyW;
            }
        }
        #region Konstruktor
        public WszystkieWymiaryEtatuViewModel()
           : base("Wymiary etatu")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<WymiarEtatuForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.WymiarEtatus
                    from w in firmaSpawalniczaEntities.WymiarEtatus
                    select new WymiarEtatuForView
                    {
                        Id = w.Id,
                        Nazwa = w.Nazwa,
                        IloscGodzinTygodniowo = w.IloscGodzinTygodniowo,
                        Opis = w.Opis,
                        Aktywny = w.Aktywny,
                        KiedyUtworzono = w.KiedyUtworzono
                    }
                );
        }
        #endregion

    }
}
