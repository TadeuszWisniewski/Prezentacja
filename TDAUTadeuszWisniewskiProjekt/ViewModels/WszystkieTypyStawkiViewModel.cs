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
    public class WszystkieTypyStawkiViewModel : WszystkieViewModel<TypStawkiForView>
    {
        public TypStawkiForView _WybranyT;
        public TypStawkiForView WybranyT
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
        #region Konstruktor
        public WszystkieTypyStawkiViewModel()
           : base("Typy stawki")
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
                List = new ObservableCollection<TypStawkiForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<TypStawkiForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<TypStawkiForView>
                (
                    from t in firmaSpawalniczaEntities.TypStawkis
                    select new TypStawkiForView
                    {
                        Id = t.Id,
                        Nazwa = t.Nazwa,
                        KiedyUtworzono = t.KiedyUtworzono,
                        Aktywny = t.Aktywny
                    }
                );
        }
        #endregion

    }
}
