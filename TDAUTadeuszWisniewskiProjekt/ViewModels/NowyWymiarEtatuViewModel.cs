using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Views;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyWymiarEtatuViewModel : JedenViewModel<WymiarEtatu> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        public NowyWymiarEtatuViewModel()
            :base("Wymiar Etatu")
        {
            item=new WymiarEtatu();
            _DataUtworzenia = DateTime.Now;
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
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? IloscGodzinTygodniowo
        {
            get
            {
                return item.IloscGodzinTygodniowo;
            }
            set
            {
                if (item.IloscGodzinTygodniowo != value)
                {
                    item.IloscGodzinTygodniowo = value;
                    OnPropertyChanged(() => IloscGodzinTygodniowo);
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
        //dopisać warunek zabetonowania
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

        public bool? Aktywny
        {
            get
            {
                return item.Aktywny;
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
       
    }
}
