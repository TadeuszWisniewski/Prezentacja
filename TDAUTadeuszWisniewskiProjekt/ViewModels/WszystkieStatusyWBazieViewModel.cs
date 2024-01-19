using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieStatusyWBazieViewModel : WszystkieViewModel<StatusWBazieMFForView>
    {
        #region Properties
        public StatusWBazieMFForView _WybranyS;
        public StatusWBazieMFForView WybranyS
        {
            set
            {
                if (_WybranyS != value)
                {
                    _WybranyS = value;
                    Messenger.Default.Send(_WybranyS);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyS;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieStatusyWBazieViewModel()
           : base("Statusy w bazie")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            List = new ObservableCollection<StatusWBazieMFForView>
                (
                    from s in firmaSpawalniczaEntities.StatusWbazies
                    select new StatusWBazieMFForView
                    {
                        Id=s.Id,
                        Nazwa=s.Nazwa,
                        KiedyUtworzono=s.KiedyUtworzono,
                        KiedyZmieniono=s.KiedyZmieniono,
                        Aktywny = s.Aktywny,
                    }
                );
        }
        #endregion

    }
}
