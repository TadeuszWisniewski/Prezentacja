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
    public class WszystkieAdresyDoKorespondencjiViewModel : WszystkieViewModel<AdresDoKorespondencjiForView>
    {
        #region Wybrany
        private AdresDoKorespondencjiForView _WybranyA;
        public AdresDoKorespondencjiForView WybranyA
        {
            set
            {
                if (_WybranyA != value)
                {
                    _WybranyA = value;
                    Messenger.Default.Send(_WybranyA);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyA;
            }
        }


        #endregion
        public WszystkieAdresyDoKorespondencjiViewModel()
            : base("Adresy Do korespondencji")
        {
        }


        public override List<string> getComboboxSortList()
        {
            return new List<string> { "NazwaKraju", "NazwaWojewodztwa" };
        }
        public override void sort()
        {

            if (SortField == "NazwaKraju")
                List = new ObservableCollection<AdresDoKorespondencjiForView>(List.OrderBy(item => item.NazwaKraju));
            if (SortField == "NazwaWojewodztwa")
                List = new ObservableCollection<AdresDoKorespondencjiForView>(List.OrderBy(item => item.NazwaWojewodztwa));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "NazwaKraju", "NazwaWojewodztwa" };
        }
        public override void find()
        {
            if (FindField == "NazwaKraju")
                List = new ObservableCollection<AdresDoKorespondencjiForView>(List.Where(item => item.NazwaKraju != null && item.NazwaKraju.StartsWith(FindTextBox)));
            if (FindField == "NazwaWojewodztwa")
                List = new ObservableCollection<AdresDoKorespondencjiForView>(List.Where(item => item.NazwaWojewodztwa != null && item.NazwaWojewodztwa.StartsWith(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<AdresDoKorespondencjiForView>
            (
                from adr in firmaSpawalniczaEntities.AdresZameldowania
                select new AdresDoKorespondencjiForView
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
            );
        }

    }
}


