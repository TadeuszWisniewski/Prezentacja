using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieRodzajeVATZakupuViewModel : WszystkieViewModel<RodzajVATZakupuForView>
    {
        #region Properties
        public RodzajVATZakupuForView _WybranyR;
        public RodzajVATZakupuForView WybranyR
        {
            set
            {
                if (_WybranyR != value)
                {
                    _WybranyR = value;
                    Messenger.Default.Send(_WybranyR);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyR;
            }
        }

        #endregion
        #region Konstruktor
        public WszystkieRodzajeVATZakupuViewModel()
           : base("Rodzaje VAT")
        {
        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Wysokosc" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<RodzajVATZakupuForView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Wysokosc")
                List = new ObservableCollection<RodzajVATZakupuForView>(List.OrderBy(item => item.Wysokosc));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "Wysokosc" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<RodzajVATZakupuForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Wysokosc")
                List = new ObservableCollection<RodzajVATZakupuForView>(List.Where(item => item.Wysokosc != null && item.Wysokosc == Decimal.Parse(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<RodzajVATZakupuForView>
                (
                    from r in firmaSpawalniczaEntities.RodzajVats
                    select new RodzajVATZakupuForView
                    {
                        Id = r.Id,
                        Nazwa = r.Nazwa,
                        Wysokosc = r.Wysokosc,
                        KiedyUtworzone = r.KiedyUtworzone,
                        KiedyZmieniono=r.KiedyZmieniono,
                        Aktywny = r.Aktywny
                    }
                );
        }
        #endregion
    }
}
