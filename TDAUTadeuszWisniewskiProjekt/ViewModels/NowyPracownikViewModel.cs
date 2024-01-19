using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Input.Manipulations;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
   
    public class NowyPracownikViewModel : JedenViewModel<Pracownik>
    {
        #region Command
        private BaseCommand _ShowAdresyZameldowaniaCommand;
        public ICommand ShowAdresyZameldowaniaCommand
        {
            get
            {
                if (_ShowAdresyZameldowaniaCommand == null)
                {
                    _ShowAdresyZameldowaniaCommand = new BaseCommand(() => Messenger.Default.Send("Adresy ZameldowaniaShow"));
                }
                return _ShowAdresyZameldowaniaCommand;
            }
        }
        private BaseCommand _ShowAdresyDoKorespondencjiCommand;
        public ICommand ShowAdresyDoKorespondencjiCommand
        {
            get
            {
                if (_ShowAdresyDoKorespondencjiCommand == null)
                {
                    _ShowAdresyDoKorespondencjiCommand = new BaseCommand(() => Messenger.Default.Send("Adresy do korespondencjiShow"));
                }
                return _ShowAdresyDoKorespondencjiCommand;
            }
        }
        private BaseCommand _ShowJednostkiOrganizacyjneCommand;
        public ICommand ShowJednostkiOrganizacyjneCommand
        {
            get
            {
                if (_ShowJednostkiOrganizacyjneCommand == null)
                {
                    _ShowJednostkiOrganizacyjneCommand = new BaseCommand(() => Messenger.Default.Send("Jednostki organizacyjneShow"));
                }
                return _ShowJednostkiOrganizacyjneCommand;
            }
        }
        private BaseCommand _ShowPodstawyZatrudnieniaCommand;
        public ICommand ShowPodstawyZatrudnieniaCommand
        {
            get
            {
                if (_ShowPodstawyZatrudnieniaCommand == null)
                {
                    _ShowPodstawyZatrudnieniaCommand = new BaseCommand(() => Messenger.Default.Send("Podstawy zatrudnieniaShow"));
                }
                return _ShowPodstawyZatrudnieniaCommand;
            }
        }
        private BaseCommand _ShowTypUmowyOPraceCommand;
        public ICommand ShowTypUmowyOPraceCommand
        {
            get
            {
                if (_ShowTypUmowyOPraceCommand == null)
                {
                    _ShowTypUmowyOPraceCommand = new BaseCommand(() => Messenger.Default.Send("Typy umów o praceShow"));
                }
                return _ShowTypUmowyOPraceCommand;
            }
        }
        private BaseCommand _ShowStanowiskaCommand;
        public ICommand ShowStanowiskaCommand
        {
            get
            {
                if (_ShowStanowiskaCommand == null)
                {
                    _ShowStanowiskaCommand = new BaseCommand(() => Messenger.Default.Send("StanowiskaShow"));
                }
                return _ShowStanowiskaCommand;
            }
        }
        private BaseCommand _ShowWymiarEtatuCommand;
        public ICommand ShowWymiarEtatuCommand
        {
            get
            {
                if (_ShowWymiarEtatuCommand == null)
                {
                    _ShowWymiarEtatuCommand = new BaseCommand(() => Messenger.Default.Send("Wymiar etatuShow"));
                }
                return _ShowWymiarEtatuCommand;
            }
        }
        private BaseCommand _ShowTypStawkiCommand;
        public ICommand ShowTypStawkiCommand
        {
            get
            {
                if (_ShowTypStawkiCommand == null)
                {
                    _ShowTypStawkiCommand = new BaseCommand(() => Messenger.Default.Send("Typy stawekShow"));
                }
                return _ShowTypStawkiCommand;
            }
        }
        private BaseCommand _ShowMiejscaUrodzeniaCommand;
        public ICommand ShowMiejscaUrodzeniaCommand
        {
            get
            {
                if (_ShowMiejscaUrodzeniaCommand == null)
                {
                    _ShowMiejscaUrodzeniaCommand = new BaseCommand(() => Messenger.Default.Send("Miejsca urodzeniaShow"));
                }
                return _ShowMiejscaUrodzeniaCommand;
            }
        }
        #endregion
        #region Konstruktor
        public NowyPracownikViewModel()
            : base("Pracownik")
        {
            item = new Pracownik();

            _DataUtworzenia = DateTime.Now;

            //ten messanger oczekuje na przesłanie wybranego kontrahenta z okna wszyscy kontrahenci i po złapaniu tego kontrahenta uruchamia get wybrany kontrahent
            //ten messanger oczekuje na przesłanie wybranego kontrahenta z okna wszyscy kontrahenci i po złapaniu tego kontrahenta uruchamia get wybrany kontrahent
            Messenger.Default.Register<AdresZameldowaniaForView>(this, getWybranyAdresZameldowania);
            Messenger.Default.Register<AdresDoKorespondencjiForView>(this, getWybranyAdresDoKorespondencji);

            Messenger.Default.Register<JednostkaOrganizacyjnaForView>(this, getWybranaJednostkaOrganizacyjna);
            Messenger.Default.Register<PodstawaZatrudnieniaForView>(this, getWybranaPodstawaZatrudnienia);
            Messenger.Default.Register<TypyUmowOPraceForView>(this, getWybranyTypUmowyOPrace);
            Messenger.Default.Register<StanowiskoForView>(this, getWybraneStanowisko);
            Messenger.Default.Register<WymiarEtatuForView>(this, getWybranyWymiarEtatu);
            Messenger.Default.Register<TypStawkiForView>(this, getWybranyTypStawki);
            Messenger.Default.Register<MiejsceUrodzeniaForView>(this, getWybraneMiejsceUrodzenia);
        }
        #endregion
        #region Metody
        private void getWybranyAdresZameldowania(AdresZameldowaniaForView adr)
        {
            IdAdresZameldowania = adr.Id;
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
        private void getWybranaJednostkaOrganizacyjna(JednostkaOrganizacyjnaForView j)
        {
            IdJednostkaOrganizacyjna = j.Id;
            NazwaJednostkaOrganizacyjna = j.NazwaJednostkiOrganizacyjnej;
        }
        private void getWybranaPodstawaZatrudnienia(PodstawaZatrudnieniaForView p)
        {
            IdPodstawaZatrudnienia=p.Id;
            NazwaPodstawaZatrudnienia = p.Nazwa;
        }
        private void getWybranyTypUmowyOPrace(TypyUmowOPraceForView t)
        {
            IdTypUmowyOPrace=t.Id;
            NazwaTypUmowyOPrace = t.Nazwa;
        }
        private void getWybraneStanowisko(StanowiskoForView s)
        {
            IdStanowisko=s.Id;
            NazwaStanowisko = s.Nazwa;
        }
        private void getWybranyWymiarEtatu(WymiarEtatuForView w)
        {
            IdWymiarEtatu=w.Id;
            NazwaWymiarEtatu=w.Nazwa;
        }
        private void getWybranyTypStawki(TypStawkiForView t)
        {
            IdTypStawki = t.Id;
            NazwaTypStawki=t.Nazwa;
        }
        private void getWybraneMiejsceUrodzenia(MiejsceUrodzeniaForView m)
        {
            IdMiejsceUrodzenia = m.Id;
            NazwaMiejsceUrodzenia = m.NazwaMiejscowosci;
        }
        #endregion
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
                if (item.KiedyZmieniono != DateTime.Now)
                {
                    item.KiedyZmieniono = DateTime.Now;
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
                    return false;
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
        #region Adresy
        #region AdresZameldowania
        public int? IdAdresZameldowania
        {
            get
            {
                return item.IdAdresuZamieszkania;
            }
            set
            {
                if (item.IdAdresuZamieszkania != value)
                {
                    item.IdAdresuZamieszkania = value;
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
                return item.IdAdresuKorespondencji;
            }
            set
            {
                if (item.IdAdresuKorespondencji != value)
                {
                    item.IdAdresuKorespondencji = value;
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
        private bool? _AdresDoKorespondencjiInnyNizAdresZameldowania = false;
        public bool? AdresDoKorespondencjiInnyNizAdresZameldowania
        {
            get
            {
                return _AdresDoKorespondencjiInnyNizAdresZameldowania;
            }
            set
            {
                if (_AdresDoKorespondencjiInnyNizAdresZameldowania != value)
                {
                    _AdresDoKorespondencjiInnyNizAdresZameldowania = value;
                    OnPropertyChanged(() => AdresDoKorespondencjiInnyNizAdresZameldowania);
                }
            }
        }
        #endregion
        #endregion
        #region UmowaOPrace
        public int? IdJednostkaOrganizacyjna
        {
            get
            {
                return item.IdJednostkaOrganizacyjna;
            }
            set
            {
                if(item.IdJednostkaOrganizacyjna != value)
                {
                    item.IdJednostkaOrganizacyjna = value;
                    OnPropertyChanged(() => IdJednostkaOrganizacyjna);
                }
            }
        }
        public string? _NazwaJednostkaOrganizacyjna;
        public string? NazwaJednostkaOrganizacyjna
        {
            get
            {
                return _NazwaJednostkaOrganizacyjna;
            }
            set
            {
                if(_NazwaJednostkaOrganizacyjna != value)
                {
                    _NazwaJednostkaOrganizacyjna = value;
                    OnPropertyChanged(() => NazwaJednostkaOrganizacyjna);
                }
            }
        }
        public int? IdPodstawaZatrudnienia
        {
            get
            {
                return item.IdPodstawyZatrudnienia;
            }
            set
            {
                if (item.IdPodstawyZatrudnienia != value)
                {
                    item.IdPodstawyZatrudnienia = value;
                    OnPropertyChanged(() => IdPodstawaZatrudnienia);
                }
            }
        }
        public string? _NazwaPodstawaZatrudnienia;
        public string? NazwaPodstawaZatrudnienia
        {
            get
            {
                return _NazwaPodstawaZatrudnienia;
            }
            set
            {
                if (_NazwaPodstawaZatrudnienia != value)
                {
                    _NazwaPodstawaZatrudnienia = value;
                    OnPropertyChanged(() => NazwaPodstawaZatrudnienia);
                }
            }
        }
        public int? IdTypUmowyOPrace
        {
            get
            {
                return item.IdTypUmowyOprace;
            }
            set
            {
                if (item.IdTypUmowyOprace != value)
                {
                    item.IdTypUmowyOprace = value;
                    OnPropertyChanged(() => IdTypUmowyOPrace);
                }
            }
        }
        public string? _NazwaTypUmowyOPrace;
        public string? NazwaTypUmowyOPrace
        {
            get
            {
                return _NazwaTypUmowyOPrace;
            }
            set
            {
                if (_NazwaTypUmowyOPrace != value)
                {
                    _NazwaTypUmowyOPrace = value;
                    OnPropertyChanged(() => NazwaTypUmowyOPrace);
                }
            }
        }
        public int? IdStanowisko
        {
            get
            {
                return item.IdStanowisko;
            }
            set
            {
                if (item.IdStanowisko != value)
                {
                    item.IdStanowisko = value;
                    OnPropertyChanged(() => IdStanowisko);
                }
            }
        }
        public string? _NazwaStanowisko;
        public string? NazwaStanowisko
        {
            get
            {
                return _NazwaStanowisko;
            }
            set
            {
                if (_NazwaStanowisko != value)
                {
                    _NazwaStanowisko = value;
                    OnPropertyChanged(() => NazwaStanowisko);
                }
            }
        }
        public DateTime? DataZawarciaUmowy
        {
            get
            {
                if(item.DataZawarciaUmowy == null)
                {
                    item.DataZawarciaUmowy = DateTime.Today;
                    return item.DataZawarciaUmowy;
                }
                else
                {
                    return item.DataZawarciaUmowy;
                }
            }
            set
            {
                if(item.DataZawarciaUmowy != value)
                {
                    item.DataZawarciaUmowy = value;
                    OnPropertyChanged(() => DataZawarciaUmowy);
                }
            }
        }
        public int? IdWymiarEtatu
        {
            get
            {
                return item.IdWymiaruEtatu;
            }
            set
            {
                if (item.IdWymiaruEtatu != value)
                {
                    item.IdWymiaruEtatu = value;
                    OnPropertyChanged(() => IdWymiarEtatu);
                }
            }
        }
        public string? _NazwaWymiarEtatu;
        public string? NazwaWymiarEtatu
        {
            get
            {
                return _NazwaWymiarEtatu;
            }
            set
            {
                if (_NazwaWymiarEtatu != value)
                {
                    _NazwaWymiarEtatu = value;
                    OnPropertyChanged(() => NazwaWymiarEtatu);
                }
            }
        }
        public int? IdTypStawki
        {
            get
            {
                return item.IdTypStawki;
            }
            set
            {
                if (item.IdTypStawki != value)
                {
                    item.IdTypStawki = value;
                    OnPropertyChanged(() => IdTypStawki);
                }
            }
        }
        public string? _NazwaTypStawki;
        public string? NazwaTypStawki
        {
            get
            {
                return _NazwaTypStawki;
            }
            set
            {
                if (_NazwaTypStawki != value)
                {
                    _NazwaTypStawki = value;
                    OnPropertyChanged(() => NazwaTypStawki);
                }
            }
        }
        public decimal? Stawka
        {
            get
            {
                return item.Stawka;
            }
            set
            {
                if(item.Stawka != value)
                {
                    item.Stawka = value;
                    OnPropertyChanged(() => Stawka);
                }
            }
        }
        #endregion
        #region DanePersonalne
        public string? Akronim
        {
            get
            {
                return item.Akronim;
            }
            set
            {
                if (item.Akronim != value)
                {
                    item.Akronim = value;
                    OnPropertyChanged(() => Akronim);
                }
            }
        }
        public string? Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string? Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }        
        public string? DrugieImie
        {
            get
            {
                return item.DrugieImie;
            }
            set
            {
                if (item.DrugieImie != value)
                {
                    item.DrugieImie = value;
                    OnPropertyChanged(() => DrugieImie);
                }
            }
        }
        public string? NazwiskoRodowe
        {
            get
            {
                return item.NazwiskoRodowe;
            }
            set
            {
                if (item.NazwiskoRodowe != value)
                {
                    item.NazwiskoRodowe = value;
                    OnPropertyChanged(() => NazwiskoRodowe);
                }
            }
        }
        public string? ImieMatki
        {
            get
            {
                return item.ImieMatki;
            }
            set
            {
                if (item.ImieMatki != value)
                {
                    item.ImieMatki = value;
                    OnPropertyChanged(() => ImieMatki);
                }
            }
        }
        public string? NazwiskoRodoweMatki
        {
            get
            {
                return item.NazwiskoRodoweMatki;
            }
            set
            {
                if (item.NazwiskoRodoweMatki != value)
                {
                    item.NazwiskoRodoweMatki = value;
                    OnPropertyChanged(() => NazwiskoRodoweMatki);
                }
            }
        }
        public DateTime? DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                if (item.DataUrodzenia != value)
                {
                    item.DataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
                }
            }
        }
        public string? ImieOjca
        {
            get
            {
                return item.ImieOjca;
            }
            set
            {
                if (item.ImieOjca != value)
                {
                    item.ImieOjca = value;
                    OnPropertyChanged(() => ImieOjca);
                }
            }
        }
        public int? IdMiejsceUrodzenia
        {
            get
            {
                return item.IdMiejsceUrodzenia;
            }
            set
            {
                if (item.IdMiejsceUrodzenia != value)
                {
                    item.IdMiejsceUrodzenia = value;
                    OnPropertyChanged(() => IdMiejsceUrodzenia);
                }
            }
        }
        private string? _NazwaMiejsceUrodzenia;
        public string? NazwaMiejsceUrodzenia
        {
            get
            {
                return _NazwaMiejsceUrodzenia;
            }
            set
            {
                if(_NazwaMiejsceUrodzenia != value)
                {
                    _NazwaMiejsceUrodzenia = value;
                    OnPropertyChanged(() => NazwaMiejsceUrodzenia);
                }
            }
        }
        private bool? _IdentyfikacjaPodatkowaOpcja1 = true;
        public bool? IdentyfikacjaPodatkowaOpcja1
        {
            get
            {
                //if(_IdentyfikacjaPodatkowaOpcja1 == null)
                //{
                //    _IdentyfikacjaPodatkowaOpcja1 = true;
                //}
                return _IdentyfikacjaPodatkowaOpcja1;
            }
            set
            {
                if(_IdentyfikacjaPodatkowaOpcja1 != value)
                {
                    _IdentyfikacjaPodatkowaOpcja1 = value;
                    OnPropertyChanged(() => IdentyfikacjaPodatkowaOpcja1);
                }
            }
        }
        private bool? _IdentyfikacjaPodatkowaOpcja2 = false;
        public bool? IdentyfikacjaPodatkowaOpcja2
        {
            get
            {
                //if (_IdentyfikacjaPodatkowaOpcja2 == null)
                //{
                //    _IdentyfikacjaPodatkowaOpcja2 = false;
                //}
                return _IdentyfikacjaPodatkowaOpcja2;
            }
            set
            {
                if (_IdentyfikacjaPodatkowaOpcja2 != value)
                {
                    _IdentyfikacjaPodatkowaOpcja2 = value;
                    OnPropertyChanged(() => IdentyfikacjaPodatkowaOpcja2);
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
                    item.Pesel = value;
                    OnPropertyChanged(() => Pesel);
                }
            }
        }

        public int? IdTypNIP
        {
            get
            {
                return item.IdTypNip;
            }
            set
            {
                if (item.IdTypNip != value)
                {
                    item.IdTypNip = value;
                    OnPropertyChanged(() => IdTypNIP);
                }
            }
        }
        public IQueryable<TypNip> TypNipComboBoxItems
        {
            get
            {
                return
                    (
                    from TypNip in firmaSpawalniczaEntities.TypNips
                    select TypNip
                    ).ToList().AsQueryable();
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
                    item.Nip = value;
                    OnPropertyChanged(() => Nip);
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
