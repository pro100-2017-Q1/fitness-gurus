using Smartwatch;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<CSVActivity> activityLog = new ObservableCollection<CSVActivity>
          {
              new CSVActivity("Walking", 150, 2),
             new CSVActivity("Biking", 300, 3)
         };

        public MainWindow()
        {
            InitializeComponent();

            SmartWatch sw = new SmartWatch();

            Activities.ItemsSource = activityLog;
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Arrow_Click(object sender, RoutedEventArgs e)
        {
            if (ActivityLog.Visibility == Visibility.Visible)
            {
                ActivityLog.Visibility = Visibility.Hidden;
                Leaderboard.Visibility = Visibility.Visible;
                dot1.IsChecked = false;
                dot2.IsChecked = true;
            }
            else
            {
                ActivityLog.Visibility = Visibility.Visible;
                Leaderboard.Visibility = Visibility.Hidden;
                dot1.IsChecked = true;
                dot2.IsChecked = false;
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
    }
}
