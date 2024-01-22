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
    public class WszystkieKodyCPVViewModel : WszystkieViewModel<KodCPVForView>
    {
        #region Command
        private KodCPVForView _WybranyCPV;
        public KodCPVForView WybranyCPV
        {
            set
            {
                if (_WybranyCPV != value)
                {
                    _WybranyCPV = value;
                    Messenger.Default.Send(_WybranyCPV);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyCPV;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieKodyCPVViewModel()
           : base("Kody CPV")
        {
        }
        #endregion

        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Kod"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<KodCPVForView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Kod")
                List = new ObservableCollection<KodCPVForView>(List.OrderBy(item => item.Kod));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "Kod" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<KodCPVForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Kod")
                List = new ObservableCollection<KodCPVForView>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<KodCPVForView>
                (
                    from k in firmaSpawalniczaEntities.KodCpvs
                    select new KodCPVForView
                    {
                        Id= k.Id,
                        Nazwa = k.Nazwa,
                        Kod=k.Kod,
                        KiedyUtworzono=k.KiedyUtworzono,
                        KiedyZmieniono=k.KiedyZmieniono,
                        Aktywny=k.Aktywny,
                    }
                );
        }
        #endregion
    }
}
