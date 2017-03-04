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
        ObservableCollection<CSVActivity> activityLog = new ObservableCollection<CSVActivity>();

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
        }
        public async Task<byte> GetActivities()
        {
            string pattern = @"([A-Za-z]+),([0-9]+),([0-9]+)";
            string input = "";
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\fitness_data.csv"))
            {
                input = await sr.ReadToEndAsync();
            }
                                  
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match m in matches)
            {
                int cals = int.Parse(m.Groups[2].Value);
                int dist = int.Parse(m.Groups[3].Value);
                activityLog.Add(new CSVActivity(m.Groups[1].Value, cals, dist));
            }
            return 0;
        }
    }

}
