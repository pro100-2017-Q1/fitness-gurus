﻿using Microsoft.Win32;
using Smartwatch;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

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
            int calories = 0; 
            int distance = 0;
            int.TryParse(profile.calorietbx.Text, out calories);
            int.TryParse(profile.distanceBox.Text, out distance);
            StreamWriter file = new System.IO.StreamWriter(profile.username + "calories.txt");
            string[] splitInfo;
            string input = "";

            using (StreamReader sr = new StreamReader(filename))
            {
                while((input = await sr.ReadLineAsync()) != null)
                {
                    splitInfo = input.Split(',');
                    int cals = int.Parse(splitInfo[1]);
                    int dist = int.Parse(splitInfo[2]);
                    activityLog.Add(new CSVActivity(splitInfo[0], cals, dist));
                    calories += cals;
                    distance += dist;
                }
            }
            sw = new SmartWatch();

            file.WriteLine(calories);
            file.WriteLine(distance);
            file.Close();
            profile.calorietbx.Text = calories.ToString();
            profile.distanceBox.Text = distance.ToString();

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
            calorieList.Items.Add("Joe");
        }
        public void getTopDistance()
        {
            distanceList.Items.Add("Kevin");
        }
        public void getTopPerformers()
        {
            performersList.Items.Add("Mary");
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            profile.Hide();
            this.Hide();
            login.LogOut();
            login.Show();
        }
    }

}
