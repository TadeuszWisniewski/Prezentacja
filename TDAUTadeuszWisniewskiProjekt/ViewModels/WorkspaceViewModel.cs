using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDAUTadeuszWisniewskiProjekt.Helpers;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    //to jest viewModel do odziedziczenia przez viewModele reprezentujace zakladki
    // kazda zakladka bedzie dziedziczyla po workspaceViewModel
    //kazda zakladka ma nazwe i przycisk do zamkniecia
    public class WorkspaceViewModel : BaseViewModel
    {
        #region Pola i wlasciwosci

        public string DisplayName { get; set; } // nazwa zakladki

        private BaseCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(OnRequestClose); //komenda do zamykania zakladki wywoluje funkcje onRequestClose
                return _CloseCommand;
            }
        }

        #endregion

        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion


    }
}


