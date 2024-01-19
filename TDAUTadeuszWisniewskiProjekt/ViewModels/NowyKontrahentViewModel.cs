using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyKontrahentViewModel : JedenViewModel<Kontrahent>
    {
        #region Commands
        private BaseCommand _ShowRodzajVatCommand;
        public ICommand ShowRodzajVatCommand
        {
            get
            {
                if (_ShowRodzajVatCommand == null)
                {
                    _ShowRodzajVatCommand = new BaseCommand(() => Messenger.Default.Send("Rodzaje VATShow"));
                }
                return _ShowRodzajVatCommand;
            }
        }
        private BaseCommand _ShowRodzajVatZakupuCommand;
        public ICommand ShowRodzajVatZakupuCommand
        {
            get
            {
                if (_ShowRodzajVatZakupuCommand == null)
                {
                    _ShowRodzajVatZakupuCommand = new BaseCommand(() => Messenger.Default.Send("Rodzaje VAT zakupuShow"));
                }
                return _ShowRodzajVatZakupuCommand;
            }
        }
        private BaseCommand _ShowStatusyWBazieMFCommand;
        public ICommand ShowStatusyWBazieMFCommand
        {
            get
            {
                if (_ShowStatusyWBazieMFCommand == null)
                {
                    _ShowStatusyWBazieMFCommand = new BaseCommand(() => Messenger.Default.Send("Statusy w bazieShow"));
                }
                return _ShowStatusyWBazieMFCommand;
            }
        }
        private BaseCommand _ShowStatusyWBazieVIESCommand;
        public ICommand ShowStatusyWBazieVIESCommand
        {
            get
            {
                if (_ShowStatusyWBazieVIESCommand == null)
                {
                    _ShowStatusyWBazieVIESCommand = new BaseCommand(() => Messenger.Default.Send("Statusy w bazie VIESShow"));
                }
                return _ShowStatusyWBazieVIESCommand;
            }
        }
        private BaseCommand _ShowStatusyCommand;
        public ICommand ShowStatusyCommand
        {
            get
            {
                if (_ShowStatusyCommand == null)
                {
                    _ShowStatusyCommand = new BaseCommand(() => Messenger.Default.Send("StatusyShow"));
                }
                return _ShowStatusyCommand;
            }
        }
        private BaseCommand _FormaPrawnaCommand;
        public ICommand FormaPrawnaCommand
        {
            get
            {
                if (_FormaPrawnaCommand == null)
                {
                    _FormaPrawnaCommand = new BaseCommand(() => Messenger.Default.Send("Formy prawneShow"));
                }
                return _FormaPrawnaCommand;
            }
        }
        private BaseCommand _AdresZameldowaniaCommand;
        public ICommand AdresZameldowaniaCommand
        {
            get
            {
                if (_AdresZameldowaniaCommand == null)
                {
                    _AdresZameldowaniaCommand = new BaseCommand(() => Messenger.Default.Send("AdresyShow"));
                }
                return _AdresZameldowaniaCommand;
            }
        }
        private BaseCommand _AdresDoKorespondencjiCommand;
        public ICommand AdresDoKorespondencjiCommand
        {
            get
            {
                if (_AdresDoKorespondencjiCommand == null)
                {
                    _AdresDoKorespondencjiCommand = new BaseCommand(() => Messenger.Default.Send("Adresy do korespondencjiShow"));
                }
                return _AdresDoKorespondencjiCommand;
            }
        }
        private BaseCommand _DefinicjaPlatnosciCommand;
        public ICommand DefinicjaPlatnosciCommand
        {
            get
            {
                if (_DefinicjaPlatnosciCommand == null)
                {
                    _DefinicjaPlatnosciCommand = new BaseCommand(() => Messenger.Default.Send("Definicje platnosciShow"));
                }
                return _DefinicjaPlatnosciCommand;
            }
        }
        #endregion
        #region Konstruktor
        public NowyKontrahentViewModel()
            : base("Kontrahent")
        {
            item = new Kontrahent();
            _DataUtworzenia = DateTime.Today;

            Messenger.Default.Register<StatusWBazieMFForView>(this, getWybranyStatusWBazie);
            Messenger.Default.Register<StatusWBazieVIESForView>(this, getWybranyStatusWBazieVIES);
            Messenger.Default.Register<StatusForView>(this, getWybranyStatus);
            Messenger.Default.Register<FormaPrawnaForView>(this, getWybranaFormaPrawna);
            Messenger.Default.Register<AdresZameldowaniaForView>(this, getWybranyAdresZameldowania);
            Messenger.Default.Register<AdresDoKorespondencjiForView>(this, getWybranyAdresDoKorespondencji);
            Messenger.Default.Register<DefinicjaPlatnosciForView>(this, getWybranaDefinicjaPlatnosci);
        }
        #endregion
        #region Metody
        private void getWybranyStatusWBazie(StatusWBazieMFForView statusWBazie)
        {
            //podstawiamy rodzaj vat przesłany
            IdStatusMF=statusWBazie.Id;
            StatusWBazieMF = statusWBazie.Nazwa;
        }
        private void getWybranyStatusWBazieVIES(StatusWBazieVIESForView statusWBazie)
        {
            //podstawiamy rodzaj vat przesłany
            IdStatusVIES = statusWBazie.Id;
            StatusWBazieVIES = statusWBazie.Nazwa;
        }
        private void getWybranyStatus(StatusForView status)
        {
            //podstawiamy rodzaj vat przesłany
            IdStatus = status.Id;
            Status=status.Nazwa;
        }
        private void getWybranaFormaPrawna(FormaPrawnaForView forma)
        {
            //podstawiamy rodzaj vat przesłany
            IdFormaPrawna=forma.Id;
            FormaPrawna = forma.Nazwa;
        }
        private void getWybranyAdresZameldowania(AdresZameldowaniaForView adr)
        {
            IdAdresZameldowania=adr.Id;
            AdresZameldowaniaNazwaKraju = adr.NazwaKraju;
            AdresZameldowaniaNazwaWojewodztwa = adr.NazwaWojewodztwa;
            AdresZameldowaniaNazwaMiejscowosci = adr.NazwaMiejscowosci;
            AdresZameldowaniaNazwaPowiatu = adr.NazwaPowiatu;
            AdresZameldowaniaKodGminy = adr.KodGminy;
            AdresZameldowaniaUlica = adr.Ulica;
            AdresZameldowaniaNumerDomu = adr.NumerDomu;
            AdresZameldowaniaNumerLokalu = adr.NumerLokalu;
            AdresZameldowaniaKodPocztowy = adr.KodPocztowy;
            AdresZameldowaniaTelefon = adr.Telefon;
            AdresZameldowaniaTelefonSms = adr.TelefonSMS;
            AdresZameldowaniaEmail = adr.Email;
        }
        private void getWybranyAdresDoKorespondencji(AdresDoKorespondencjiForView adr)
        {
            IdAdresDoKorespondencji = adr.Id;
            AdresDoKorespondencjiNazwaKraju = adr.NazwaKraju;
            AdresDoKorespondencjiNazwaWojewodztwa = adr.NazwaWojewodztwa;
            AdresDoKorespondencjiNazwaMiejscowosci = adr.NazwaMiejscowosci;
            AdresDoKorespondencjiNazwaPowiatu = adr.NazwaPowiatu;
            AdresDoKorespondencjiKodGminy = adr.KodGminy;
            AdresDoKorespondencjiUlica = adr.Ulica;
            AdresDoKorespondencjiNumerDomu = adr.NumerDomu;
            AdresDoKorespondencjiNumerLokalu = adr.NumerLokalu;
            AdresDoKorespondencjiKodPocztowy = adr.KodPocztowy;
            AdresDoKorespondencjiTelefon = adr.Telefon;
            AdresDoKorespondencjiTelefonSms = adr.TelefonSMS;
            AdresDoKorespondencjiEmail = adr.Email;
        }
        private void getWybranaDefinicjaPlatnosci(DefinicjaPlatnosciForView def)
        {
            IdDefinicjaPlatnosci = def.Id;
            DefinicjaPlatnosciNazwa = def.Nazwa;
        }
        private void PrzywrocAdresDoKorespondencjiDoStanyPoczatkowego()
        {
            IdAdresDoKorespondencji = null;
            AdresDoKorespondencjiNazwaKraju = null;
            AdresDoKorespondencjiNazwaWojewodztwa = null;
            AdresDoKorespondencjiNazwaPowiatu = null;
            AdresDoKorespondencjiNazwaMiejscowosci = null;
            AdresDoKorespondencjiKodGminy = null;
            AdresDoKorespondencjiUlica = null;
            AdresDoKorespondencjiNumerDomu = null;
            AdresDoKorespondencjiNumerLokalu = null;
            AdresDoKorespondencjiKodPocztowy = null;
            AdresDoKorespondencjiTelefon = null;
            AdresDoKorespondencjiTelefonSms = null;
            AdresDoKorespondencjiEmail = null;
        }
        private void StworzKod()
        {
            Kod = Nazwa.Substring(0, 3);
        }
        public override int Zakoncz()
        {
            if (Aktywny == false || LimitKredytu == null  || IdStatus == null || IdFormaPrawna == null || IdStatusMF == null || IdStatusVIES == null || Nazwa.IsNullOrEmpty() || Nip.IsNullOrEmpty() || Pesel.IsNullOrEmpty() || Regon.IsNullOrEmpty() || Krs.IsNullOrEmpty() || GlnIln.IsNullOrEmpty() || StronaWww.IsNullOrEmpty() || IdAdresZameldowania == null || IdDefinicjaPlatnosci == null || IdWaluta == null)
            {
                return 0;
            }
            StworzKod();
            return 1;
        }
        #endregion
        #region Pola
        #region PierwszyWiersz
        #region Prawa
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
        #region Lewa
        public decimal? LacznaWartoscFaktur
        {
            get
            {
                return (
                    from p in firmaSpawalniczaEntities.Fakturas
                    where p.IdKontrahenta == item.Id
                    select new
                    {
                        p.WartoscPoRabacie
                    }
                    ).Sum(p => p.WartoscPoRabacie);
            }
        }
        public decimal? SumaZaleglychNaleznosci
        {
            get
            {
                return (
                    from p in firmaSpawalniczaEntities.Fakturas
                    where p.Id == item.Id && p.Zaplacone == false
                    select new
                    {
                        p.WartoscPoRabacie
                    }
                    ).Sum(p => p.WartoscPoRabacie);
            }
        }
        public decimal? LimitKredytu
        {
            get
            {
                return item.LimitKredytu;
            }
            set
            {
                if (item.LimitKredytu != value)
                {

                    if( value.ToString().StartsWith(' '))
                    {
                        MessageBox.Show("Błędne dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.LimitKredytu = null;
                        return;
                    }
                    item.LimitKredytu = value;
                    OnPropertyChanged(() => LimitKredytu);
                }
            }
        }
        public decimal? PozostalyLimit
        {
            get
            {
                if (LimitKredytu == null)
                {
                    return null;
                }
                if (SumaZaleglychNaleznosci == null)
                {
                    return item.LimitKredytu;
                }
                if ((LimitKredytu - SumaZaleglychNaleznosci) <= 0)
                {
                    item.BlokadaSprzedazy = true;
                }
                return LimitKredytu - SumaZaleglychNaleznosci;
            }
        }
        public bool? BlokadaSprzedazy
        {
            get
            {
                if (item.BlokadaSprzedazy == null)
                {
                    return item.BlokadaSprzedazy = false;
                }
                else
                {
                    return item.BlokadaSprzedazy;
                }
            }
            set
            {
                if (item.BlokadaSprzedazy != value)
                {
                    item.BlokadaSprzedazy = value;
                    OnPropertyChanged(() => BlokadaSprzedazy);
                }
            }
        }
        #endregion    
        #endregion
        #region Podmiot
        public bool? PodatnikVat
        {
            get
            {
                if(item.PodatnikVat == null)
                {
                    return PodatnikVat = true;
                }
                else
                {
                    return item.PodatnikVat;
                }
            }
            set
            {
                if(item.PodatnikVat != value)
                {
                    item.PodatnikVat= value;
                    OnPropertyChanged(() => PodatnikVat);
                }
            }
        }
        public int? IdStatus
        {
            get
            {
                return item.IdStatus;
            }
            set
            {
                if (item.IdStatus != value)
                {
                    item.IdStatus = value;
                    base.OnPropertyChanged(() => IdStatus);
                }
            }
        }

        private string? _Status;
        public string? Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }
        public int? IdFormaPrawna
        {
            get
            {
                return item.IdFormaPrawna;
            }
            set
            {
                if (item.IdFormaPrawna != value)
                {
                    item.IdFormaPrawna = value;
                    base.OnPropertyChanged(() => IdFormaPrawna);
                }
            }
        }
        private string? _FormaPrawna;
        public string? FormaPrawna
        {
            get
            {
                return _FormaPrawna;
            }
            set
            {
                if (_FormaPrawna != value)
                {
                    _FormaPrawna = value;
                    OnPropertyChanged(() => FormaPrawna);
                }
            }
        }
        public int? IdStatusMF
        {
            get
            {
                return item.IdStatusWbazieMf;
            }
            set
            {
                if (item.IdStatusWbazieMf != value)
                {
                    item.IdStatusWbazieMf = value;
                    base.OnPropertyChanged(() => IdStatusMF);
                }
            }
        }
        private string? _StatusWBazieMF;
        public string? StatusWBazieMF
        {
            get
            {
                return _StatusWBazieMF;
            }
            set
            {
                if(_StatusWBazieMF != value)
                {
                    _StatusWBazieMF = value;
                    OnPropertyChanged(() => StatusWBazieMF);
                }
            }
        }
        public int? IdStatusVIES
        {
            get
            {
                return item.IdStatusWbazieVies;
            }
            set
            {
                if (item.IdStatusWbazieVies != value)
                {
                    item.IdStatusWbazieVies = value;
                    base.OnPropertyChanged(() => IdStatusVIES);
                }
            }
        }
        private string? _StatusWBazieVIES;
        public string? StatusWBazieVIES
        {
            get
            {
                return _StatusWBazieVIES;
            }
            set
            {
                if (_StatusWBazieVIES != value)
                {
                    _StatusWBazieVIES = value;
                    OnPropertyChanged(() => StatusWBazieVIES);
                }
            }
        }
        public DateTime? DataAktualizacjiMF
        {
            get
            {
                if(item.DataAktualizacjiMf == null)
                {
                    return item.DataAktualizacjiMf = DateTime.Today;
                }
                return item.DataAktualizacjiMf;
            }
            set
            {
                if(item.DataAktualizacjiMf != value)
                {
                    item.DataAktualizacjiMf = value;
                    OnPropertyChanged(() => DataAktualizacjiMF);
                }
            }
        }
        public DateTime? DataAktualizacjiVIES
        {
            get
            {
                if (item.DataAktualizacjiVies == null)
                {
                    return item.DataAktualizacjiVies = DateTime.Today;
                }
                return item.DataAktualizacjiVies;
            }
            set
            {
                if(item.DataAktualizacjiVies != value)
                {
                    item.DataAktualizacjiVies = value;
                    OnPropertyChanged(() => DataAktualizacjiVIES);
                }
            }
        }
        #endregion
        #region DaneIdentyfikacyjne
        public string? Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if(item.Kod !=  value)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod);
                }
            }
        }
        public string? Nazwa
        {
            get
            {
                return item.Bazwa;
            }
            set
            {
                if (item.Bazwa != value)
                {
                    if(value.StartsWith(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Bazwa = null;
                        return;
                    }
                    if(value.Length <= 3)
                    {
                        MessageBox.Show("Zbyt krótka nazwa", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Bazwa = null;
                        return;
                    }
                    item.Bazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string? Nip
        {
            get
            {
                return item.Nip;
            }
            set
            {
                if (item.Nip != value)
                {
                    if (value.Length != 10)
                    {
                        MessageBox.Show("Błędna ilośc znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Nip = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Nip = null;
                        return;
                    }
                    item.Nip = value;
                    OnPropertyChanged(() => Nip);
                }
            }
        }
        public string? Pesel
        {
            get
            {
                return item.Pesel;
            }
            set
            {
                if (item.Pesel != value)
                {
                    if (value.Length != 11)
                    {
                        MessageBox.Show("Błędna ilośc znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Pesel = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Pesel = null;
                        return;
                    }
                    item.Pesel = value;
                    OnPropertyChanged(() => Pesel);
                }
            }
        }
        public string? Regon
        {
            get
            {
                return item.Regon;
            }
            set
            {
                if (item.Regon != value)
                {
                    if (value.Length != 9)
                    {
                        MessageBox.Show("Błędna ilośc znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Regon = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Regon = null;
                        return;
                    }
                    item.Regon = value;
                    OnPropertyChanged(() => Regon);
                }
            }
        }
        public string? Krs
        {
            get
            {
                return item.Krs;
            }
            set
            {
                if (item.Krs != value)
                {
                    if (value.Length != 11)
                    {
                        MessageBox.Show("Błędna ilośc znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Krs = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Krs = null;
                        return;
                    }
                    item.Krs = value;
                    OnPropertyChanged(() => Krs);
                }
            }
        }
        public string? GlnIln
        {
            get
            {
                return item.GlnIln;
            }
            set
            {
                if (item.GlnIln != value)
                {
                    if (value.Length != 13)
                    {
                        MessageBox.Show("Błędna ilośc znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.GlnIln = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.GlnIln = null;
                        return;
                    }
                    item.GlnIln = value;
                    OnPropertyChanged(() => GlnIln);
                }
            }
        }
        public string? StronaWww
        {
            get
            {
                return item.StronaWww;
            }
            set
            {
                if (item.StronaWww != value)
                {
                    if (value.StartsWith('.'))
                    {
                        MessageBox.Show("Błędny znak początkowy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.StronaWww = null;
                        return;
                    }
                    if (value.Contains(' '))
                    {
                        MessageBox.Show("Użyto biały znak", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.StronaWww = null;
                        return;
                    }
                    if(!(value.Contains(".www"))) 
                    {
                        MessageBox.Show("Błędny adres strony", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.StronaWww = null;
                        return;
                    }
                    item.StronaWww = value;
                    OnPropertyChanged(() => StronaWww);
                }
            }
        }
        #endregion
        #region Adresy
        #region AdresZameldowania
        public int? IdAdresZameldowania
        {
            get
            {
                return item.IdAdresuZameldowania;
            }
            set
            {
                if (item.IdAdresuZameldowania != value)
                {
                    item.IdAdresuZameldowania = value;
                    OnPropertyChanged(() => IdAdresZameldowania);
                }
            }
        }

        private string? _AdresZameldowaniaNazwaKraju;
        public string? AdresZameldowaniaNazwaKraju
        {
            get
            {
                return _AdresZameldowaniaNazwaKraju;
            }
            set
            {
                if (_AdresZameldowaniaNazwaKraju != value)
                {
                    _AdresZameldowaniaNazwaKraju = value;
                    OnPropertyChanged(() => AdresZameldowaniaNazwaKraju);
                }
            }
        }
        private string? _AdresZameldowaniaNazwaWojewodztwa;
        public string? AdresZameldowaniaNazwaWojewodztwa
        {
            get
            {
                return _AdresZameldowaniaNazwaWojewodztwa;
            }
            set
            {
                if (_AdresZameldowaniaNazwaWojewodztwa != value)
                {
                    _AdresZameldowaniaNazwaWojewodztwa = value;
                    OnPropertyChanged(() => AdresZameldowaniaNazwaWojewodztwa);
                }
            }
        }
        private string? _AdresZameldowaniaNazwaMiejscowosci;
        public string? AdresZameldowaniaNazwaMiejscowosci
        {
            get
            {
                return _AdresZameldowaniaNazwaMiejscowosci;
            }
            set
            {
                if (_AdresZameldowaniaNazwaMiejscowosci != value)
                {
                    _AdresZameldowaniaNazwaMiejscowosci = value;
                    OnPropertyChanged(() => AdresZameldowaniaNazwaMiejscowosci);
                }
            }
        }
        private string? _AdresZameldowaniaNazwaPowiatu;
        public string? AdresZameldowaniaNazwaPowiatu
        {
            get
            {
                return _AdresZameldowaniaNazwaPowiatu;
            }
            set
            {
                if (_AdresZameldowaniaNazwaPowiatu != value)
                {
                    _AdresZameldowaniaNazwaPowiatu = value;
                    OnPropertyChanged(() => AdresZameldowaniaNazwaPowiatu);
                }
            }
        }
        private string? _AdresZameldowaniaKodGminy;
        public string? AdresZameldowaniaKodGminy
        {
            get
            {
                return _AdresZameldowaniaKodGminy;
            }
            set
            {
                if (_AdresZameldowaniaKodGminy != value)
                {
                    _AdresZameldowaniaKodGminy = value;
                    OnPropertyChanged(() => AdresZameldowaniaKodGminy);
                }
            }
        }
        private string? _AdresZameldowaniaUlica;
        public string? AdresZameldowaniaUlica
        {
            get
            {
                return _AdresZameldowaniaUlica;
            }
            set
            {
                if (_AdresZameldowaniaUlica != value)
                {
                    _AdresZameldowaniaUlica = value;
                    OnPropertyChanged(() => AdresZameldowaniaUlica);
                }
            }
        }
        private string? _AdresZameldowaniaNumerDomu;
        public string? AdresZameldowaniaNumerDomu
        {
            get
            {
                return _AdresZameldowaniaNumerDomu;
            }
            set
            {
                if (_AdresZameldowaniaNumerDomu != value)
                {
                    _AdresZameldowaniaNumerDomu = value;
                    OnPropertyChanged(() => AdresZameldowaniaNumerDomu);
                }
            }
        }
        private string? _AdresZameldowaniaNumerLokalu;
        public string? AdresZameldowaniaNumerLokalu
        {
            get
            {
                return _AdresZameldowaniaNumerLokalu;
            }
            set
            {
                if (_AdresZameldowaniaNumerLokalu != value)
                {
                    _AdresZameldowaniaNumerLokalu = value;
                    OnPropertyChanged(() => AdresZameldowaniaNumerLokalu);
                }
            }
        }
        private string? _AdresZameldowaniaKodPocztowy;
        public string? AdresZameldowaniaKodPocztowy
        {
            get
            {
                return _AdresZameldowaniaKodPocztowy;
            }
            set
            {
                if (_AdresZameldowaniaKodPocztowy != value)
                {
                    _AdresZameldowaniaKodPocztowy = value;
                    OnPropertyChanged(() => AdresZameldowaniaKodPocztowy);
                }
            }
        }
        private string? _AdresZameldowaniaTelefon;
        public string? AdresZameldowaniaTelefon
        {
            get
            {
                return _AdresZameldowaniaTelefon;
            }
            set
            {
                if (_AdresZameldowaniaTelefon != value)
                {
                    _AdresZameldowaniaTelefon = value;
                    OnPropertyChanged(() => AdresZameldowaniaTelefon);
                }
            }
        }
        private string? _AdresZameldowaniaTelefonSms;
        public string? AdresZameldowaniaTelefonSms
        {
            get
            {
                return _AdresZameldowaniaTelefonSms;
            }
            set
            {
                if (_AdresZameldowaniaTelefonSms != value)
                {
                    _AdresZameldowaniaTelefonSms = value;
                    OnPropertyChanged(() => AdresZameldowaniaTelefonSms);
                }
            }
        }
        private string? _AdresZameldowaniaEmail;
        public string? AdresZameldowaniaEmail
        {
            get
            {
                return _AdresZameldowaniaEmail;
            }
            set
            {
                if (_AdresZameldowaniaEmail != value)
                {
                    _AdresZameldowaniaEmail = value;
                    OnPropertyChanged(() => AdresZameldowaniaEmail);
                }
            }
        }
        #endregion
        #region AdresDoKorespondencji
        public int? IdAdresDoKorespondencji
        {
            get
            {
                return item.IdAdresuDoKorespondencji;
            }
            set
            {
                if (item.IdAdresuDoKorespondencji != value)
                {
                    item.IdAdresuDoKorespondencji = value;
                    OnPropertyChanged(() => IdAdresDoKorespondencji);
                }
            }
        }

        private string? _AdresDoKorespondencjiNazwaKraju;
        public string? AdresDoKorespondencjiNazwaKraju
        {
            get
            {
                return _AdresDoKorespondencjiNazwaKraju;
            }
            set
            {
                if (_AdresDoKorespondencjiNazwaKraju != value)
                {
                    _AdresDoKorespondencjiNazwaKraju = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiNazwaKraju);
                }
            }
        }
        private string? _AdresDoKorespondencjiNazwaWojewodztwa;
        public string? AdresDoKorespondencjiNazwaWojewodztwa
        {
            get
            {
                return _AdresDoKorespondencjiNazwaWojewodztwa;
            }
            set
            {
                if (_AdresDoKorespondencjiNazwaWojewodztwa != value)
                {
                    _AdresDoKorespondencjiNazwaWojewodztwa = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiNazwaWojewodztwa);
                }
            }
        }
        private string? _AdresDoKorespondencjiNazwaMiejscowosci;
        public string? AdresDoKorespondencjiNazwaMiejscowosci
        {
            get
            {
                return _AdresDoKorespondencjiNazwaMiejscowosci;
            }
            set
            {
                if (_AdresDoKorespondencjiNazwaMiejscowosci != value)
                {
                    _AdresDoKorespondencjiNazwaMiejscowosci = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiNazwaMiejscowosci);
                }
            }
        }
        private string? _AdresDoKorespondencjiNazwaPowiatu;
        public string? AdresDoKorespondencjiNazwaPowiatu
        {
            get
            {
                return _AdresDoKorespondencjiNazwaPowiatu;
            }
            set
            {
                if (_AdresDoKorespondencjiNazwaPowiatu != value)
                {
                    _AdresDoKorespondencjiNazwaPowiatu = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiNazwaPowiatu);
                }
            }
        }
        private string? _AdresDoKorespondencjiKodGminy;
        public string? AdresDoKorespondencjiKodGminy
        {
            get
            {
                return _AdresDoKorespondencjiKodGminy;
            }
            set
            {
                if (_AdresDoKorespondencjiKodGminy != value)
                {
                    _AdresDoKorespondencjiKodGminy = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiKodGminy);
                }
            }
        }
        private string? _AdresDoKorespondencjiUlica;
        public string? AdresDoKorespondencjiUlica
        {
            get
            {
                return _AdresDoKorespondencjiUlica;
            }
            set
            {
                if (_AdresDoKorespondencjiUlica != value)
                {
                    _AdresDoKorespondencjiUlica = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiUlica);
                }
            }
        }
        private string? _AdresDoKorespondencjiNumerDomu;
        public string? AdresDoKorespondencjiNumerDomu
        {
            get
            {
                return _AdresDoKorespondencjiNumerDomu;
            }
            set
            {
                if (_AdresDoKorespondencjiNumerDomu != value)
                {
                    _AdresDoKorespondencjiNumerDomu = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiNumerDomu);
                }
            }
        }
        private string? _AdresDoKorespondencjiNumerLokalu;
        public string? AdresDoKorespondencjiNumerLokalu
        {
            get
            {
                return _AdresDoKorespondencjiNumerLokalu;
            }
            set
            {
                if (_AdresDoKorespondencjiNumerLokalu != value)
                {
                    _AdresDoKorespondencjiNumerLokalu = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiNumerLokalu);
                }
            }
        }
        private string? _AdresDoKorespondencjiKodPocztowy;
        public string? AdresDoKorespondencjiKodPocztowy
        {
            get
            {
                return _AdresDoKorespondencjiKodPocztowy;
            }
            set
            {
                if (_AdresDoKorespondencjiKodPocztowy != value)
                {
                    _AdresDoKorespondencjiKodPocztowy = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiKodPocztowy);
                }
            }
        }
        private string? _AdresDoKorespondencjiTelefon;
        public string? AdresDoKorespondencjiTelefon
        {
            get
            {
                return _AdresDoKorespondencjiTelefon;
            }
            set
            {
                if (_AdresDoKorespondencjiTelefon != value)
                {
                    _AdresDoKorespondencjiTelefon = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiTelefon);
                }
            }
        }
        private string? _AdresDoKorespondencjiTelefonSms;
        public string? AdresDoKorespondencjiTelefonSms
        {
            get
            {
                return _AdresDoKorespondencjiTelefonSms;
            }
            set
            {
                if (_AdresDoKorespondencjiTelefonSms != value)
                {
                    _AdresDoKorespondencjiTelefonSms = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiTelefonSms);
                }
            }
        }
        private string? _AdresDoKorespondencjiEmail;
        public string? AdresDoKorespondencjiEmail
        {
            get
            {
                return _AdresDoKorespondencjiEmail;
            }
            set
            {
                if (_AdresDoKorespondencjiEmail != value)
                {
                    _AdresDoKorespondencjiEmail = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiEmail);
                }
            }
        }
        #endregion
        #region PolePodAdresami
        private bool? _AdresDoKorespondencjiInnyNizAdresZameldowania;
        public bool? AdresDoKorespondencjiInnyNizAdresZameldowania
        {
            get
            {
                if(_AdresDoKorespondencjiInnyNizAdresZameldowania == null)
                {
                    _AdresDoKorespondencjiInnyNizAdresZameldowania = false;
                }
                return _AdresDoKorespondencjiInnyNizAdresZameldowania;
            }
            set
            {
                if (_AdresDoKorespondencjiInnyNizAdresZameldowania != value)
                {
                    PrzywrocAdresDoKorespondencjiDoStanyPoczatkowego();
                    _AdresDoKorespondencjiInnyNizAdresZameldowania = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiInnyNizAdresZameldowania);
                }
            }
        }
        #endregion
        #endregion
        #region WarunkiHandlowe
        public int? IdDefinicjaPlatnosci
        {
            get
            {
                return item.IdDefinicjaPlatnosci;
            }
            set
            {
                if(item.IdDefinicjaPlatnosci != value)
                {
                    item.IdDefinicjaPlatnosci = value;
                    OnPropertyChanged(() => IdDefinicjaPlatnosci);
                }
            }
        }
        private string? _DefinicjaPlatnosciNazwa;
        public string? DefinicjaPlatnosciNazwa
        {
            get
            {
                return _DefinicjaPlatnosciNazwa;
            }
            set
            {
                if(_DefinicjaPlatnosciNazwa != value)
                {
                    _DefinicjaPlatnosciNazwa = value;
                    OnPropertyChanged(() => DefinicjaPlatnosciNazwa);
                }
            }
        }
        //Chwilowo poza użytkiem, możliwe przeniesienie do tabeli/klasy Definicja Płatności
        //public int? TerminDomyslny
        //{
        //    get
        //    {
        //        return item.Termin;
        //    }
        //    set
        //    {
        //        if(item.Termin != value)
        //        {
        //            item.Termin = value;
        //            OnPropertyChanged(() => TerminDomyslny);
        //        }
        //    }
        //}
        public int? IdWaluta
        {
            get
            {
                return item.IdWaluta;
            }
            set
            {
                if(item.IdWaluta != value)
                {
                    item.IdWaluta = value;
                    OnPropertyChanged(() => IdWaluta);
                }
            }
        }
        public IQueryable<Walutum> WalutaComboBoxItems
        {
            get
            {
                return(
                    from w in firmaSpawalniczaEntities.Waluta
                    select w
                    ).ToList().AsQueryable();
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
                if(item.Opis != value)
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
