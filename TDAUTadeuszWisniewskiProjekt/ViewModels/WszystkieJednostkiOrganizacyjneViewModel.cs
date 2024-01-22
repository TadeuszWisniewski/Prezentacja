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
    public class WszystkieJednostkiOrganizacyjneViewModel : WszystkieViewModel<JednostkaOrganizacyjnaForView>
    {
        #region Command
        private JednostkaOrganizacyjnaForView _WybranaJ;
        public JednostkaOrganizacyjnaForView WybranaJ
        {
            set
            {
                if (_WybranaJ != value)
                {
                    _WybranaJ = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranaJ);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaJ;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieJednostkiOrganizacyjneViewModel()
           : base("Jednostki organizacyjne")
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
                List = new ObservableCollection<JednostkaOrganizacyjnaForView>(List.OrderBy(item => item.NazwaJednostkiOrganizacyjnej));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<JednostkaOrganizacyjnaForView>(List.Where(item => item.NazwaJednostkiOrganizacyjnej != null && item.NazwaJednostkiOrganizacyjnej.StartsWith(FindTextBox)));
        }
        public override void load()
        {
            List = new ObservableCollection<JednostkaOrganizacyjnaForView>
                (
                    from jedn in firmaSpawalniczaEntities.JednostkaOrganizacyjnas
                    select new JednostkaOrganizacyjnaForView
                    {
                        Id = jedn.Id,
                        NazwaJednostkiOrganizacyjnej = jedn.NazwaJednostkiOrganizacyjnej,
                        Opis = jedn.Opis,
                        Aktywny = jedn.Aktywny,
                        KiedyUtworzone = jedn.KiedyUtworzone
                    }
                );
        }
        #endregion

    }
}
