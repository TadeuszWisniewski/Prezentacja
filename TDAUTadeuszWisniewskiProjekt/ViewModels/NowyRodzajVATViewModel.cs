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
    public class NowyRodzajVATViewModel : JedenViewModel<RodzajVat> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        #region Konstruktor
        public NowyRodzajVATViewModel()
            : base("Rodzaj VAT")
        {
            item = new RodzajVat();
            _DataUtworzenia = DateTime.Today;
        }
        #endregion
        #region Metody
        public override int Zakoncz()
        {
            if (Aktywny == false || Nazwa.IsNullOrEmpty() || Nazwa.StartsWith(' '))
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
        public decimal? Wysokosc
        {
            get
            {
                if(item.Wysokosc is null)
                {
                    item.Wysokosc = 0;
                }
                return item.Wysokosc;
            }
            set
            {
                if (item.Wysokosc != value)
                {                  
                    if (value >= 0 && value <= 100)
                    {
                        item.Wysokosc = value;
                        OnPropertyChanged(() => Wysokosc);
                    }
                    else
                    {
                        MessageBox.Show("Wysokość VAt musi wynosić między 0 a 100", "Niepoprawna wysokość VAT", MessageBoxButton.OK, MessageBoxImage.Error);
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
