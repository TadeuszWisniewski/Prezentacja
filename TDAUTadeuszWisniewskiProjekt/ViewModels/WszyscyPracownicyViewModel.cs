using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForView>
    {
        #region Command
        private PracownikForView _WybranyP;
        public PracownikForView WybranyP
        {
            set
            {
                if (_WybranyP != value)
                {
                    _WybranyP = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyP);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyP;
            }
        }


        #endregion
        public WszyscyPracownicyViewModel()
            :base("Pracownicy")
        {
        }

        public override void load()
        {
            List = new ObservableCollection<PracownikForView>
                (
                from p in firmaSpawalniczaEntities.Pracowniks
                select new PracownikForView
                {
                    Id = p.Id,
                    Imie=p.Imie,
                    Nazwisko=p.Nazwisko,
                    Pesel=p.Pesel,
                    DataUrodzenia=p.DataUrodzenia,
                    JednostkaOrganizacyjnaNazwa=p.IdJednostkaOrganizacyjnaNavigation.NazwaJednostkiOrganizacyjnej,
                    Stawka=p.Stawka,
                    Aktywny=p.Aktywny,
                    KiedyUtworzone=p.KiedyUtworzone
                }
                ) ;
        }
    }
}
