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
    public class WszystkieKodyCPVViewModel : WszystkieViewModel<KodCPVForView>
    {
        #region Command
        private KodCPVForView _WybranyCPV;
        public KodCPVForView WybranyCPV
        {
            set
            {
                if (_WybranyCPV != value)
                {
                    _WybranyCPV = value;
                    //Wysyłamy wybranego kontrahenta do okna nowa faktura 
                    Messenger.Default.Send(_WybranyCPV);
                    //zamyka okno
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyCPV;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieKodyCPVViewModel()
           : base("Kody CPV")
        {
        }
        #endregion
       
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<KodCPVForView>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    //firmaSpawalniczaEntities.KodCpvs
                    from k in firmaSpawalniczaEntities.KodCpvs
                    select new KodCPVForView
                    {
                        Id= k.Id,
                        Kod=k.Kod,
                        KiedyUtworzono=k.KiedyUtworzono,
                        KiedyZmieniono=k.KiedyZmieniono,
                        Aktywny=k.Aktywny,
                    }
                );
        }
        #endregion

    }
}
