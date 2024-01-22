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
    public class WszystkieAdresyZameldowaniaViewModel : WszystkieViewModel<AdresZameldowaniaForView>
    {
        #region Properties
        private AdresZameldowaniaForView _WybranyAdresZameldowania;
        public AdresZameldowaniaForView WybranyAdresZameldowania
        {
            set
            {
                if (_WybranyAdresZameldowania != value)
                {
                    _WybranyAdresZameldowania = value;
                    Messenger.Default.Send(_WybranyAdresZameldowania);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyAdresZameldowania;
            }
        }
        #endregion
        public WszystkieAdresyZameldowaniaViewModel() 
            : base("Adresy zameldowania")
        {
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "NazwaKraju", "NazwaWojewodztwa" };
        }
        public override void sort()
        {

            if (SortField == "NazwaKraju")
                List = new ObservableCollection<AdresZameldowaniaForView>(List.OrderBy(item => item.NazwaKraju));
            if (SortField == "NazwaWojewodztwa")
                List = new ObservableCollection<AdresZameldowaniaForView>(List.OrderBy(item => item.NazwaWojewodztwa));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "NazwaKraju", "NazwaWojewodztwa" };
        }
        public override void find()
        {
            if (FindField == "NazwaKraju")
                List = new ObservableCollection<AdresZameldowaniaForView>(List.Where(item => item.NazwaKraju != null && item.NazwaKraju.StartsWith(FindTextBox)));
            if (FindField == "NazwaWojewodztwa")
                List = new ObservableCollection<AdresZameldowaniaForView>(List.Where(item => item.NazwaWojewodztwa != null && item.NazwaWojewodztwa.StartsWith(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<AdresZameldowaniaForView>
            (
                from adr in firmaSpawalniczaEntities.AdresZameldowania
                select new AdresZameldowaniaForView
                {
                    Id = adr.Id,
                    NazwaKraju = adr.IdKrajuNavigation.Nazwa,
                    NazwaPowiatu = adr.Powiat,
                    Ulica = adr.Ulica,
                    NazwaMiejscowosci = adr.IdMiejscowoscNavigation.Nazwa,
                    Telefon = adr.Telefon,
                    Email = adr.EMail,
                    NazwaWojewodztwa = adr.IdWojewodztwaNavigation.Nazwa,
                    KodGminy = adr.KodGminy,
                    NumerDomu = adr.NumerDomu,
                    NumerLokalu = adr.NumerLokalu,
                    KodPocztowy = adr.KodPocztowy,
                    TelefonSMS = adr.TelefonSms,
                    Opis = adr.Opis,
                    Aktywny = adr.Aktywny,
                    KiedyUtworzone = adr.KiedyUtworzone
                }
            ) ; 
        }
        
    }
}
