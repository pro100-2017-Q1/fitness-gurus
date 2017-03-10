﻿using Microsoft.Win32;
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

        ObservableCollection<CSVActivity> activityLog = new ObservableCollection<CSVActivity>();

        public MainWindow(Login loginPage)
        {
            InitializeComponent();
            login = loginPage;
            profile = new Profile(this);

            SmartWatch sw = new SmartWatch();

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
            
            string pattern = @"([A-Za-z]+),([0-9]+),([0-9]+)";
            string input = "";

            using (StreamReader sr = new StreamReader(filename))
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
