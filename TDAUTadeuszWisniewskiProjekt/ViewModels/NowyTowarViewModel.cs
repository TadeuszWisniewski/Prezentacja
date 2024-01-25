using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;
using TDAUTadeuszWisniewskiProjekt.Models.Validatory;
using TDAUTadeuszWisniewskiProjekt.ViewModels;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar> 
    {
        #region Command
        private BaseCommand _ShowTypyCommand;
        public ICommand ShowTypyCommand
        {
            get
            {
                if (_ShowTypyCommand == null)
                {
                    _ShowTypyCommand = new BaseCommand(() => Messenger.Default.Send("TypyShow"));
                }
                return _ShowTypyCommand;
            }
        }
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
        private BaseCommand _ShowJednostkaCommand;
        public ICommand ShowJednostkaCommand
        {
            get
            {
                if (_ShowJednostkaCommand == null)
                {
                    _ShowJednostkaCommand = new BaseCommand(() => Messenger.Default.Send("JednostkiShow"));
                }
                return _ShowJednostkaCommand;
            }
        }
        private BaseCommand _ShowCPVCommand;
        public ICommand ShowCPVCommand
        {
            get
            {
                if (_ShowCPVCommand == null)
                {
                    _ShowCPVCommand = new BaseCommand(() => Messenger.Default.Send("CPVShow"));
                }
                return _ShowCPVCommand;
            }
        }
        private BaseCommand _ShowCenyCommand;
        public ICommand ShowCenyCommand
        {
            get
            {
                if (_ShowCenyCommand == null)
                {
                    _ShowCenyCommand = new BaseCommand(() => Messenger.Default.Send("CenyShow"));
                }
                return _ShowCenyCommand;
            }
        }
        private BaseCommand _ShowCenyWyprzedazyCommand;
        public ICommand ShowCenyWyprzedazyCommand
        {
            get
            {
                if (_ShowCenyWyprzedazyCommand == null)
                {
                    _ShowCenyWyprzedazyCommand = new BaseCommand(() => Messenger.Default.Send("Ceny wyprzedazyShow"));
                }
                return _ShowCenyWyprzedazyCommand;
            }
        }
        private BaseCommand _ObliczCeneKoncowaCommand;
        public ICommand ObliczCeneKoncowaCommand
        {
            get
            {
                if (_ObliczCeneKoncowaCommand == null)
                {
                    _ObliczCeneKoncowaCommand = new BaseCommand(() => Oblicz());
                }
                return _ObliczCeneKoncowaCommand;
            }
        }
        #endregion
        public NowyTowarViewModel()
            : base("Towar")// to jest ustawienie nazwy zakladki
        {
            item = new Towar();
            _DataUtworzenia = DateTime.Today;
            towarB = new TowarB(firmaSpawalniczaEntities);

            Messenger.Default.Register<TypForView>(this, getWybranyTyp);
            Messenger.Default.Register<RodzajVatForView>(this, getWybranyRodzajVat);
            Messenger.Default.Register<RodzajVATZakupuForView>(this, getWybranyRodzajVatZakupu);
            Messenger.Default.Register<JednostkaForView>(this, getWybranaJednostka);
            Messenger.Default.Register<KodCPVForView>(this, getWybranyCPV);
            Messenger.Default.Register<CenaForView>(this, getWybranaCena);
            Messenger.Default.Register<CenaWyprzedazyForView>(this, getWybranaCenaWyprzedazy);
        }
        #region Metody
        private void getWybranyTyp(TypForView t)
        {
            IdTyp = t.Id;
            NazwaTyp = t.Nazwa;
        }
        private void getWybranyRodzajVat(RodzajVatForView rodzajVat)
        {
            //podstawiamy rodzaj vat przesłany
            IdRodzajVatSprzedazy = rodzajVat.Id;
            RodzajVatSprzedazy = rodzajVat.Wysokosc;
        }
        private void getWybranyRodzajVatZakupu(RodzajVATZakupuForView rodzajVat)
        {
            //podstawiamy rodzaj vat przesłany
            IdRodzajVatZakupu = rodzajVat.Id;
            RodzajVatZakupu = rodzajVat.Wysokosc;
        }
        private void getWybranaJednostka(JednostkaForView j)
        {
            IdJednostka= j.Id;
            NazwaJednostka=j.Nazwa;
        }
        private void getWybranyCPV(KodCPVForView cpv)
        {
            IdCPV = cpv.Id;
            CPVKod = cpv.Kod;
        }
        private void getWybranaCena(CenaForView c)
        {
            IdCenaRegularna = c.Id;
            WartoscCenaRegularna = c.Wartosc;
        }
        private void getWybranaCenaWyprzedazy(CenaWyprzedazyForView c)
        {
            IdCenaWyprzedazy = c.Id;
            WartoscCenaWyprzedazy = c.Wartosc;
        }
        private void getWybranaCenaWyprzedazy()
        {
            IdCenaWyprzedazy = null;
            WartoscCenaWyprzedazy = null;
        }
        public int? Przypisz(int? idEan)
        {
            ObservableCollection<Eantyp> List = new ObservableCollection<Eantyp>
                (
                    firmaSpawalniczaEntities.Eantyps
                );
            foreach (Eantyp e in List)
            {
                if (e.Id == idEan)
                {
                    return e.IloscCyfr;
                }
            }
            return null;
        }
        //private bool ObliczCenaKoncowa()
        //{
        //    decimal? cenaKoncowa = 0;
        //    if (DoWyprzedazy == false)
        //    {
        //        if (WartoscCenaRegularna != null)
        //        {
        //            cenaKoncowa = cenaKoncowa + WartoscCenaRegularna;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Wybierz cenę regularną", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }
        //    }
        //    if (DoWyprzedazy == true)
        //    {
        //        if (WartoscCenaWyprzedazy != null)
        //        {
        //            cenaKoncowa = cenaKoncowa + WartoscCenaWyprzedazy;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Wybierz cenę wyprzedaży", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }
        //    }
        //    if (IdRodzajVatSprzedazy != null  )
        //    {
        //        if (RodzajVatSprzedazy != null)
        //        {
        //            cenaKoncowa = cenaKoncowa + (cenaKoncowa * (RodzajVatSprzedazy / 100));
        //        }
        //        else
        //        {
        //            MessageBox.Show("Wybierz VAT dla sprzedaży", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Wybierz VAT dla sprzedaży", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
        //    //Poniższe zacznie działać po zmianie typu danych w bazie na nvarchar(50)
        //    if (Opakowanie == true)
        //    {
        //        if(KosztOpakowania != null && KosztOpakowania != 0)
        //        {
        //            cenaKoncowa += KosztOpakowania;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Podaj koszt opakowania lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }
        //    }
        //    if (UslugaPodnoszacaWartoscMagazynowa == true)
        //    {
        //        if(WartoscUslugaPodnoszacaWartoscMagazynowa != null && WartoscUslugaPodnoszacaWartoscMagazynowa != 0)
        //        {
        //            cenaKoncowa += WartoscUslugaPodnoszacaWartoscMagazynowa;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Podaj wartość podnoszącą wartość magazynową lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }

        //    }
        //    if (KosztDodatkowy == true)
        //    {
        //        if(WartoscKosztDodatkowy != null && WartoscKosztDodatkowy != 0)
        //        {
        //            cenaKoncowa += WartoscKosztDodatkowy;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Podaj koszt dodatkowy lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }
        //    }
            
        //    if(cenaKoncowa != 0)
        //    {
        //        CenaKoncowa = cenaKoncowa;
        //    }
        //    return true;
        //}
        private void Oblicz()
        {
            CenaKoncowa = towarB.ObliczCenaKoncowa(DoWyprzedazy, WartoscCenaRegularna, WartoscCenaWyprzedazy, IdRodzajVatSprzedazy, RodzajVatSprzedazy, Opakowanie,
            KosztOpakowania, UslugaPodnoszacaWartoscMagazynowa, WartoscUslugaPodnoszacaWartoscMagazynowa, KosztDodatkowy, WartoscKosztDodatkowy);
        }
        public override int Zakoncz()
        {           
            if (!(new WalidatorOgolny().WalidatorTowarZakoncz(Aktywny, Nazwa, PKWiU, NumerKatalogowy, KodKreskowy, IdTyp, IdCPV)))
            {
                return 0;
            }

            Oblicz();
            decimal? wynik1 = CenaKoncowa;
            //bool wynik = ObliczCenaKoncowa();
            if (wynik1 == null)
            {
                return 2;
            }
            return 1;
        }
        #endregion
        #region Pola
        TowarB towarB;
        #region PierwszyWiersz
        private readonly DateTime? _DataUtworzenia;
        public DateTime? DataUtworzenia
        {
            get
            {
                if (item.KiedyUtworzone != _DataUtworzenia)
                {
                    item.KiedyUtworzone = _DataUtworzenia;
                    OnPropertyChanged(() => DataUtworzenia);
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
        public int? IdTyp
        {
            get
            {
                return item.IdTypu;
            }
            set
            {
                if (item.IdTypu != value)
                {
                    item.IdTypu = value;
                    OnPropertyChanged(() => IdTyp);
                }
            }
        }
        private string? _NazwaTyp;
        public string? NazwaTyp
        {
            get
            {
                return _NazwaTyp;
            }
            set
            {
                if(_NazwaTyp != value)
                {
                    _NazwaTyp = value;
                    OnPropertyChanged(() => NazwaTyp);
                }
            }
        }
        public string? Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    if(value.IsNullOrEmpty() || value.StartsWith(' '))
                    {
                        MessageBox.Show("Błędna nazwa", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Nazwa = null;
                        return;
                    }
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? IdEAN
        {
            get
            {
                return item.IdEanu;
            }
            set
            {
                if (item.IdEanu != value)
                {
                    item.IdEanu = value;                
                    KodKreskowy = null;
                    EdycjaKoduKreskowego = true;
                    OnPropertyChanged(() => IdEAN);
                    EANIloscCyfr = Przypisz(IdEAN);
                }
            }
        }
        
        private bool? _EdycjaKoduKreskowego;
        public bool? EdycjaKoduKreskowego
        {
            get
            {
                if(_EdycjaKoduKreskowego is null)
                {
                    _EdycjaKoduKreskowego = false;
                    OnPropertyChanged(() => _EdycjaKoduKreskowego);
                }
                return _EdycjaKoduKreskowego;
            }
            set
            {
                if(_EdycjaKoduKreskowego != value)
                {
                    _EdycjaKoduKreskowego = value;
                    OnPropertyChanged(() => EdycjaKoduKreskowego);
                }
            }
        }

        private int? _EANIloscCyfr;
        public int? EANIloscCyfr
        {
            get
            {
                //w przypadku null po stronie ean mamy 10
                if(_EANIloscCyfr is null)
                {
                    return 10;
                }
                return _EANIloscCyfr;
            }
            set
            {
                if ( _EANIloscCyfr != value)
                {
                    _EANIloscCyfr = value;
                    OnPropertyChanged(() => EANIloscCyfr);
                }
            }
        }
        
        public IQueryable<KeyAndValue2> EANComboBoxItems
        {
            get
            {
                return towarB.GetEANComboBoxItems;
            }
        }
        
        public string? KodKreskowy
        {
            get
            {
                return item.KodKreskowy;
            }
            set
            {
                if (item.KodKreskowy != value)
                {
                    if( value.IsNullOrEmpty() || value.Contains(' ') || value.Length != EANIloscCyfr)
                    {
                        MessageBox.Show("Błędny kod kreskowy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.KodKreskowy = null;
                        OnPropertyChanged(() => KodKreskowy);
                        return;
                    }
                    item.KodKreskowy = value;
                    OnPropertyChanged(() => KodKreskowy);
                }
            }
        }
        public bool? Opakowanie
        {
            get
            {
                if (item.Opakowanie == null)
                {
                    item.Opakowanie = false;
                    OnPropertyChanged(() => Opakowanie);
                    return item.Opakowanie;
                }
                else
                {
                    return item.Opakowanie;
                }
            }
            set
            {
                if (item.Opakowanie != value)
                {
                    item.Opakowanie = value;
                    KosztOpakowania = null;
                    OnPropertyChanged(() => Opakowanie);

                }
            }
        }
        public decimal? KosztOpakowania
        {
            get
            {
                return item.KosztOpakowania;
            }
            set
            {
                if (item.KosztOpakowania != value)
                {
                    if (value == null)
                    {
                        KosztOpakowania = 0;
                        OnPropertyChanged(() => KosztOpakowania);
                        return;
                    }
                    item.KosztOpakowania = value;
                    OnPropertyChanged(() => KosztOpakowania);
                }
            }
        }
        public string? NumerKatalogowy
        {
            get
            {
                return item.NumerKatalogowy;
            }
            set
            {
                if (item.NumerKatalogowy != value)
                {
                    if (value.IsNullOrEmpty() || value.Contains(' ') )
                    {
                        MessageBox.Show("Błędny numer katalogowy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.NumerKatalogowy = null;
                        OnPropertyChanged(() => NumerKatalogowy);
                        return;
                    }
                    item.NumerKatalogowy = value;
                    OnPropertyChanged(() => NumerKatalogowy);
                }
            }
        }
        public int? IdRodzajVatSprzedazy
        {
            get
            {
                return item.IdStawkiVatsprzedazy;
            }
            set
            {
                if (item.IdStawkiVatsprzedazy != value)
                {
                    item.IdStawkiVatsprzedazy = value;
                    OnPropertyChanged(() => IdRodzajVatSprzedazy);
                }
            }
        }
        private decimal? _RodzajVatSprzedazy;
        public decimal? RodzajVatSprzedazy
        {
            get
            {
                return _RodzajVatSprzedazy;
            }
            set
            {
                if (_RodzajVatSprzedazy != value)
                {
                    _RodzajVatSprzedazy = value;
                    OnPropertyChanged(() => RodzajVatSprzedazy);
                }
            }
        }
        //Nie dodaje warunku sprawdzającego przy zapisie ponieważ nie ma jeszcze implementacji stanów magazynowych.
        public int? IdRodzajVatZakupu
        {
            get
            {
                return item.IdStawkiVatzakupu;
            }
            set
            {
                if (item.IdStawkiVatzakupu != value)
                {
                    item.IdStawkiVatzakupu = value;
                    base.OnPropertyChanged(() => IdRodzajVatZakupu);
                }
            }
        }
        private decimal? _RodzajVatZakupu;
        public decimal? RodzajVatZakupu
        {
            get
            {
                return _RodzajVatZakupu;
            }
            set
            {
                if (_RodzajVatZakupu != value)
                {
                    _RodzajVatZakupu = value;
                    OnPropertyChanged(() => RodzajVatZakupu);
                }
            }
        }
        public int? IdJednostka
        {
            get
            {
                return item.IdJednostka;
            }
            set
            {
                if (item.IdJednostka != value)
                {
                    item.IdJednostka = value;
                    OnPropertyChanged(() => IdJednostka);
                }
            }
        }
        private string? _NazwaJednostka;
        public string? NazwaJednostka
        {
            get
            {
                return _NazwaJednostka;
            }
            set
            {
                if (_NazwaJednostka != value)
                {
                    _NazwaJednostka = value;
                    OnPropertyChanged(() => NazwaJednostka);
                }
            }
        }
        public string? PKWiU
        {
            get
            {
                return item.PkwiU;
            }
            set
            {
                if (item.PkwiU != value)
                {
                    if (value.IsNullOrEmpty() || value.StartsWith(' '))
                    {
                        MessageBox.Show("Błędny numer PKWiU", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.PkwiU = null;
                        OnPropertyChanged(() => PKWiU);
                        return;
                    }
                    item.PkwiU = value;
                    OnPropertyChanged(() => PKWiU);
                }
            }
        }
        public string? PodstawaZastosowaniaStawkiVat
        {
            get
            {
                return item.PodstawaZastosowaniaStawkiVat;
            }
            set
            {
                if (item.PodstawaZastosowaniaStawkiVat != value)
                {
                    item.PodstawaZastosowaniaStawkiVat = value;
                    OnPropertyChanged(() => PodstawaZastosowaniaStawkiVat);
                }
            }
        }
        #endregion
        #region Dodatkowe
        public int? IdCPV
        {
            get
            {
                return item.IdKodCpv;
            }
            set
            {
                if (item.IdKodCpv != value)
                {
                    item.IdKodCpv = value;
                    OnPropertyChanged(() => IdCPV);
                }
            }
        }
        private string? _CPVKod;
        public string? CPVKod
        {
            get
            {
                return _CPVKod;
            }
            set
            {
                if (_CPVKod != value)
                {
                    _CPVKod = value;
                    OnPropertyChanged(() => CPVKod);
                }
            }
        }
        public int? IdCenaRegularna
        {
            get
            {
                return item.IdCeny;
            }
            set
            {
                if (item.IdCeny != value)
                {
                    item.IdCeny = value;
                    OnPropertyChanged(() => IdCenaRegularna);
                }
            }
        }
        private decimal? _WartoscCenaRegularna;
        public decimal? WartoscCenaRegularna
        {
            get
            {
                return _WartoscCenaRegularna;
            }
            set
            {
                if (_WartoscCenaRegularna != value)
                {
                    _WartoscCenaRegularna = value;
                    OnPropertyChanged(() => WartoscCenaRegularna);
                }
            }
        }
        public bool? DoWyprzedazy
        {
            get
            {
                if (item.DoWyprzedazy == null)
                {
                    item.DoWyprzedazy = false;
                    OnPropertyChanged(() => DoWyprzedazy);
                    return item.DoWyprzedazy;
                }
                else
                {
                    return item.DoWyprzedazy;
                }
            }
            set
            {
                if (item.DoWyprzedazy != value)
                {
                    item.DoWyprzedazy = value;
                    IdCenaWyprzedazy = null;
                    WartoscCenaWyprzedazy = null;
                    //getWybranaCenaWyprzedazy();
                    OnPropertyChanged(() => DoWyprzedazy);
                }
            }
        }
        public int? IdCenaWyprzedazy
        {
            get
            {
                return item.IdCenaWyprzedazy;
            }
            set
            {
                if (item.IdCenaWyprzedazy != value)
                {
                    item.IdCenaWyprzedazy = value;
                    OnPropertyChanged(() => IdCenaWyprzedazy);
                }
            }
        }
        private decimal? _WartoscCenaWyprzedazy;
        public decimal? WartoscCenaWyprzedazy
        {
            get
            {
                return _WartoscCenaWyprzedazy;
            }
            set
            {
                if (_WartoscCenaWyprzedazy != value)
                {
                    _WartoscCenaWyprzedazy = value;
                    OnPropertyChanged(() => _WartoscCenaWyprzedazy);
                }
            }
        }


        public bool? BlokadaSprzedazy
        {
            get
            {
                if (item.Blokada == null)
                {
                    item.Blokada = false;
                    OnPropertyChanged(() => BlokadaSprzedazy);
                    return item.Blokada;
                }
                else
                {
                    return item.Blokada;
                }
            }
            set
            {
                if (item.Blokada != value)
                {
                    item.Blokada = value;
                    OnPropertyChanged(() => BlokadaSprzedazy);
                    PowodBlokady = null;
                }
            }
        }
        public string? PowodBlokady
        {
            get
            {
                return item.PowodBlokady;
            }
            set
            {
                if(item.PowodBlokady != value)
                {
                    if (value.IsNullOrEmpty() || value.StartsWith(' '))
                    {
                        MessageBox.Show("Błędny powód blokady", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.PowodBlokady = null;
                        OnPropertyChanged(() => PowodBlokady);
                        return;
                    }
                    item.PowodBlokady = value;
                    OnPropertyChanged(() => PowodBlokady);
                }
            }
        }
        public bool? UslugaPodnoszacaWartoscMagazynowa
        {
            get
            {
                if (item.UslugaPodnoszacaWartoscMagazynowa == null)
                {
                    item.UslugaPodnoszacaWartoscMagazynowa = false;
                    OnPropertyChanged(() => UslugaPodnoszacaWartoscMagazynowa);
                    return item.UslugaPodnoszacaWartoscMagazynowa;
                }
                else
                {
                    return item.UslugaPodnoszacaWartoscMagazynowa;
                }
            }
            set
            {
                if (item.UslugaPodnoszacaWartoscMagazynowa != value)
                {
                    item.UslugaPodnoszacaWartoscMagazynowa = value;
                    OnPropertyChanged(() => UslugaPodnoszacaWartoscMagazynowa);
                    WartoscUslugaPodnoszacaWartoscMagazynowa = null;
                }
            }
        }
        public decimal? WartoscUslugaPodnoszacaWartoscMagazynowa
        {
            get
            {
                return item.WartoscUslugi;
            }
            set
            {
                if (item.WartoscUslugi != value)
                {
                    item.WartoscUslugi = value;
                    OnPropertyChanged(() => WartoscUslugaPodnoszacaWartoscMagazynowa);
                }
            }
        }
        public bool? KosztDodatkowy
        {
            get
            {
                if (item.DodatkowyKoszt == null)
                {
                    item.DodatkowyKoszt = false;
                    OnPropertyChanged(() => KosztDodatkowy);
                    return item.DodatkowyKoszt;
                }
                else
                {
                    return item.DodatkowyKoszt;
                }
            }
            set
            {
                if (item.DodatkowyKoszt != value)
                {
                    item.DodatkowyKoszt = value;
                    OnPropertyChanged(() => KosztDodatkowy);
                    WartoscKosztDodatkowy = null;
                }
            }
        }
        public decimal? WartoscKosztDodatkowy
        {
            get
            {
                return item.WartoscDodatkowegoKosztu;
            }
            set
            {
                if (item.WartoscDodatkowegoKosztu != value)
                {
                    item.WartoscDodatkowegoKosztu = value;
                    OnPropertyChanged(() => WartoscKosztDodatkowy);
                }
            }
        }
        public decimal? CenaKoncowa
        {
            get
            {
                return item.CenaKoncowa;
            }
            set
            {
                if (item.CenaKoncowa != value)
                {
                    item.CenaKoncowa = value;
                    OnPropertyChanged(() => CenaKoncowa);
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
