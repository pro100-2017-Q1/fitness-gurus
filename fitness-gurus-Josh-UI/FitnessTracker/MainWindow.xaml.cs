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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace FitnessTracker
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(nametbx.Text + ".txt");
            Boolean ageAccepted = false;
            string ageRegex = "([0-9]+)";
            Regex ageR = new Regex(ageRegex);
            string age = agetbx.Text;
            Boolean nameAccepted = false;
            string nameRegex = "([A-Za-z ]+)";
            Regex nameR = new Regex(nameRegex);
            Boolean genderAccepted = false;
            Boolean weightAccepted = false;
            Boolean HeightAccepted = false;
            string name = nametbx.Text;
            Match m = nameR.Match(name);
            Match a = ageR.Match(age);
            Boolean desc = false;
            if (weighttbx != null)
            {
                weightAccepted = true;
            }
            if (heighttbx != null)
            {
                HeightAccepted = true;
            }
            if (m.Success)
            {
                nameAccepted = true;
            }
            if (a.Success)
            {
                ageAccepted = true;
            }
            if ((gendertbx.Text == "Male" || gendertbx.Text == "Female"))
            {
                genderAccepted = true;
            }
            if (desctbx != null)
            {
                desc = true;
            }
            if (genderAccepted == true)
            {
                if (HeightAccepted == true)
                {
                    if (weightAccepted == true)
                    {
                        if (ageAccepted == true)
                        {
                            if (nameAccepted == true)
                            {
                                file.WriteLine(name);
                                file.WriteLine(age);
                                file.WriteLine(weighttbx.Text);
                                file.WriteLine(heighttbx.Text);
                                file.WriteLine(gendertbx.Text);
                                file.WriteLine(desctbx.Text);
                                file.Close();
                            }
                        }
                    }
                }
            }
        }

        private void loadbtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", "C:\\Users\\Jochi\\Desktop\\fitness-gurus-Josh-UI\\FitnessTracker\\bin\\Debug\\" + nametbx.Text + ".txt");
            
        }
    }
}