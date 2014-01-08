using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CollegeEssentialsConverter.Resources;
using WPET;

namespace CollegeEssentialsConverter
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool convertValue1;
        Settings<string> conversionType = new Settings<string>("ConversionType", "temperature");

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void SetupLabels()
        {
            if (conversionType.Value == "temperature")
            {
                this.PageTitle.Text = "temperature";
                textBlock1.Text = "Fahrenheit";
                textBlock2.Text = "Celsius";
            }
            else
            {
                this.PageTitle.Text = "spoons";
                textBlock1.Text = "Teaspoons";
                textBlock2.Text = "Tablespoons";
            }
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            convertValue1 = true;
            SetupLabels();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            switch (conversionType.Value)
            {
                case "temperature":
                    {
                        if (convertValue1)
                        {
                            textBox2.Text = "";
                            try
                            {
                                double fahrenheightValue = double.Parse(textBox1.Text);
                                double celsiusValue = (fahrenheightValue - 32) * (5.0 / 9.0);
                                textBox2.Text = celsiusValue.ToString("F");
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            textBox1.Text = "";
                            try
                            {
                                double celsiusValue = double.Parse(textBox2.Text);
                                double fahrenheitValue = (celsiusValue * (9.0 / 5.0)) + 32;
                                textBox1.Text = fahrenheitValue.ToString("F");
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;

                case "spoons":
                    {
                        if (convertValue1)
                        {
                            textBox2.Text = "";
                            try
                            {
                                double teaspoons = double.Parse(textBox1.Text);
                                double tablespoons = teaspoons / 3;
                                textBox2.Text = tablespoons.ToString("F");
                            }
                            catch (Exception)
                            {
                                textBlock2.Text = "Error";
                            }
                        }
                        else
                        {
                            textBox1.Text = "";
                            try
                            {
                                double tablespoons = double.Parse(textBox2.Text);
                                double teaspoons = tablespoons * 3;
                                textBox1.Text = teaspoons.ToString("F");
                            }
                            catch (Exception)
                            {
                                textBlock1.Text = "Error";
                            }
                        }
                    }
                    break;
            }
            this.Focus();
        }

        private void Value1_GotFocus(object sender, RoutedEventArgs e)
        {
            convertValue1 = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Value2_GotFocus(object sender, RoutedEventArgs e)
        {
            convertValue1 = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void ChooseTemperatureConversion_Click(object sender, EventArgs e)
        {
            conversionType.Value = "temperature";
            SetupLabels();
        }

        private void ChooseSpoonConversion_Click(object sender, EventArgs e)
        {
            conversionType.Value = "spoons";
            SetupLabels();
        }

        private void About_Click(object sender, EventArgs e)
        { 
            //Navigates to a new page
            NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

    }

}