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
    public class WszystkieMiejscowosciViewModel : WszystkieViewModel<MiejscowosciForView>
    {
        #region Wybrany
        private MiejscowosciForView _WybranaMiejscowosc;
        public MiejscowosciForView WybranaMiejscowosc
        {
            set
            {
                if (_WybranaMiejscowosc != value)
                {
                    _WybranaMiejscowosc = value;
                    Messenger.Default.Send(_WybranaMiejscowosc);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaMiejscowosc;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieMiejscowosciViewModel()
           : base("Miejscowosci")
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
                List = new ObservableCollection<MiejscowosciForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<MiejscowosciForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<MiejscowosciForView>
                (
                    from miej in firmaSpawalniczaEntities.Miejscowoscs
                    select new MiejscowosciForView
                    {
                        Id = miej.Id,
                        Nazwa = miej.Nazwa,
                        DataUtworzenia = miej.KiedyUtworzono,
                        DataModyfikacji = miej.KiedyZmieniono,
                        Aktywny = miej.Aktywny
                    }
                );
        }
        #endregion

    }
}
