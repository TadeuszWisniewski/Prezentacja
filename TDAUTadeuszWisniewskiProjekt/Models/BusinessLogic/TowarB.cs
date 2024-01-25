using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic
{
    public class TowarB:DataBaseClass
    {
        public TowarB(FirmaSpawalniczaEntities f)
            :base(f)
        {

        }
        public IQueryable<KeyAndValue2> GetEANComboBoxItems
        {
            get
            {
                return
                    (
                    from Eantyp in firmaSpawalniczaEntities.Eantyps
                    select new KeyAndValue2
                    {
                        Key = Eantyp.Id,
                        Value = Eantyp.IloscCyfr
                    }
                    ).ToList().AsQueryable();
            }
        }
        public decimal? ObliczCenaKoncowa(bool? DoWyprzedazy, decimal? WartoscCenaRegularna, decimal? WartoscCenaWyprzedazy, int? IdRodzajVatSprzedazy, decimal? RodzajVatSprzedazy, bool? Opakowanie,
            decimal? KosztOpakowania, bool? UslugaPodnoszacaWartoscMagazynowa, decimal? WartoscUslugaPodnoszacaWartoscMagazynowa, bool? KosztDodatkowy, decimal? WartoscKosztDodatkowy)
        {
            decimal? cenaKoncowa = 0;
            if (DoWyprzedazy == false)
            {
                if (WartoscCenaRegularna != null)
                {
                    cenaKoncowa = cenaKoncowa + WartoscCenaRegularna;
                }
                else
                {
                    MessageBox.Show("Wybierz cenę regularną", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            if (DoWyprzedazy == true)
            {
                if (WartoscCenaWyprzedazy != null)
                {
                    cenaKoncowa = cenaKoncowa + WartoscCenaWyprzedazy;
                }
                else
                {
                    MessageBox.Show("Wybierz cenę wyprzedaży", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            if (IdRodzajVatSprzedazy != null)
            {
                if (RodzajVatSprzedazy != null)
                {
                    cenaKoncowa = cenaKoncowa + (cenaKoncowa * (RodzajVatSprzedazy / 100));
                }
                else
                {
                    MessageBox.Show("Wybierz VAT dla sprzedaży", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Wybierz VAT dla sprzedaży", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            //Poniższe zacznie działać po zmianie typu danych w bazie na nvarchar(50)
            if (Opakowanie == true)
            {
                if (KosztOpakowania != null && KosztOpakowania != 0)
                {
                    cenaKoncowa += KosztOpakowania;
                }
                else
                {
                    MessageBox.Show("Podaj koszt opakowania lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            if (UslugaPodnoszacaWartoscMagazynowa == true)
            {
                if (WartoscUslugaPodnoszacaWartoscMagazynowa != null && WartoscUslugaPodnoszacaWartoscMagazynowa != 0)
                {
                    cenaKoncowa += WartoscUslugaPodnoszacaWartoscMagazynowa;
                }
                else
                {
                    MessageBox.Show("Podaj wartość podnoszącą wartość magazynową lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

            }
            if (KosztDodatkowy == true)
            {
                if (WartoscKosztDodatkowy != null && WartoscKosztDodatkowy != 0)
                {
                    cenaKoncowa += WartoscKosztDodatkowy;
                }
                else
                {
                    MessageBox.Show("Podaj koszt dodatkowy lub odznacz", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            return cenaKoncowa;
        }
    }

}
