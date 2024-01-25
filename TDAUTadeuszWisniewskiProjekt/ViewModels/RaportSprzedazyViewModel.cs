using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.BusinessLogic;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class RaportSprzedazyViewModel:WorkspaceViewModel
    {
        #region DB
        protected readonly FirmaSpawalniczaEntities firmaSpawalniczaEntities;
        #endregion
        #region Pola
        private DateTime? _DataOd;
        public DateTime? DataOd
        {
            get
            {
                if (_DataOd == null)
                {
                    return _DataOd = DateTime.Today;
                }
                return _DataOd;
            }
            set
            {
                if (value != _DataOd)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }

            }
        }
        private DateTime? _DataDo;
        public DateTime? DataDo
        {
            get
            {
                if (_DataDo == null)
                {
                    return _DataDo = DateTime.Today;
                }
                return _DataDo;
            }
            set
            {
                if (value != _DataDo)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }

            }
        }
        private decimal? _Utarg;
        public decimal? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (value != _Utarg)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }
        #endregion
        #region Konstruktor
        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport Sprzedazy";
            firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion
        #region Commands
        private BaseCommand _ObliczCommand;
        //ten propertis zostanie podpiety pod przycisk oblicz. Wywoła on funkcję obliczutargClick
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => obliczUtargClick());

                }
                return _ObliczCommand;
            }
        }
        private void obliczUtargClick()
        {
            //to jest wywołanie funkcji z klasy logiki biznesowej UtargB
            Utarg = new UtargB(firmaSpawalniczaEntities).UtargOkres(DataOd, DataDo);
        }
        #endregion
    }
}
