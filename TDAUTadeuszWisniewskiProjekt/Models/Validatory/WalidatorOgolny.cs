using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.Models.Validatory
{
    public class WalidatorOgolny
    {
        public bool SprawdzDane(bool? Aktywny, string? Nazwa)
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || Nazwa.StartsWith(" "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SprawdzDane2(bool? Aktywny, string? Nazwa, int? IloscGodzinTygodniowo)
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || Nazwa.StartsWith(" ") || IloscGodzinTygodniowo == null || IloscGodzinTygodniowo == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool WalidatorSpacji(string? Nazwa)
        {
            if (Nazwa.StartsWith(' '))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool WalidatorSpacji2(string? Nazwa)
        {
            if (Nazwa.Contains(' '))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool WalidatorDlugosci(string? Nazwa, int? dlugosc)
        {
            if (Nazwa.Length <= dlugosc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool WalidatorDlugosci2(string? Nazwa, int? dlugosc)
        {
            if (Nazwa.Length != dlugosc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SprawdzDane3(bool? Aktywny, int? Id)
        {
            if (Aktywny == false || Id == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SprawdzDane4(bool? Aktywny, int? kod)
        {
            if (Aktywny == false || kod == null || kod == 0 || kod > 15)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SprawdzPracownikaZakoncz(bool? Aktywny, int? IdAdresZameldowania, int? IdAdreesKorespondencji, bool? AdresDoKorespondencjiInnyNizAdresZameldowania, int? IdJednostkaOrganizacyjna, 
            int? IdPodstawaZatrudnienia, int? IdTypUmowyOPrace, int? IdStanowisko, int? IdWymiarEtatu, decimal? Stawka, string? Nazwisko, string? Imie, string? DrugieImie, 
            string? NazwiskoRodowe, string? ImieMatki, string? NazwiskoRodoweMatki, string? ImieOjca, int? IdMiejsceUrodzenia, bool? IdentyfikacjaPodatkowaOpcja1, bool? IdentyfikacjaPodatkowaOpcja2,
            string? Pesel, int? IdTypNIP, string? Nip)
        {
            if (IdentyfikacjaPodatkowaOpcja1 == true && Pesel == null)
            {
                MessageBox.Show("Brak identyfikacji podatkowej", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (IdentyfikacjaPodatkowaOpcja2 == true && Nip == null)
            {
                MessageBox.Show("Brak identyfikacji podatkowej", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (AdresDoKorespondencjiInnyNizAdresZameldowania == true && IdAdreesKorespondencji == null)
            {
                MessageBox.Show("Wybierz adres do korespondencji lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Aktywny == false || IdAdresZameldowania == null || IdJednostkaOrganizacyjna == null || IdPodstawaZatrudnienia == null || IdTypUmowyOPrace == null
                || IdStanowisko == null || IdWymiarEtatu == null ||  Stawka == null || Nazwisko == null || Imie == null || DrugieImie == null
                || NazwiskoRodowe == null || ImieMatki == null || NazwiskoRodoweMatki == null || ImieOjca == null || IdMiejsceUrodzenia == null)
            {

                MessageBox.Show("Wprowadź wszystkie wymagane dane poprawnie", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool WalidatorStawki(decimal? wartosc)
        {
            if(wartosc == 0 || wartosc > 1000 )
            {
                
                return false;
            }
            return true;
        }
        public bool WalidatorDni(decimal? wartosc)
        {
            if (wartosc > 31)
            {

                return false;
            }
            return true;
        }
        public bool WalidatorKontrahentZakoncz(bool? Aktywny, decimal? LimitKredytu, int? IdStatus, int? IdFormaPrawna, int? IdStatusMF, int? IdStatusVIES,
            string? Nazwa, string? Nip, string? Pesel, string? Regon, string? Krs, string? GlnIln, string? StronaWww, int? IdAdresZameldowania, int? IdDefinicjaPlatnosci, int? IdWaluta,
            bool? AdresDoKorespondencjiInnyNizAdresZameldowania, int? IdAdresDoKorespondencji)
        {
            if (AdresDoKorespondencjiInnyNizAdresZameldowania == true && IdAdresDoKorespondencji == null)
            {
                return false;
            }
            if (Aktywny == false || LimitKredytu == null || IdStatus == null || IdFormaPrawna == null || IdStatusMF == null || IdStatusVIES == null
                || Nazwa.IsNullOrEmpty() || Nip.IsNullOrEmpty() || Pesel.IsNullOrEmpty() || Regon.IsNullOrEmpty() || Krs.IsNullOrEmpty() || GlnIln.IsNullOrEmpty()
                || StronaWww.IsNullOrEmpty() || IdAdresZameldowania == null || IdDefinicjaPlatnosci == null || IdWaluta == null)
            {
                return false;
            }
            return true;
        }
        public bool WalidatorTowarZakoncz(bool? Aktywny, string? Nazwa, string? PKWiU, string? NumerKatalogowy, string?  KodKreskowy, int? IdTyp, int? IdCPV)
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || PKWiU.IsNullOrEmpty() || NumerKatalogowy.IsNullOrEmpty() || KodKreskowy.IsNullOrEmpty() || IdTyp == null || IdCPV == null)
            {
                return false;
            }
            return true;
        }
        public bool WalidatorFakturaZakoncz(bool? Aktywny, string? Numer, int? IdKontrahenta, ObservableCollection<PozycjaNaFakturzeForView> ListaPozycjiFaktury)
        {
            if (Aktywny == false || Numer.IsNullOrEmpty() || IdKontrahenta == null || ListaPozycjiFaktury.IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }
    }
}
