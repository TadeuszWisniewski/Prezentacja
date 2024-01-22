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
    public class WszystkieKrajeViewModel : WszystkieViewModel<KrajForView>
    {
        #region Wybrany
        private KrajForView _WybranyKraj;
        public KrajForView WybranyKraj
        {
            get
            {
                return _WybranyKraj;
            }
            set
            {
                if (_WybranyKraj != value)
                {
                    _WybranyKraj = value;
                    Messenger.Default.Send(_WybranyKraj);
                    OnRequestClose();
                }
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieKrajeViewModel()
           : base("Kraje")
        {
        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<KrajForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<KrajForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<KrajForView>
                (
                    from kraj in firmaSpawalniczaEntities.Krajs
                    select new KrajForView
                    {
                        Id = kraj.Id,
                        Nazwa = kraj.Nazwa,
                        KiedyUtworzone = kraj.KiedyUtworzone,
                        KiedyZmieniono = kraj.KiedyZmieniono,
                        Aktywny = kraj.Aktywny
                    }
                );
        }
        #endregion

    }
}
