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
    public class WszystkieTypyViewModel : WszystkieViewModel<TypForView>
    {
        private TypForView _WybranyT;
        public TypForView WybranyT
        {
            get
            {
                return _WybranyT;
            }
            set
            {
                if(_WybranyT != value)
                {
                    _WybranyT = value;
                    Messenger.Default.Send(_WybranyT);
                    OnRequestClose();
                }
            }
        }
        #region Konstruktor
        public WszystkieTypyViewModel()
           : base("Typy")
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
                List = new ObservableCollection<TypForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<TypForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<TypForView>
                (
                    from t in firmaSpawalniczaEntities.Typs
                    select new TypForView
                    {
                        Id=t.Id,
                        Nazwa=t.Nazwa,
                        Opis=t.Opis,
                        KiedyUtworzono=t.KiedyUtworzono,
                        KiedyZmieniono=t.KiedyZmieniono,
                        Aktywny=t.Aktywny
                    }
                );
        }
        #endregion

    }
}
