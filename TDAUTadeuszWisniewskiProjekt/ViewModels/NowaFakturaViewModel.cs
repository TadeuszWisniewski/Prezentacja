using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.VisualBasic;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;
using Microsoft.Win32;
using TDAUTadeuszWisniewskiProjekt.Models.Validatory;
using TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    
    public class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        #region Commands
        private BaseCommand _ShowKontrahenciCommand;
        public ICommand ShowKontrahenciCommand
        {
            get
            {
                if (_ShowKontrahenciCommand == null)
                {
                    _ShowKontrahenciCommand = new BaseCommand(() => Messenger.Default.Send("KontrahenciShow"));
                }
                return _ShowKontrahenciCommand;
            }
        }
        private BaseCommand _ShowTowaryCommand;
        public ICommand ShowTowaryCommand
        {
            get
            {
                if (_ShowTowaryCommand == null)
                {
                    _ShowTowaryCommand = new BaseCommand(() => Messenger.Default.Send("TowaryShow"));
                }
                return _ShowTowaryCommand;
            }
        }
        private BaseCommand _DodajCommand;
        public ICommand DodajCommand
        {
            get
            {
                if (_DodajCommand == null)
                {
                    _DodajCommand = new BaseCommand(() => DodajDoListy());
                } 
                return _DodajCommand;
            }
        }
        private BaseCommand _ClearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_ClearCommand == null)
                {
                    _ClearCommand = new BaseCommand(() => WyczyscListe());
                }
                
                return _ClearCommand;
            }
        }
        private BaseCommand _ObliczCenePoczatkowaCommand;
        public ICommand ObliczCenePoczatkowaCommand
        {
            get
            {
                if (_ObliczCenePoczatkowaCommand == null)
                {
                    _ObliczCenePoczatkowaCommand = new BaseCommand(() => ObliczCenaPoczatkowa());
                }
                return _ObliczCenePoczatkowaCommand;
            }
        }
        private BaseCommand _ObliczCeneKoncowaCommand;
        public ICommand ObliczCeneKoncowaCommand
        {
            get
            {
                if (_ObliczCeneKoncowaCommand == null)
                {
                    _ObliczCeneKoncowaCommand = new BaseCommand(() => ObliczCenaKoncowa());
                }
                return _ObliczCeneKoncowaCommand;
            }
        }
        #endregion
        #region Konstruktor
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            item = new Faktura();
            _DataUtworzenia = DateTime.Today;
            fakturaB = new FakturaB(firmaSpawalniczaEntities);

            Messenger.Default.Register<KontrahentForView>(this, getWybranyKontrahent);
            Messenger.Default.Register<TowarForView>(this, getWybranyTowar);
        }
        #endregion
        #region Kolekcje  
        private ObservableCollection<PozycjaNaFakturzeForView> _ListaPozycjiFaktury = new ObservableCollection<PozycjaNaFakturzeForView>();
        public ObservableCollection<PozycjaNaFakturzeForView> ListaPozycjiFaktury
        {
            get
            {
                return _ListaPozycjiFaktury;
            }
            set
            {
                _ListaPozycjiFaktury = value;
                OnPropertyChanged(() => ListaPozycjiFaktury);
            }
        }
        #endregion
        #region Metody
        private void getWybranyKontrahent(KontrahentForView k)
        {
            if (k.Aktywny == false)
            {
                MessageBox.Show("Wybrany kontrahent nie jest aktywny", "Błędny kontrahent", MessageBoxButton.OK, MessageBoxImage.Error);
                IdKontrahenta = null;
                KontrahentNazwa = null;
                return;
            }
            if(k.BlokadaSprzedazy == true)
            {
                MessageBox.Show("Wybrany kontrahent jest zablokowany dla sprzedazy", "Błędny kontrahent", MessageBoxButton.OK, MessageBoxImage.Error);
                IdKontrahenta = null;
                KontrahentNazwa = null;
                return;
            }
            IdKontrahenta = k.Id;
            KontrahentNazwa = k.Bazwa;
            //KontrahentPodatnikVat = k.PodatnikVat;//chwilowo bez zastosowania
        }
        private void getWybranyTowar(TowarForView t)
        {
            //Sprawdzam, czy wybrany towar jest aktywny
            if(t.Aktywny == false || t.Blokada == true)
            {
                MessageBox.Show("Wybrany towar nie jest aktywny", "Błędny towar", MessageBoxButton.OK, MessageBoxImage.Error);
                IdTowar = null;
                NazwaTowar = null;
                CenaTowar = null;
                return;
            }
            IdTowar = t.Id;
            NazwaTowar = t.Nazwa;
            CenaTowar = t.CenaKoncowa;
        }
        private void DodajDoListy()
        {
            if(Ilosc == null && CenaTowar == null)
            {
                MessageBox.Show("Wprowadź dane", "Brak danych", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Ilosc == null || Ilosc == 0)
            {
                MessageBox.Show("Podaj ilość.", "Niepoprawna wartość.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(CenaTowar == null )
            {
                MessageBox.Show("Wybierz towar", "Niepoprawny towar", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PozycjaNaFakturzeForView p = new PozycjaNaFakturzeForView();
            p.NazwaTowaru = NazwaTowar;
            p.Cena = CenaTowar;          
            p.Ilosc = Ilosc;
            ListaPozycjiFaktury.Add(p);
            NazwaTowar = null;
            CenaTowar = null;
            Ilosc = null;
        }
        
        private void ObliczCenaPoczatkowa()
        {
           
            if (!(ListaPozycjiFaktury.IsNullOrEmpty()))
            {
                Wartosc = fakturaB.ObliczCenaPoczatkowa(ListaPozycjiFaktury);
            }
            else
            {
                Wartosc = null;
                RabatCeny = null;
                MessageBox.Show("Wprowadź dane", "Brak danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(Wartosc != null)
            {
                CzyRabatAktywny = true;
            }
            else
            {
                CzyRabatAktywny = false;
            }
            return;

        }
        private void WyczyscListe()
        {
            ListaPozycjiFaktury.Clear();
            Wartosc = null; 
            RabatCeny = null; 
            CzyRabatAktywny=false;
            CenaPoRabacie = null;
        }
        private bool ObliczCenaKoncowa()
        {
            ObliczCenaPoczatkowa();
            if (Wartosc == null) return false;
            if (Dostawa == true)
            {
                if (KosztDostawy != null)
                {
                    CenaPoRabacie += KosztDostawy;
                }
                else
                {
                    MessageBoxResult wynik = MessageBox.Show("Wprowadź koszt dostawy albo odznacz", "Rabat", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CenaPoRabacie = null;
                    return false;
                }
            }
            if (RabatCeny == null)
            {
                MessageBoxResult wynik = MessageBox.Show("Czy chcesz wprowadzić wartość rabatu?", "Rabat", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (wynik == MessageBoxResult.Yes)
                {
                    //Skoro trzeba dodac rabat to przerywam, żeby to umożliwić
                    return false;
                }
                if (wynik == MessageBoxResult.No)
                {
                    CzyRabatAktywny = false;
                    RabatCeny = null;
                    CenaPoRabacie = Wartosc;
                }
            }
            if(RabatCeny != null)
            {
                CenaPoRabacie = Wartosc - RabatCeny;
            }
            

            return true;
        }
        public override int Zakoncz()
        {
            if (!(new WalidatorOgolny().WalidatorFakturaZakoncz(Aktywny, Numer, IdKontrahenta, ListaPozycjiFaktury)))
            {
                return 0;
            }

            bool wynik = ObliczCenaKoncowa();
            if (!wynik)
            {
                return 2;
            }

            return 1;
        }
        #endregion
        #region Pola
        FakturaB fakturaB;
        #region PierwszyWiersz
        private readonly DateTime? _DataUtworzenia;
        public DateTime? DataUtworzenia
        {
            get
            {
                if (item.KiedyUtworzono != _DataUtworzenia)
                {
                    item.KiedyUtworzono = _DataUtworzenia;
                    OnPropertyChanged(() => DataUtworzenia);
                }
                return item.KiedyUtworzono;
            }
        }
        public DateTime? DataModyfikacji
        {
            get
            {
                if (item.KiedyZmieniono != DateTime.Today && item.KiedyUtworzono != DateTime.Today)
                {
                    item.KiedyZmieniono = DateTime.Today;
                    OnPropertyChanged(() => DataModyfikacji);
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
                    item.Aktywny = true;
                    OnPropertyChanged(() => Aktywny);
                    return item.Aktywny;
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
        #region Ogólne
        public string? Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    if(value.Contains(' '))
                    {
                        MessageBox.Show("Błędny numer dokumentu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Numer = null;
                        base.OnPropertyChanged(() => Numer);
                        return;
                    }
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public bool? Dostawa
        {
            get
            {
                if (item.Dostawa == null)
                {
                    item.Dostawa = false;
                    OnPropertyChanged(() => Dostawa);
                    return item.Dostawa;
                }
                else
                {
                    return item.Dostawa;
                }
            }
            set
            {
                if (item.Dostawa != value)
                {
                    item.Dostawa = value;
                    OnPropertyChanged(() => Dostawa);
                    KosztDostawy = null;
                }
            }
        }
        public decimal? KosztDostawy
        {
            get
            {
                return item.KosztDostawy;
            }
            set
            {
                if (item.KosztDostawy != value)
                {
                    item.KosztDostawy = value;
                    base.OnPropertyChanged(() => KosztDostawy);
                }
            }
        }
        public int? IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                if (item.IdKontrahenta != value)
                {
                    item.IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }
        private string? _KontrahentNazwa;
        public string? KontrahentNazwa
        {
            get
            {
                return _KontrahentNazwa;
            }
            set
            {
                if (_KontrahentNazwa != value)
                {
                    _KontrahentNazwa = value;
                    base.OnPropertyChanged(() => KontrahentNazwa);
                }
            }
        }
        //chwilowo bez zastosowania
        //private bool? _KontrahentPodatnikVat;
        //public bool? KontrahentPodatnikVat
        //{
        //    get
        //    {
        //        return _KontrahentPodatnikVat;
        //    }
        //    set
        //    {
        //        if (_KontrahentPodatnikVat != value)
        //        {
        //            _KontrahentPodatnikVat = value;
        //            OnPropertyChanged(() => _KontrahentPodatnikVat);
        //        }
        //    }
        //}
        #endregion
        #region Pozycje
        private int? _IdTowar;
        public int? IdTowar
        {
            get
            {
                return _IdTowar;
            }
            set
            {
                if(_IdTowar != value)
                {
                    _IdTowar = value;
                    OnPropertyChanged(() => IdTowar);
                }
            }
        }
        private string? _NazwaTowar;
        public string? NazwaTowar
        {
            get
            {
                return _NazwaTowar;
            }
            set
            {
                if (_NazwaTowar != value)
                {
                    _NazwaTowar = value;
                    OnPropertyChanged(() => NazwaTowar);
                }
            }
        }
        private decimal? _CenaTowar;
        public decimal? CenaTowar
        {
            get
            {
                return _CenaTowar;
            }
            set
            {
                if (_CenaTowar != value)
                {
                    _CenaTowar = value;
                    OnPropertyChanged(() => CenaTowar);
                }
            }
        }
        private int? _Ilosc;
        public int? Ilosc
        {
            get
            {
                return _Ilosc;
            }
            set
            {
                if (_Ilosc != value)
                {
                    _Ilosc = value;
                    OnPropertyChanged(() => Ilosc);
                }
            }
        }
        #endregion
        #region Podsumowanie
        public decimal? Wartosc
        {
            get
            {
                return item.Wartosc;
            }
            set
            {
                if(item.Wartosc != value)
                {
                    item.Wartosc = value;
                    OnPropertyChanged(() => Wartosc);
                }
            }
        }
        private bool? _CzyRabatAktywny;
        public bool? CzyRabatAktywny
        {
            get
            {
                if (_CzyRabatAktywny == null)
                {
                    _CzyRabatAktywny = false;
                }
                return _CzyRabatAktywny;
            }
            set
            {
                if(_CzyRabatAktywny != value)
                {
                    _CzyRabatAktywny= value;
                    OnPropertyChanged(() => CzyRabatAktywny);
                }
            }
        }
        public decimal? RabatCeny
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                if (item.Rabat != value)
                {
                    item.Rabat = value;
                    base.OnPropertyChanged(() => RabatCeny);
                }
            }
        }
        public decimal? CenaPoRabacie
        {
            get
            {
                return item.WartoscPoRabacie;
            }
            set
            {
                if(item.WartoscPoRabacie != value)
                {
                    item.WartoscPoRabacie = value;
                    OnPropertyChanged(() => CenaPoRabacie);
                }
            }
        }
        public bool? CzyZaplacone
        {
            get
            {
                if(item.Zaplacone == null)
                {
                    item.Zaplacone = false;
                    OnPropertyChanged(() => CzyZaplacone);
                }
                return item.Zaplacone;
            }
            set
            {
                if(item.Zaplacone != value)
                {
                    item.Zaplacone = value;
                    OnPropertyChanged(() => CzyZaplacone);
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
