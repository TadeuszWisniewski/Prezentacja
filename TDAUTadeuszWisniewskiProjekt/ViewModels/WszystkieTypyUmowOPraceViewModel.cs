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
    public class WszystkieTypyUmowOPraceViewModel : WszystkieViewModel<TypyUmowOPraceForView>
    {

        public TypyUmowOPraceForView _WybranaU;
        public TypyUmowOPraceForView WybranaU
        {
            set
            {
                if (_WybranaU != value)
                {
                    _WybranaU = value;
                    Messenger.Default.Send(_WybranaU);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaU;
            }
        }
        #region Konstruktor
        public WszystkieTypyUmowOPraceViewModel()
           : base("Typy umowy o prace")
        {
        }
        #endregion
        #region Command
        private Kontrahent _WybranyTypUmowy;
        public Kontrahent WybranyTypUmowy
        {
            set
            {
                if (_WybranyTypUmowy != value)
                {
                    _WybranyTypUmowy = value;
                    Messenger.Default.Send(_WybranyTypUmowy);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyTypUmowy;
            }
        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<TypyUmowOPraceForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<TypyUmowOPraceForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<TypyUmowOPraceForView>
                (
                    from u in firmaSpawalniczaEntities.TypUmowyOpraces
                    select new TypyUmowOPraceForView
                    {
                        Id = u.Id,
                        Nazwa = u.Nazwa,
                        KiedyUtworzone = u.KiedyUtworzone,
                        Aktywny = u.Aktywny
                    }
                );
        }
        #endregion

    }
}
