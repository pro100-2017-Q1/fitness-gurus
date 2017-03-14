using Smartwatch;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace FitnessTracker
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public CreateAccount create;
        public MainWindow main;
        public Login login;
        public Profile profile;
        public ActivityLog activity;
        public Leaderboard leader;
        //

        SmartWatch sw;

        ObservableCollection<CSVActivity> activityLog = new ObservableCollection<CSVActivity>();
        public Login()
        {
            InitializeComponent();
            create = new CreateAccount(this);
            main = new MainWindow(this);
        }

        private void loginButtonChanged_Click(object sender, RoutedEventArgs e)
        {
            main.Show();
            this.Hide();

            // check sql to see if it contains email and password given 
            //string username = tbxUsername.Text;
            //string password = tbxPassword.Password;
            //SqlConnection connect = new SqlConnection();
            //SqlCommand command = new SqlCommand();

            if (tbxEmail.Text == "bradg@gmail.com")
            {
                profile = new Profile();

                sw = new SmartWatch();

                activity.Activities.ItemsSource = activityLog;

                //getTopCalories();
                //getTopDistance();
                //getTopPerformers();
            }
            if (tbxEmail.Text == "danim@gmail.com")
            {
                profile = new Profile();

                sw = new SmartWatch();

                activity.Activities.ItemsSource = activityLog;
            }
           
            else
            {
                profile = new Profile();

                sw = new SmartWatch();

                activity.Activities.ItemsSource = activityLog;
            }

            
        }
        private void tbxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            // username: maximum 8 
        }
        private void tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.Text = string.Empty;
            tbx.GotFocus -= tbx_GotFocus;
        }
        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // password: maximum 8 > validate correct
            // contains one lowercase
            // contains one uppercase
            // contains one number 
            // Regex: 

        }

        private void createAccountLabel_Click(object sender, RoutedEventArgs e)
        {
            create.Show();
            this.Hide();
        }

        //private void newUserLabel_Click(object sender, RoutedEventArgs e)
        //{
        //    CreateAccount c = new FitnessTracker.CreateAccount();
        //    c.Show();
        //    this.Close();
        //}

        public void LogOut()
        {
            main = new MainWindow(this);
        }
    }
}