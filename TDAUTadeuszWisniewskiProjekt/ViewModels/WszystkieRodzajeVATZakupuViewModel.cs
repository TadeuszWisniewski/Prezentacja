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
    public class WszystkieRodzajeVATZakupuViewModel : WszystkieViewModel<RodzajVATZakupuForView>
    {
        #region Properties
        public RodzajVATZakupuForView _WybranyR;
        public RodzajVATZakupuForView WybranyR
        {
            set
            {
                if (_WybranyR != value)
                {
                    _WybranyR = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyR);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyR;
            }
        }

        #endregion
        #region Konstruktor
        public WszystkieRodzajeVATZakupuViewModel()
           : base("Rodzaje VAT")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<RodzajVATZakupuForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.RodzajVats
                    from r in firmaSpawalniczaEntities.RodzajVats
                    select new RodzajVATZakupuForView
                    {
                        Id = r.Id,
                        Nazwa = r.Nazwa,
                        Wysokosc = r.Wysokosc,
                        KiedyUtworzone = r.KiedyUtworzone,
                        KiedyZmieniono=r.KiedyZmieniono,
                        Aktywny = r.Aktywny
                    }
                );
        }
        #endregion
    }
}
