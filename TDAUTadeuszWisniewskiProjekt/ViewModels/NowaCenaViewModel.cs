using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.IdentityModel.Tokens;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowaCenaViewModel : JedenViewModel<Cena> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        #region Konstruktor
        public NowaCenaViewModel()
            : base("Cena")
        {
            item = new Cena();
            _DataUtworzenia = DateTime.Today;
        }
        #endregion
        #region Metody
        public override int Zakoncz()
        {
            if (Aktywny == false || Wartosc == null)
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
        
        public decimal? Wartosc
        {
            get
            {
                if(item.Wartosc is null)
                {
                    item.Wartosc = 0;
                    OnPropertyChanged(() => Wartosc);
                }
                return item.Wartosc;
            }
            set
            {  
                if (item.Wartosc != value)
                {   
                    item.Wartosc = value;
                    OnPropertyChanged(() => Wartosc);
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
