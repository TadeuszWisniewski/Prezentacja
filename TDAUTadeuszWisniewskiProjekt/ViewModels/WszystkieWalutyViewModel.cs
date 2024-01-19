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
    public class WszystkieWalutyViewModel : WszystkieViewModel<WalutaForView>
    {
        #region Wybrany
        public WalutaForView _WybranaW;
        public WalutaForView WybranaW
        {
            set
            {
                if (_WybranaW != value)
                {
                    _WybranaW = value;
                    Messenger.Default.Send(_WybranaW);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaW;
            }
        }

        #endregion
        #region Konstruktor
        public WszystkieWalutyViewModel()
           : base("Waluty")
        {
        }
        #endregion
        #region Zaladuj
        public override void load()
        {
            List = new ObservableCollection<WalutaForView>
                (
                    from w in firmaSpawalniczaEntities.Waluta
                    select new WalutaForView
                    {
                        Id= w.Id,
                        Nazwa= w.Nazwa,
                        Skrot=w.Skrot,
                        KiedyUtworzono=w.KiedyUtworzono,
                        KiedyZmieniono=w.KiedyZmieniono,
                        Aktywny=w.Aktywny,
                    }
                );
        }
        #endregion

    }
}