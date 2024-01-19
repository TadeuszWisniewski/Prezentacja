using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyEANTypViewModel : JedenViewModel<Eantyp> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        #region Konstruktor
        public NowyEANTypViewModel()
            : base("EAN Typ")
        {
            item = new Eantyp();
            _DataUtworzenia = DateTime.Today;
        }
        #endregion
        #region Metody
        public override int Zakoncz()
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || Nazwa.StartsWith(' ') || IloscCyfr == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        #endregion
        #region Pola
        #region PierwszyWiersz
        private readonly DateTime? _DataUtworzenia;
        public DateTime? DataUtworzenia
        {
            get
            {
                if (item.KiedyUtworzono != _DataUtworzenia)
                {
                    item.KiedyUtworzono = _DataUtworzenia;
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
        #region DrugiWiersz
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
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? IloscCyfr
        {
            get
            {
                if(item.IloscCyfr == null)
                {
                    item.IloscCyfr = 10;
                }
                return item.IloscCyfr;
            }
            set
            {
                if (item.IloscCyfr != value)
                {
                    if (value > 0 && value <= 15)
                    {
                        item.IloscCyfr = value;
                        OnPropertyChanged(() => IloscCyfr);
                    }
                    else
                    {
                        MessageBox.Show("Ilość cyfr musi wynosić między 1 a 15", "Niepoprawna ilość cyfr", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
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
