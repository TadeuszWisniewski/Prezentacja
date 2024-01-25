using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForView>
    {
        #region Command
        private PracownikForView _WybranyP;
        public PracownikForView WybranyP
        {
            set
            {
                if (_WybranyP != value)
                {
                    _WybranyP = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyP);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyP;
            }
        }


        #endregion
        public WszyscyPracownicyViewModel()
            :base("Pracownicy")
        {
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Imie", "Nazwisko" };
        }
        public override void sort()
        {

            if (SortField == "Imie")
                List = new ObservableCollection<PracownikForView>(List.OrderBy(item => item.Imie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<PracownikForView>(List.OrderBy(item => item.Nazwisko));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Imie", "Nazwisko" };
        }
        public override void find()
        {
            if (FindField == "Imie")
                List = new ObservableCollection<PracownikForView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<PracownikForView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<PracownikForView>
                (
                from p in firmaSpawalniczaEntities.Pracowniks
                select new PracownikForView
                {
                    Id = p.Id,
                    Imie=p.Imie,
                    Nazwisko=p.Nazwisko,
                    Pesel=p.Pesel,
                    DataUrodzenia=p.DataUrodzenia,
                    JednostkaOrganizacyjnaNazwa=p.IdJednostkaOrganizacyjnaNavigation.NazwaJednostkiOrganizacyjnej,
                    Stawka=p.Stawka,
                    Aktywny=p.Aktywny,
                    KiedyUtworzone=p.KiedyUtworzone
                }
                ) ;
        }
    }
}
