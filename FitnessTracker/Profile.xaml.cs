using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace FitnessTracker
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void ProfilePicUpload(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                profilePic.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void saveButton_Click_1(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(nameBox.Text + ".txt");
            Boolean weightAccepted = false;
            Boolean HeightAccepted = false;
            if (weightBox != null)
            {
                weightAccepted = true;
            }
            if (feetBox != null && inchBox != null)
            {
                HeightAccepted = true;
            }
            if (HeightAccepted == true)
            {
                if (weightAccepted == true)
                {
                    file.WriteLine(nameBox.Text);
                    file.WriteLine(ageBox.Text);
                    file.WriteLine(genderBox.Text);
                    file.WriteLine(descBox.Text);
                    file.WriteLine(weightBox.Text);
                    file.WriteLine(feetBox.Text + "''" + inchBox.Text + "'");
                    file.Close();
                }
            }

        }

        private void saveButton2_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(nameBox.Text + ".txt");
            Boolean ageAccepted = false;
            string ageRegex = "([0-9]+)";
            Regex ageR = new Regex(ageRegex);
            string age = ageBox.Text;
            Boolean nameAccepted = false;
            string nameRegex = "([A-Za-z ]+)";
            Regex nameR = new Regex(nameRegex);
            Boolean genderAccepted = false;
            string name = nameBox.Text;
            Match m = nameR.Match(name);
            Match a = ageR.Match(age);
            Boolean desc = false;
            if (m.Success)
            {
                nameAccepted = true;
            }
            if (a.Success)
            {
                ageAccepted = true;
            }
            if ((genderBox.Text == "Male" || genderBox.Text == "Female"))
            {
                genderAccepted = true;
            }
            if (descBox != null)
            {
                desc = true;
            }
            if (genderAccepted == true)
            {
                if (ageAccepted == true)
                {
                    if (nameAccepted == true)
                    {
                        if (desc == true)
                        {
                            file.WriteLine(name);
                            file.WriteLine(age);
                            file.WriteLine(genderBox.Text);
                            file.WriteLine(descBox.Text);
                            file.WriteLine(weightBox.Text);
                            file.WriteLine(feetBox.Text + "''" + inchBox.Text + "'");
                            file.Close();
                        }
                    }
                }
            }
        }
    }
}

