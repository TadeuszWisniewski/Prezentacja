using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieRodzajeVATViewModel : WszystkieViewModel<RodzajVatForView>
    {
        #region Properties
        public RodzajVatForView _WybranyR;
        public RodzajVatForView WybranyR
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
        public WszystkieRodzajeVATViewModel()
           : base("Rodzaje VAT")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<RodzajVatForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.RodzajVats
                    from r in firmaSpawalniczaEntities.RodzajVats
                    select new RodzajVatForView
                    {
                        Id=r.Id,
                        Nazwa=r.Nazwa,
                        Wysokosc=r.Wysokosc,
                        KiedyUtworzone =r.KiedyUtworzone,
                        KiedyZmieniono=r.KiedyZmieniono,
                        Aktywny=r.Aktywny
                    }
                );
        }
        #endregion

    }
}
