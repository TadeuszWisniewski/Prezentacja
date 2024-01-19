using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TDAUTadeuszWisniewskiProjekt.Views
{
    /// <summary>
    /// Interaction logic for NowaDefinicjaPlatnosciView.xaml
    /// </summary>
    public partial class NowaDefinicjaPlatnosciView : JedenViewBase
    {
        private void TylkoLitery(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");//działa
            e.Handled = regex.IsMatch(e.Text);
        }
        public NowaDefinicjaPlatnosciView()
        {
            InitializeComponent();
        }
    }
}
