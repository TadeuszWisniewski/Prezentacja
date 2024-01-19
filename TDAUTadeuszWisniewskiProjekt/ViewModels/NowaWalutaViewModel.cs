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
    public class NowaWalutaViewModel : JedenViewModel<Walutum> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {      
        #region Konstruktor
        public NowaWalutaViewModel()
            : base("Waluta")
        {
            item = new Walutum();
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
        private void StworzSkrot()
        {
            if (item.Nazwa != null)
            {
                Skrot = Nazwa.Substring(0, 3);
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
                    if(value == null || value.StartsWith(' ') || value.Length <= 3)
                    {
                        MessageBox.Show("Błędna nazwa waluty", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        item.Nazwa = null;
                        return;
                    }  
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                    StworzSkrot();
                }
            }
        }
        public string? Skrot
        {
            get
            {
                return item.Skrot;
            }
            set
            {
                if (item.Skrot != value)
                {
                    item.Skrot = value;
                    OnPropertyChanged(() => Skrot);
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

