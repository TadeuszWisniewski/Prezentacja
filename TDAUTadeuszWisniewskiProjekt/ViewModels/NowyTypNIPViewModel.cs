using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyTypNIPViewModel : JedenViewModel<TypNip> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        public NowyTypNIPViewModel()
            : base("Typ NIP")
        {
            item = new TypNip();
            _DataUtworzenia = DateTime.Now;
        }
        public int? IloscCyfr
        {
            get
            {
                return item.IloscCyfr;
            }
            set
            {
                if (item.IloscCyfr != value)
                {
                    item.IloscCyfr = value;
                    OnPropertyChanged(() => IloscCyfr);
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
                if (item.KiedyUtworzone != _DataUtworzenia)
                {
                    item.KiedyUtworzone = _DataUtworzenia;
                }
                return item.KiedyUtworzone;
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
