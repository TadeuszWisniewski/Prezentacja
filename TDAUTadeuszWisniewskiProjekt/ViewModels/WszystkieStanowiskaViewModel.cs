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
    public class WszystkieStanowiskaViewModel : WszystkieViewModel<StanowiskoForView>
    {
        public StanowiskoForView _WybraneS;
        public StanowiskoForView WybraneS
        {
            set
            {
                if (_WybraneS != value)
                {
                    _WybraneS = value;
                    Messenger.Default.Send(_WybraneS);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybraneS;
            }
        }
        #region Konstruktor
        public WszystkieStanowiskaViewModel()
           : base("Stanowiska")
        {

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
                List = new ObservableCollection<StanowiskoForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<StanowiskoForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<StanowiskoForView>
                (
                    from s in firmaSpawalniczaEntities.Stanowiskos
                    select new StanowiskoForView
                    {
                        Id = s.Id,
                        Nazwa = s.Nazwa,
                        KiedyUtworzone = s.KiedyUtworzone,
                        Aktywny = s.Aktywny
                    }
                );
        }
        #endregion

    }
}
