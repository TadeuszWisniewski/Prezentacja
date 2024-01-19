using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Context;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    //to jest klasa z której będą dziedziczyć wszystkie view modele typu "Wszystkie.."
    //ta klasa jest abstrakcyjna bo zawiera metodę abstrakcyjną
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel
    {
        #region DB
        //to jest obiekt reprezentujący całą bazę danych
        protected readonly FirmaSpawalniczaEntities firmaSpawalniczaEntities;
        #endregion
        #region Command
        //komenda służy do tego żeby ją podłączać pod akcję np: pod naciśnięcie przycisku
        //Pod przycisk podpinamy komendę która wywołuje funkcję load
        public BaseCommand _LoadCommand;
        
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        //To jest komenda która zostanie podpięta pod przycisk '+' do dodawania rekordów 
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    //wywoła ona metodę add()
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        #endregion
        #region Kolekcja
        //tu będziemy przechowywać towary
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                //jak lista jest pusta to ją wypełnię
                if (_List == null)
                {
                    load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Konstruktor


        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;//to jest ustawienie nazwy zkładki
            //tworzę obiekt dostępowwy do bazy danych
            firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion
        #region Pomocniczy
        //ta metoda jest abstrakcyjna bo nie wiemy jak ją napisać w klasie view model a wiemy dopiero w view model
        public abstract void load();
        public void add()
        {
            //ta metoda wyśle przy pomocy messengera z MVVMLight komunikat do main window view model o konieczności otworzenia okna
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
    }
}
