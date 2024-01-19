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
    public class WszystkieTowaryViewModel : WszystkieViewModel<TowarForView>
    {
        #region Properties
        public TowarForView _WybranyT;
        public TowarForView WybranyT
        {
            set
            {
                if (_WybranyT != value)
                {
                    _WybranyT = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyT);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyT;
            }
        }

        #endregion
        public WszystkieTowaryViewModel()
            :base("Towary")
        {
            
        }

        public override void load()
        {
            List = new ObservableCollection<TowarForView>
                (
                from T in firmaSpawalniczaEntities.Towars
                select new TowarForView
                {
                    Id= T.Id,
                    Nazwa= T.Nazwa,
                    CenaKoncowa = T.CenaKoncowa,
                    WysokoscVAT = T.IdStawkiVatsprzedazyNavigation.Wysokosc,
                    KiedyUtworzone= T.KiedyUtworzone,  
                    KiedyZmieniono=T.KiedyZmieniono,
                    Aktywny=T.Aktywny,
                }
                );
        }
    }
}
