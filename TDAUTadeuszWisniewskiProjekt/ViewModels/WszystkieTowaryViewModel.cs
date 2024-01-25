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
                    Messenger.Default.Send(_WybranyT);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyT;
            }
        }

        #endregion
        #region Konstruktor

        #endregion
        public WszystkieTowaryViewModel()
            :base("Towary")
        {
            
        }
        #region Zaladuj
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "CenaKoncowa" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<TowarForView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "CenaKoncowa")
                List = new ObservableCollection<TowarForView>(List.OrderBy(item => item.CenaKoncowa));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "CenaKoncowa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<TowarForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "CenaKoncowa")
                List = new ObservableCollection<TowarForView>(List.Where(item => item.CenaKoncowa != null && item.CenaKoncowa == Decimal.Parse(FindTextBox)));
        }
        #endregion
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
                    Blokada = T.Blokada,
                    KiedyUtworzone= T.KiedyUtworzone,  
                    KiedyZmieniono=T.KiedyZmieniono,
                    Aktywny=T.Aktywny,
                }
                );
        }
    }
}
