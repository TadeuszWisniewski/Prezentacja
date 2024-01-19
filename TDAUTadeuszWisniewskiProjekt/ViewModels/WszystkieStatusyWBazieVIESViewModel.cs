﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
        public class WszystkieStatusyWBazieVIESViewModel : WszystkieViewModel<StatusWBazieVIESForView>
        {
            #region Properties
            public StatusWBazieVIESForView _WybranyS;
            public StatusWBazieVIESForView WybranyS
            {
                set
                {
                    if (_WybranyS != value)
                    {
                        _WybranyS = value;
                        Messenger.Default.Send(_WybranyS);
                        OnRequestClose();
                    }
                }
                get
                {
                    return _WybranyS;
                }
            }
            #endregion
            #region Konstruktor
            public WszystkieStatusyWBazieVIESViewModel()
               : base("Statusy w bazie")
            {
            }
            #endregion
            #region Pomocniczy
            public override void load()
            {
                List = new ObservableCollection<StatusWBazieVIESForView>
                    (
                        from s in firmaSpawalniczaEntities.StatusWbazies
                        select new StatusWBazieVIESForView
                        {
                            Id = s.Id,
                            Nazwa = s.Nazwa,
                            KiedyUtworzono = s.KiedyUtworzono,
                            KiedyZmieniono=s.KiedyZmieniono,
                            Aktywny = s.Aktywny,
                        }
                    );
            }
            #endregion
        }
}