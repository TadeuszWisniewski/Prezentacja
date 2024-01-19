using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.ViewModels
{
    public class NowyNIPViewModel : WorkspaceViewModel //wszystkie zakladni dziedzicza po WorkSpaceViewModel
    {
        public NowyNIPViewModel()
        {
            base.DisplayName = "NIP"; // to jest ustawienie nazwy zakladki
        }
    }
}
