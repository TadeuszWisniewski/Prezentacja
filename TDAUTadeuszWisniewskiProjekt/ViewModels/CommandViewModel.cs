using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    // kazdy link z menu po lewej stronie jest commandviewmodelem
    public class CommandViewModel : BaseViewModel
    {
        //kazdy comand view model czyli link w menu po lewej stronie ma nazwe i komende ktora wywoluje akcje otworzenia zakladki 
        #region Properties
        public ICommand Command { get; private set; }
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion

    }
}
