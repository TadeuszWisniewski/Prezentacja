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
    public class WszystkieJednostkiViewModel : WszystkieViewModel<JednostkaForView>
    {
        private JednostkaForView _WybranaJ;
        public JednostkaForView WybranaJ
        {
            get
            {
                return _WybranaJ;
            }
            set
            {
                if(_WybranaJ != value)
                {
                    _WybranaJ = value;
                    Messenger.Default.Send(_WybranaJ);
                    OnRequestClose();
                }
            }
        }
        #region Konstruktor
        public WszystkieJednostkiViewModel()
           : base("Jednostki")
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
                List = new ObservableCollection<JednostkaForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<JednostkaForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<JednostkaForView>
                (
                    from j in firmaSpawalniczaEntities.Jednostkas
                    select new JednostkaForView
                    {
                        Id= j.Id,
                        Nazwa= j.Nazwa,
                        KiedyUtworzono=j.KiedyUtworzono,
                        KiedyZmieniono=j.KiedyZmieniono,
                        Aktywny=j.Aktywny
                    }
                );
        }
        #endregion

    }
}
