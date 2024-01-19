using GalaSoft.MvvmLight.Helpers;
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
    /// Interaction logic for NowyRodzajVATView.xaml
    /// </summary>
    public partial class NowyRodzajVATView : JedenViewBase
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");//działa
            //Regex regex = new Regex("[^0-9]+|null");//Dlaczego nie działa?
            e.Handled = regex.IsMatch(e.Text);
        }
        public NowyRodzajVATView()
        {
            InitializeComponent();
        }
    }
}
