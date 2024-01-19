﻿using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    public class WszystkieDefinicjePlatnosciViewModel : WszystkieViewModel<DefinicjaPlatnosciForView>
    {
        #region Wybrany
        public DefinicjaPlatnosciForView _WybranaD;
        public DefinicjaPlatnosciForView WybranaD
        {
            set
            {
                if (_WybranaD != value)
                {
                    _WybranaD = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranaD);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaD;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieDefinicjePlatnosciViewModel()
           : base("Definicje platnosci")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            List = new ObservableCollection<DefinicjaPlatnosciForView>
                (
                    from d in firmaSpawalniczaEntities.DefinicjaPlatnoscis
                    select new DefinicjaPlatnosciForView
                    {
                        Id=d.Id,
                        Nazwa=d.Nazwa,
                        KiedyUtworzono=d.KiedyUtworzono,
                        KiedyZmieniono=d.KiedyZmieniono,
                        Aktywny=d.Aktywny,
                    }
                );
        }
        #endregion

    }
}
