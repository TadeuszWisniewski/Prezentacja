using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;
using TDAUTadeuszWisniewskiProjekt.Models.Context;
using static System.Net.Mime.MediaTypeNames;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected readonly FirmaSpawalniczaEntities firmaSpawalniczaEntities;
        #endregion

        #region Command
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
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        private BaseCommand _SortCommand; 
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => sort());
                }
                return _SortCommand;
            }
        }
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if(_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => find());
                }
                return _FindCommand;
            }
        }
        #endregion
        #region Kolekcja
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

        #region Properties
        public string SortField { get; set; }
        public List<string> SortComboBoxItems
        {
            get
            {
                return getComboboxSortList();
            }
        }
        public string FindField { get; set; }
        public string FindTextBox {  get; set; }
        
        public List<string> FindComboBoxItems
        {
            get
            {
                return getComboboxFindList();
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;
            firmaSpawalniczaEntities = new FirmaSpawalniczaEntities();
        }
        #endregion

        #region Pomocniczy
        public abstract void load();
        public void add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        public abstract void sort();
        public abstract List<String> getComboboxSortList();
        public abstract void find();
        public abstract List<String> getComboboxFindList();
        #endregion
    }
}
