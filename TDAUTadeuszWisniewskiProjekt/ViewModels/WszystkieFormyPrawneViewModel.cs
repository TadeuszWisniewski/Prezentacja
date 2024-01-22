﻿using GalaSoft.MvvmLight.Messaging;
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
    public class WszystkieFormyPrawneViewModel : WszystkieViewModel<FormaPrawnaForView>
    {
        #region Properties
        public FormaPrawnaForView _WybranaF;
        public FormaPrawnaForView WybranaF
        {
            set
            {
                if (_WybranaF != value)
                {
                    _WybranaF = value;
                    Messenger.Default.Send(_WybranaF);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaF;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieFormyPrawneViewModel()
           : base("Formy prawne")
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
                List = new ObservableCollection<FormaPrawnaForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<FormaPrawnaForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<FormaPrawnaForView>
                (
                    from f in firmaSpawalniczaEntities.FormaPrawnas
                    select new FormaPrawnaForView
                    {
                        Id = f.Id,
                        Nazwa= f.Nazwa,
                        KiedyUtworzono=f.KiedyUtworzono,
                        KiedyZmieniono=f.KiedyZmieniono,
                        Aktywny= f.Aktywny,
                    }
                );
        }
        #endregion

    }
}
