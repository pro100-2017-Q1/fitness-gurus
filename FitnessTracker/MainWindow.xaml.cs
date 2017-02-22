using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FitnessTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void forgottenPasswordLabel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void loginButtonChanged_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tbxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void tbxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.Text = string.Empty;
            tbx.GotFocus -= tbxUsername_GotFocus;
        }
        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}