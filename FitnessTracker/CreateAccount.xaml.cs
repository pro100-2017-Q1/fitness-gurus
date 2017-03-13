using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace FitnessTracker
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        Login login;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter data;
        private DataSet set;
        // add button to go back to login
        public CreateAccount(Login loginPage)
        {
            InitializeComponent();
            login = loginPage;
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(tbxUsername.Text + ".txt");
            if (tbxUsername.Text != "")
            {
                if(tbxPassword != null)
                {
                    if (tbxFirstName.Text != "")
                    {
                        file.WriteLine(tbxUsername.Text);
                        file.WriteLine(tbxPassword);
                        

                        login.main.profile.username = tbxUsername.Text;
                        login.main.profile.Show();
                        file.Close();
                        this.Hide();
                        
                    }
                }
            }
            if(tbxEmail.Text.Length == 0)
            {
                tbxError.Text = "Enter a valid email.";
                tbxEmail.Text = "Try Again.";
                tbxEmail.Focus();
            }
            if (Regex.IsMatch(tbxEmail.Text, @"[\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*
                                            [a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]"))
            {
                string email = tbxEmail.Text;
                string password = tbxPassword.Password;
                string username = tbxUsername.Text;
               // connection = new SqlConnection();
                data = new SqlDataAdapter();
                set = new DataSet();
               // command = new SqlCommand();
                connection = new SqlConnection("Data Source=Saving;Initial Catalog=Data;User ID=sa;Password=wintellect");
                connection.Open();
                command = new SqlCommand("Insert into CreateAcc (Username,Password,Address) values('" 
                                                                    + email + "','" + password + "')", connection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                connection.Close();
                tbxError.Text = "You have joined successfully.";

            }

            }
        private void tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.Text = string.Empty;
            tbx.GotFocus -= tbx_GotFocus;
        }

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
