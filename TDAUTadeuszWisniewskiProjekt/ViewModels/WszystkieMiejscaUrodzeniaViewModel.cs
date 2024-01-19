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
    public class WszystkieMiejscaUrodzeniaViewModel : WszystkieViewModel<MiejsceUrodzeniaForView>
    {
        private MiejsceUrodzeniaForView _WybraneMiejsce;
        public MiejsceUrodzeniaForView WybraneMiejsce
        {
            get
            {
                return _WybraneMiejsce;
            }
            set
            {
                if(_WybraneMiejsce != value)
                {
                    _WybraneMiejsce = value;
                    Messenger.Default.Send(_WybraneMiejsce);
                    OnRequestClose();
                }
            }
        }
        public WszystkieMiejscaUrodzeniaViewModel() 
            : base("Miejsca urodzenia")
        {
        }
        public override void load()
        {
            List= new ObservableCollection<MiejsceUrodzeniaForView>
                (
                from miejsce in firmaSpawalniczaEntities.MiejsceUrodzenia
                select new MiejsceUrodzeniaForView
                {
                    Id = miejsce.Id,
                    IdMiejscowosc = miejsce.IdMiejscowosc,
                    NazwaMiejscowosci = miejsce.IdMiejscowoscNavigation.Nazwa,
                    Opis = miejsce.Opis,
                    KiedyUtworzone = miejsce.KiedyUtworzone,
                    Aktywny = miejsce.Aktywny
                }
                );

        }
    }
}
