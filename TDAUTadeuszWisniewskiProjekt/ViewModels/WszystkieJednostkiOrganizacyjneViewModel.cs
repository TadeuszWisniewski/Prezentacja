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
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<JednostkaOrganizacyjnaForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.JednostkaOrganizacyjnas
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
