using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Context;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class JedenViewModel<T> : WorkspaceViewModel
    {
        #region DB
        //cała db
        protected FirmaSpawalniczaEntities firmaSpawalniczaEntities;//można dodać propertisa tutaj
        //dodawany obiekt
        protected T item;
        #endregion

        #region Command
        private BaseCommand _SaveAndCloseCommand;
        //ta komenda będzie podpięta pod przycisk zapisz i zamknij
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                    //komenda saveandclose uruchamia metode save and close
                    _SaveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _SaveAndCloseCommand;
            }
        }


        #endregion
        
        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;//to jest ustawienie nazwy zkładki
            firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion

        #region Pomocniczy
        //funkcja zapisuje nowy towar do bazy danych
        public void Save()
        {
            //dodanie do lokalnej kolekcji
            firmaSpawalniczaEntities.Add(item);
            //zapisujemy bazy danych
            firmaSpawalniczaEntities.SaveChanges();
        }
        private void SaveAndClose()
        {
            int wynik = Zakoncz();
            if(wynik == 0)
            {
                MessageBox.Show("Wprowadź wszystkie wymagane dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (wynik == 2)
            {
                return;
            }
            //zapisuje nowy obiekt
            Save();
            //zamykamy zakladke
            OnRequestClose();
        }

        public virtual int Zakoncz()
        {
            return -1;
        }
        #endregion
    }
}
