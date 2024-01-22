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
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa"};
        }
        public override void sort()
        {

            if (SortField == "Nazwa")
                List = new ObservableCollection<MiejsceUrodzeniaForView>(List.OrderBy(item => item.NazwaMiejscowosci));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<MiejsceUrodzeniaForView>(List.Where(item => item.NazwaMiejscowosci != null && item.NazwaMiejscowosci.StartsWith(FindTextBox)));
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
                    KiedyUtworzone = miejsce.KiedyUtworzone,
                    Aktywny = miejsce.Aktywny
                }
                );

        }
    }
}
