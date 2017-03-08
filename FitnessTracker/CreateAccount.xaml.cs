﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void createbtn_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(tbxUsername.Text + ".txt");
            if (tbxUsername.Text != "")
            {
                if(passwordtbx != null)
                {
                    if (nametbx.Text != "")
                    {
                        file.WriteLine(tbxUsername.Text);
                        file.WriteLine(passwordtbx);
                        
                        Profile p = new Profile();
                        p.username = tbxUsername.Text;
                        p.Show();
                        file.Close();
                        this.Close();
                        
                    }
                }
            }
            else
            {
                tbxUsername.Text = "Put Something In";
            }
        }
    }
}
