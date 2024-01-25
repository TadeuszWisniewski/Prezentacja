using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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
    public class RaportKontrahentowViewModel : WorkspaceViewModel
    {
        #region DB
        protected FirmaSpawalniczaEntities firmaSpawalniczaEntities;
        #endregion
        #region Komendy
        private BaseCommand _ObliczKontrahentaCommand;
        public ICommand ObliczKontrahentaCommand
        {
            get
            {
                if (_ObliczKontrahentaCommand == null)
                {
                    _ObliczKontrahentaCommand = new BaseCommand(() => KontrahentUstaw());
                }
                return _ObliczKontrahentaCommand;
            }
        }
        #endregion
        #region Konstruktor
        public RaportKontrahentowViewModel()
        {
            base.DisplayName = "Raport dotyczący kontrahentów";
            firmaSpawalniczaEntities=new FirmaSpawalniczaEntities();
        }
        #endregion
        #region Metody
        public void KontrahentUstaw()
        {
            KontrahentB kontrahentB = new KontrahentB(firmaSpawalniczaEntities);
            kontrahentB.ObliczDlaWszystkichPol(IdKontrahent);

            kontrahent = firmaSpawalniczaEntities.Kontrahents.FirstOrDefault(k => k.Id == IdKontrahent);
            StronaKontrahent = kontrahent.StronaWww;
            LimitKredytuKontrahent = kontrahent.LimitKredytu;
            LacznaWartoscFakturKontrahent = kontrahent.LacznaWartoscFaktur;
            WartoscNiezaplaconychFakturKontrahent = kontrahent.SumaZaleglychNaleznosci;
            PozostalyLimitKontrahent = kontrahent.PozostalyLimit;
        }
        #endregion
        #region Pola
        private Kontrahent? kontrahent;
        private int? _IdKontrahent;
        public int? IdKontrahent
        {
            get
            {
                return _IdKontrahent;
            }
            set
            {
                if( _IdKontrahent != value)
                {
                    _IdKontrahent = value;
                    OnPropertyChanged(() => IdKontrahent);
                }
            }
        }
        private string? _StronaKontrahent;
        public string? StronaKontrahent
        {
            get
            {
                return _StronaKontrahent;
            }
            set
            {
                if (_StronaKontrahent != value)
                {
                    _StronaKontrahent = value;
                    OnPropertyChanged(() => StronaKontrahent);
                    KontrahentUstaw();
                }
            }
        }
        public IQueryable<KeyAndValue> KontrahentComboBoxItems
        {
            get
            {
                return new KontrahentB(firmaSpawalniczaEntities).GetKontrahenciKeyAndValueItems();
            }
        }
        private decimal? _LimitKredytuKontrahent;
        public decimal? LimitKredytuKontrahent
        {
            get
            {
                return _LimitKredytuKontrahent;
            }
            set
            {
                if (_LimitKredytuKontrahent != value)
                {
                    _LimitKredytuKontrahent = value;
                    OnPropertyChanged(() => LimitKredytuKontrahent);
                }
            }
        }

        private decimal? _LacznaWartoscFakturKontrahent;
        public decimal? LacznaWartoscFakturKontrahent
        {
            get
            {
                return _LacznaWartoscFakturKontrahent;
            }
            set
            {
                if (_LacznaWartoscFakturKontrahent != value)
                {
                    _LacznaWartoscFakturKontrahent = value;
                    OnPropertyChanged(() => LacznaWartoscFakturKontrahent);
                }
            }
        }
        private decimal? _WartoscNiezaplaconychFakturKontrahent;
        public decimal? WartoscNiezaplaconychFakturKontrahent
        {
            get
            {
                return _WartoscNiezaplaconychFakturKontrahent;
            }
            set
            {
                if (_WartoscNiezaplaconychFakturKontrahent != value)
                {
                    _WartoscNiezaplaconychFakturKontrahent = value;
                    OnPropertyChanged(() => WartoscNiezaplaconychFakturKontrahent);
                }
            }
        }
        public decimal? _PozostalyLimitKontrahent;
        public decimal? PozostalyLimitKontrahent
        {
            get
            {
                return _PozostalyLimitKontrahent;
            }
            set
            {
                if (_PozostalyLimitKontrahent != value)
                {
                    _PozostalyLimitKontrahent = value;
                    OnPropertyChanged(() => PozostalyLimitKontrahent);
                }
            }
        }
        #endregion
    }
}
