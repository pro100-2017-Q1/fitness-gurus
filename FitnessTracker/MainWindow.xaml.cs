using Smartwatch;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        private async void Import_Click(object sender, RoutedEventArgs e)
        {
            await GetActivities();
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
        public async Task<object> GetActivities()
        {

            Regex rr = new Regex(@"(w\+),(d+),(d+)");


            string placeholder = "";
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\fitness_data.csv"))
            {
                placeholder = await sr.ReadToEndAsync();
            }



            //while ()
            //{
            Match stuff = rr.Match(placeholder);
            activityLog.Add(new CSVActivity(/*stuff.Value*/ placeholder, 2, 2));
            //}
            return new object();
        }
    }

}
