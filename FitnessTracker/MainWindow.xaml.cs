using Microsoft.Win32;
using Smartwatch;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        //Don't close windows unless we're exiting the program just hide these ones
        public Login login;
        public Profile profile;
        //

        SmartWatch sw;

        ObservableCollection<CSVActivity> activityLog = new ObservableCollection<CSVActivity>();


        public MainWindow(Login loginPage)
        {
            InitializeComponent();
            login = loginPage;
            profile = new Profile(this);

            sw = new SmartWatch();

            Activities.ItemsSource = activityLog;

            getTopCalories();
            getTopDistance();
            getTopPerformers();
        }

        private async void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Length > 0)
            {
                await GetActivities(openFileDialog.FileName);
            }
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
            profile.Show();
        }
        public async Task<byte> GetActivities(string filename)
        {
            System.IO.StreamWriter file = new StreamWriter(profile.username + "calories.txt", true);
            string[] splitInfo;
            string input = "";

            using (StreamReader sr = new StreamReader(filename))
            {
                string calorie = null;
                string distance = null;
                while((input = await sr.ReadLineAsync()) != null)
                {
                    splitInfo = input.Split(',');
                    int cals = int.Parse(splitInfo[1]);
                    int dist = int.Parse(splitInfo[2]);
                    activityLog.Add(new CSVActivity(splitInfo[0], cals, dist));
                    profile.calorietbx.Text += cals.ToString();
                    profile.distanceBox.Text += dist.ToString();
                    calorie += cals.ToString();
                    distance += dist.ToString();
                }
                file.Write(calorie);
                file.Write(distance);
            }
            sw = new SmartWatch();
            return 0;
        }

        private void dot1_Checked(object sender, RoutedEventArgs e)
        {
            
            ActivityLog.Visibility = Visibility.Visible;
            Leaderboard.Visibility = Visibility.Hidden;

        }

        private void dot2_Checked(object sender, RoutedEventArgs e)
        {
            ActivityLog.Visibility = Visibility.Hidden;
            Leaderboard.Visibility = Visibility.Visible;

        }

        public void getTopCalories()
        {
            calorieList.Items.Add("joe");
        }
        public void getTopDistance()
        {
            distanceList.Items.Add("kevin");
        }
        public void getTopPerformers()
        {
            performersList.Items.Add("mary");
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            login.Show();
            profile.Hide();
            this.Hide();
        }
    }

}
