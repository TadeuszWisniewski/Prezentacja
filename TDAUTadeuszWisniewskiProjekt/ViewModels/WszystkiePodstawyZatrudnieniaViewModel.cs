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
    public class WszystkiePodstawyZatrudnieniaViewModel : WszystkieViewModel<PodstawaZatrudnieniaForView>
    {
        public PodstawaZatrudnieniaForView _WybranaP;
        public PodstawaZatrudnieniaForView WybranaP
        {
            set
            {
                if (_WybranaP != value)
                {
                    _WybranaP = value;
                    Messenger.Default.Send(_WybranaP);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaP;
            }
        }
        #region Konstruktor
        public WszystkiePodstawyZatrudnieniaViewModel()
           : base("Podstawy zatrudnienia")
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
                List = new ObservableCollection<PodstawaZatrudnieniaForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<PodstawaZatrudnieniaForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<PodstawaZatrudnieniaForView>
                (
                    from p in firmaSpawalniczaEntities.PodstawaZatrudnienia
                    select new PodstawaZatrudnieniaForView
                    {
                        Id = p.Id,
                        Nazwa = p.Nazwa,
                        KiedyUtworzone = p.KiedyUtworzone,                       
                        Aktywny = p.Aktywny
                    }
                );
        }
        #endregion

    }
}
