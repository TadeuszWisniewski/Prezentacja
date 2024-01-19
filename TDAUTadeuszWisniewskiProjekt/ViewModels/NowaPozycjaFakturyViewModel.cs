using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowaPozycjaFakturyViewModel : JedenViewModel<PozycjaFaktury>
    {
        #region Commands
        private BaseCommand _ShowTowaryCommand;
        public ICommand ShowTowaryCommand
        {
            get
            {
                if (_ShowTowaryCommand == null)
                {
                    _ShowTowaryCommand = new BaseCommand(() => Messenger.Default.Send("TowaryShow"));
                }
                return _ShowTowaryCommand;
            }
        }
        #endregion
        #region Konstruktor
        public NowaPozycjaFakturyViewModel()
            : base("Pozycja faktury")
        {
            item = new PozycjaFaktury();
            _DataUtworzenia = DateTime.Today;
            Messenger.Default.Register<TowarForView>(this, getWybranyTowar);
        }
        #endregion
        #region Metody
        private void getWybranyTowar(TowarForView t)
        {
            IdTowaru = t.Id;
            NazwaTowaru = t.Nazwa;
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
        public int? IdTowaru
        {
            get
            {
                return item.IdTowar;
            }

            set
            {
                if (item.IdTowar != value)
                {
                    item.IdTowar = value;
                    base.OnPropertyChanged(() => IdTowaru);
                }
            }
        }
        private string? _NazwaTowaru;
        public string? NazwaTowaru
        {
            get
            {
                return _NazwaTowaru;
            }
            set
            {
                if (_NazwaTowaru != value)
                {
                    _NazwaTowaru = value;
                    OnPropertyChanged(() => NazwaTowaru);
                }
            }
        }
        public decimal? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                if (item.Ilosc != value)
                {
                    item.Ilosc = value;
                    base.OnPropertyChanged(() => Ilosc);
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
