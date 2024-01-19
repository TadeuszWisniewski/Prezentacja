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
    public class WszystkieJednostkiViewModel : WszystkieViewModel<JednostkaForView>
    {
        private JednostkaForView _WybranaJ;
        public JednostkaForView WybranaJ
        {
            get
            {
                return _WybranaJ;
            }
            set
            {
                if(_WybranaJ != value)
                {
                    _WybranaJ = value;
                    Messenger.Default.Send(_WybranaJ);
                    OnRequestClose();
                }
            }
        }
        #region Konstruktor
        public WszystkieJednostkiViewModel()
           : base("Jednostki")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<JednostkaForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.Jednostkas
                    from j in firmaSpawalniczaEntities.Jednostkas
                    select new JednostkaForView
                    {
                        Id= j.Id,
                        Nazwa= j.Nazwa,
                        KiedyUtworzono=j.KiedyUtworzono,
                        KiedyZmieniono=j.KiedyZmieniono,
                        Aktywny=j.Aktywny
                    }
                );
        }
        #endregion

    }
}
