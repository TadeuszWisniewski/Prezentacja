using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowaJednostkaOrganizacyjnaViewModel : JedenViewModel<JednostkaOrganizacyjna> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        public NowaJednostkaOrganizacyjnaViewModel()
            : base("Jednostka organizacyjna")
        {
            item = new JednostkaOrganizacyjna();
            _DataUtworzenia = DateTime.Now;
        }
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
        public string NazwaJednostkiOrganizacyjnej
        {
            get
            {
                return item.NazwaJednostkiOrganizacyjnej;
            }
            set
            {
                if (item.NazwaJednostkiOrganizacyjnej != value)
                {
                    item.NazwaJednostkiOrganizacyjnej = value;
                    OnPropertyChanged(() => NazwaJednostkiOrganizacyjnej);
                }
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
    }
}
