using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyAdresZameldowaniaViewModel : JedenViewModel<AdresZameldowanium>
    {
        #region Komendy
        private BaseCommand _ShowKrajeCommand;
        public ICommand ShowKrajeCommand
        {
            get
            {
                if (_ShowKrajeCommand == null)
                {
                    _ShowKrajeCommand = new BaseCommand(() => Messenger.Default.Send("KrajeShow"));
                }
                return _ShowKrajeCommand;
            }
        }
        private BaseCommand _ShowWojewodztwaCommand;
        public ICommand ShowWojewodztwaCommand
        {
            get
            {
                if (_ShowWojewodztwaCommand == null)
                {
                    _ShowWojewodztwaCommand = new BaseCommand(() => Messenger.Default.Send("WojewodztwaShow"));
                }
                return _ShowWojewodztwaCommand;
            }
        }
        private BaseCommand _ShowMiejscowoscCommand;
        public ICommand ShowMiejscowoscCommand
        {
            get
            {
                if (_ShowMiejscowoscCommand == null)
                {
                    _ShowMiejscowoscCommand = new BaseCommand(() => Messenger.Default.Send("MiejscowosciShow"));
                }
                return _ShowMiejscowoscCommand;
            }
        }
        #endregion
        public NowyAdresZameldowaniaViewModel()
            :base("Adres zameldowania")
        {
            item = new AdresZameldowanium();

            _DataUtworzenia = DateTime.Today;

            Messenger.Default.Register<KrajForView>(this, getWybranyKraj);
            Messenger.Default.Register<WojewodztwoForView>(this, getWybraneWojewodztwo);
            Messenger.Default.Register<MiejscowosciForView>(this, getWybranaMiejscowosc);
        }
        #region Metody
        private void getWybranaMiejscowosc(MiejscowosciForView wybranaMiejscowosc)
        {
            IdMiejscowosci = wybranaMiejscowosc.Id;
            NazwaMiejscowosci = wybranaMiejscowosc.Nazwa;
        }
        private void getWybraneWojewodztwo(WojewodztwoForView wybraneWojewodztwo)
        {
            IdWojewodztwa = wybraneWojewodztwo.Id;
            NazwaWojewodztwa = wybraneWojewodztwo.Nazwa;
        }
        private void getWybranyKraj(KrajForView wybranyKraj)
        {
            IdKraju = wybranyKraj.Id;
            NazwaKraju = wybranyKraj.Nazwa;
        }
        #endregion
        public override int Zakoncz()
        {
            if (Aktywny == false || IdKraju == null || IdWojewodztwa == null || IdMiejscowosci == null || Powiat.IsNullOrEmpty() || Powiat.StartsWith(' ') || KodGminy.IsNullOrEmpty() || KodGminy.Contains(' ') || Ulica.IsNullOrEmpty() || Ulica.StartsWith(' ') || NumerDomu.IsNullOrEmpty() || NumerDomu.Contains(' ') || NumerLokalu.IsNullOrEmpty() || NumerLokalu.Contains(' ') || Email.IsNullOrEmpty() || Telefon.IsNullOrEmpty() || Telefon.Contains(' ') || TelefonSMS.IsNullOrEmpty() || TelefonSMS.Contains(' '))
            {

                return 0;
            }
            else
            {
                return 1;
            }
        }

        #region Pola
        #region PierwszyWiersz
        private readonly DateTime? _DataUtworzenia;
        public DateTime? DataUtworzenia
        {
            get
            {
                if (item.KiedyUtworzone != _DataUtworzenia)
                {
                    item.KiedyUtworzone = _DataUtworzenia;
                }

                return item.KiedyUtworzone;
            }
        }
        public DateTime? DataModyfikacji
        {
            get
            {
                if (item.KiedyZmieniono != DateTime.Today && item.KiedyUtworzone != DateTime.Today)
                {
                    item.KiedyZmieniono = DateTime.Today;
                }
                return item.KiedyZmieniono;
            }
        }
        public bool? Aktywny
        {
            get
            {
                if (item.Aktywny == null)
                {
                    return item.Aktywny = true;
                }
                else
                {
                    return item.Aktywny;
                }
            }
            set
            {
                if (item.Aktywny != value)
                {
                    item.Aktywny = value;
                    OnPropertyChanged(() => Aktywny);
                }
            }
        }
        #endregion
        #region DaneZamieszkania
        public int? IdKraju
        {
            get
            {
                return item.IdKraju;
            }
            set
            {
                if (item.IdKraju != value)
                {
                    item.IdKraju = value;
                    OnPropertyChanged(() => IdKraju);
                }
            }
        }
        private string? _NazwaKraju;
        public string? NazwaKraju
        {
            get
            {

                return _NazwaKraju;
            }
            set
            {
                if (_NazwaKraju != value)
                {
                    _NazwaKraju = value;
                    base.OnPropertyChanged(() => NazwaKraju);
                }
            }
        }
        public int? IdWojewodztwa
        {
            get
            {
                return item.IdWojewodztwa;
            }
            set
            {
                if (item.IdWojewodztwa != value)
                {
                    item.IdWojewodztwa = value;
                    OnPropertyChanged(() => IdWojewodztwa);
                }
            }
        }
        public string? _NazwaWojewodztwa;
        public string? NazwaWojewodztwa
        {
            get
            {

                return _NazwaWojewodztwa;
            }
            set
            {
                if (_NazwaWojewodztwa != value)
                {
                    _NazwaWojewodztwa = value;
                    base.OnPropertyChanged(() => NazwaWojewodztwa);
                }
            }
        }
        public int? IdMiejscowosci
        {
            get
            {
                return item.IdMiejscowosc;
            }
            set
            {
                if (item.IdMiejscowosc != value)
                {
                    item.IdMiejscowosc = value;
                    OnPropertyChanged(() => IdMiejscowosci);
                }
            }
        }
        public string? _NazwaMiejscowosci;
        public string? NazwaMiejscowosci
        {
            get
            {

                return _NazwaMiejscowosci;
            }
            set
            {
                if (_NazwaMiejscowosci != value)
                {
                    _NazwaMiejscowosci = value;
                    base.OnPropertyChanged(() => NazwaMiejscowosci);
                }
            }
        }
        public string? Powiat
        {
            get
            {
                return item.Powiat;
            }
            set
            {
                if (item.Powiat != value)
                {
                    item.Powiat = value;
                    base.OnPropertyChanged(() => Powiat);
                }
            }
        }
        public string? KodGminy
        {
            get
            {
                return item.KodGminy;
            }
            set
            {
                if (item.KodGminy != value)
                {
                    item.KodGminy = value;
                    base.OnPropertyChanged(() => KodGminy);
                }
            }
        }
        public string? Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string? NumerDomu
        {
            get
            {
                return item.NumerDomu;
            }
            set
            {
                if (item.NumerDomu != value)
                {
                    item.NumerDomu = value;
                    base.OnPropertyChanged(() => NumerDomu);
                }
            }
        }
        public string? NumerLokalu
        {
            get
            {
                return item.NumerLokalu;
            }
            set
            {
                if (item.NumerLokalu != value)
                {
                    item.NumerLokalu = value;
                    base.OnPropertyChanged(() => NumerLokalu);
                }
            }
        }
        public string? KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        #endregion
        #region DaneKontaktowe
        public string? Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    base.OnPropertyChanged(() => Telefon);
                }
            }
        }
        public string? TelefonSMS
        {
            get
            {
                return item.TelefonSms;
            }
            set
            {
                if (item.TelefonSms != value)
                {
                    item.TelefonSms = value;
                    base.OnPropertyChanged(() => TelefonSMS);
                }
            }
        }
        public string? Email
        {
            get
            {
                return item.EMail;
            }
            set
            {
                if (item.EMail != value)
                {
                    if (value.StartsWith('.'))
                    {
                        MessageBox.Show("Błędny znak początkowy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.EMail = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.EMail= null;
                        return;
                    }
                    if (!(value.Contains("@")))
                    {
                        MessageBox.Show("Błędny adres Email", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.EMail = null;
                        return;
                    }
                    item.EMail = value;
                    base.OnPropertyChanged(() => Email);
                }
            }
        }
        #endregion
        #region Opis
        public string? Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }
        #endregion
        #endregion
    }
}
