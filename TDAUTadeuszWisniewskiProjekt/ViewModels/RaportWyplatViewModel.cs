using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;
using TDAUTadeuszWisniewskiProjekt.Models.Validatory;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class RaportWyplatViewModel:WorkspaceViewModel
    {
        #region DB
        protected FirmaSpawalniczaEntities firmaSpawalniczaEntities;
        #endregion
        #region Komendy
        private BaseCommand _ObliczWyplataCommand;
        public ICommand ObliczWyplataCommand
        {
            get
            {
                if (_ObliczWyplataCommand == null)
                {
                    _ObliczWyplataCommand = new BaseCommand(() => WyplataUstaw());
                }
                return _ObliczWyplataCommand;
            }
        }
        #endregion
        #region Konstruktor
        public RaportWyplatViewModel()
        {
            base.DisplayName = "Raport wypłat";
            firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion
        #region Metody
        public void WyplataUstaw()
        {
            WyplatyB w = new WyplatyB(firmaSpawalniczaEntities);
            pracownik = firmaSpawalniczaEntities.Pracowniks.FirstOrDefault(k => k.Id == IdPracownik);

            ImieINazwisko = w.UstawImieINazwisko(pracownik);
            StawkaPracownik = pracownik.Stawka;
            WysokoscWymiaruEtatuPracownik = w.IloscGodzinWTyg(pracownik);
            IloscDniPracujacychWTymMiesiacu = w.LiczbaDniPracujacych();
            WyplataWTymMiesiacu = w.WyplataZaTenMiesiac(IloscDniPracujacychWTymMiesiacu, WysokoscWymiaruEtatuPracownik, StawkaPracownik);
        }

        #endregion
        #region Pola
        private Pracownik? pracownik;
        private int? _IdPracownik;
        public int? IdPracownik
        {
            get
            {
                return _IdPracownik;
            }
            set
            {
                if (_IdPracownik != value)
                {
                    _IdPracownik = value;
                    OnPropertyChanged(() => IdPracownik);
                }
            }
        }
        private string? _ImieINazwisko;
        public string? ImieINazwisko
        {
            get
            {
                return _ImieINazwisko;
            }
            set
            {
                if (_ImieINazwisko != value)
                {
                    _ImieINazwisko = value;
                    OnPropertyChanged(() => ImieINazwisko);
                    WyplataUstaw();
                }
            }
        }
        public IQueryable<KeyAndValue> KontrahentComboBoxItems
        {
            get
            {
                return new WyplatyB(firmaSpawalniczaEntities).GetPracownicyKeyAndValueItems();
            }
        }
        private decimal? _StawkaPracownik;
        public decimal? StawkaPracownik
        {
            get
            {
                return _StawkaPracownik;
            }
            set
            {
                if (_StawkaPracownik != value)
                {
                    _StawkaPracownik = value;
                    OnPropertyChanged(() => StawkaPracownik);
                }
            }
        }

        private decimal? _WysokoscWymiaruEtatuPracownik;
        public decimal? WysokoscWymiaruEtatuPracownik
        {
            get
            {
                return _WysokoscWymiaruEtatuPracownik;
            }
            set
            {
                if (_WysokoscWymiaruEtatuPracownik != value)
                {
                    _WysokoscWymiaruEtatuPracownik = value;
                    OnPropertyChanged(() => WysokoscWymiaruEtatuPracownik);
                }
            }
        }
        private decimal? _IloscDniPracujacychWTymMiesiacu;
        public decimal? IloscDniPracujacychWTymMiesiacu
        {
            get
            {
                return _IloscDniPracujacychWTymMiesiacu;
            }
            set
            {
                if(value == null)
                {
                    _IloscDniPracujacychWTymMiesiacu = null;
                    OnPropertyChanged(() => IloscDniPracujacychWTymMiesiacu);
                }
                if(!(new WalidatorOgolny().WalidatorStawki(value)))
                {
                    MessageBox.Show("Błędna ilośc dni", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    IloscDniPracujacychWTymMiesiacu = null;
                    OnPropertyChanged(() => IloscDniPracujacychWTymMiesiacu);
                    return;
                }
                if (_IloscDniPracujacychWTymMiesiacu != value)
                {
                    _IloscDniPracujacychWTymMiesiacu = value;
                    OnPropertyChanged(() => IloscDniPracujacychWTymMiesiacu);
                }
            }
        }
        public decimal? _WyplataWTymMiesiacu;
        public decimal? WyplataWTymMiesiacu
        {
            get
            {
                return _WyplataWTymMiesiacu;
            }
            set
            {
                if (_WyplataWTymMiesiacu != value)
                {
                    _WyplataWTymMiesiacu = value;
                    OnPropertyChanged(() => WyplataWTymMiesiacu);
                }
            }
        }
        #endregion
    }
}
