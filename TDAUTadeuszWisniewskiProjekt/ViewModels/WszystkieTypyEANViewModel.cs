using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class WszystkieTypyEANViewModel : WszystkieViewModel<Eantyp>
    {
        #region Konstruktor
        public WszystkieTypyEANViewModel()
           : base("EAN Typy")
        {
        }
        #endregion
        #region Pomocniczy
        public override void load()
        {
            //tworzymy observableCollection inicjując ją towarami
            List = new ObservableCollection<Eantyp>
                (
                    //z bazy danych pobieram wszystkie towary
                    //tu będzie zapytanie Linq które pobierze tylko potrzebne kolumny
                    firmaSpawalniczaEntities.Eantyps
                );
        }
        #endregion

    }
}
