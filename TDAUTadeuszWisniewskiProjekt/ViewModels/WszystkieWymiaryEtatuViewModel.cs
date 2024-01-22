using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieWymiaryEtatuViewModel : WszystkieViewModel<WymiarEtatuForView>
    {
        public WymiarEtatuForView _WybranyW;
        public WymiarEtatuForView WybranyW
        {
            set
            {
                if (_WybranyW != value)
                {
                    _WybranyW = value;
                    Messenger.Default.Send(_WybranyW);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyW;
            }
        }
        #region Konstruktor
        public WszystkieWymiaryEtatuViewModel()
           : base("Wymiary etatu")
        {
        }
        #endregion
        #region Pomocniczy
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "IloscGodzinTygodniowo" };
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<WymiarEtatuForView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "IloscGodzinTygodniowo")
                List = new ObservableCollection<WymiarEtatuForView>(List.OrderBy(item => item.IloscGodzinTygodniowo));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "IloscGodzinTygodniowo" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<WymiarEtatuForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "IloscGodzinTygodniowo")
                List = new ObservableCollection<WymiarEtatuForView>(List.Where(item => item.IloscGodzinTygodniowo != null && item.IloscGodzinTygodniowo == int.Parse(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<WymiarEtatuForView>
                (
                    from w in firmaSpawalniczaEntities.WymiarEtatus
                    select new WymiarEtatuForView
                    {
                        Id = w.Id,
                        Nazwa = w.Nazwa,
                        IloscGodzinTygodniowo = w.IloscGodzinTygodniowo,
                        Aktywny = w.Aktywny,
                        KiedyUtworzono = w.KiedyUtworzono
                    }
                );
        }
        #endregion

    }
}
