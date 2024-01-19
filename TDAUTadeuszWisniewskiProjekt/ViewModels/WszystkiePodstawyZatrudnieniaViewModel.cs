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
    public class WszystkiePodstawyZatrudnieniaViewModel : WszystkieViewModel<PodstawaZatrudnieniaForView>
    {
        public PodstawaZatrudnieniaForView _WybranaP;
        public PodstawaZatrudnieniaForView WybranaP
        {
            set
            {
                if (_WybranaP != value)
                {
                    _WybranaP = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranaP);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaP;
            }
        }
        #region Konstruktor
        public WszystkiePodstawyZatrudnieniaViewModel()
           : base("Podstawy zatrudnienia")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<PodstawaZatrudnieniaForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.PodstawaZatrudnienia
                    from p in firmaSpawalniczaEntities.PodstawaZatrudnienia
                    select new PodstawaZatrudnieniaForView
                    {
                        Id = p.Id,
                        Nazwa = p.Nazwa,
                        Opis = p.Opis,
                        KiedyUtworzone = p.KiedyUtworzone,                       
                        Aktywny = p.Aktywny
                    }
                );
        }
        #endregion

    }
}
