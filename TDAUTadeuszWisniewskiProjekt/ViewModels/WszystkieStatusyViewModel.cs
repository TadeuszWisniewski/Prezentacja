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
    public class WszystkieStatusyViewModel : WszystkieViewModel<StatusForView>
    {
        #region Properties
        public StatusForView _WybranyS;
        public StatusForView WybranyS
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
        public WszystkieStatusyViewModel()
           : base("Statusy")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            List = new ObservableCollection<StatusForView>
                (
                    //firmaSpawalniczaEntities.Statuses
                    from s in firmaSpawalniczaEntities.Statuses
                    select new StatusForView
                    {
                        Id= s.Id,
                        Nazwa=s.Nazwa,
                        KiedyUtworzono=s.KiedyUtworzono,
                        KiedyZmieniono=s.KiedyZmieniono,
                        Aktywny=s.Aktywny,
                    }
                );
        }
        #endregion

    }
}
