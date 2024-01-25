using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.Validatory;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowaJednostkaOrganizacyjnaViewModel : JedenViewModel<JednostkaOrganizacyjna> //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        #region Konstruktor
        public NowaJednostkaOrganizacyjnaViewModel()
           : base("Jednostka organizacyjna")
        {
            item = new JednostkaOrganizacyjna();
            _DataUtworzenia = DateTime.Today;
        }
        #endregion
        #region Metody
        public override int Zakoncz()
        {
            if (!(new JednostkaOrganizacyjnaValidator().SprawdzDane(Aktywny, NazwaJednostkiOrganizacyjnej)))
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
        public string? NazwaJednostkiOrganizacyjnej
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
