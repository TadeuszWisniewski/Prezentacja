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
    public class WszystkieTypyNIPViewModel : WszystkieViewModel<TypNIPForView>
    {
        public TypNIPForView _WybranyT;
        public TypNIPForView WybranyT
        {
            set
            {
                if (WybranyT != value)
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
        public WszystkieTypyNIPViewModel()
           : base("Typy NIP")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<TypNIPForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.TypNips
                    from t in firmaSpawalniczaEntities.TypNips
                    select new TypNIPForView
                    {
                        Id = t.Id,
                        IloscCyfr = t.IloscCyfr,
                        Opis = t.Opis,
                        KiedyUtworzone = t.KiedyUtworzone,
                        Aktywny = t.Aktywny,
                    }
                );
        }
        #endregion

    }
}
