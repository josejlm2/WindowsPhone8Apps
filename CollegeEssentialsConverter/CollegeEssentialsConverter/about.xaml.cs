using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
namespace CollegeEssentialsConverter
{
    public partial class about : PhoneApplicationPage
    {
        public about()
        {
            InitializeComponent();
            this.textBlock1.Text = "Version 1.0\r\n\r\nBuilt by Dream the Impossible Studios \r\n\r\n Windows Phone Applications.";
        }

        private void Suggestion_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask emailTask = new Microsoft.Phone.Tasks.EmailComposeTask();
            emailTask.Subject = "Suggestion for COLLEGE ESSENTIALS CONVERTER v1.0";
            emailTask.To = "dreamtheimpossiblestudios@gmail.com";
            emailTask.Show();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri("http://www.windowsphone.com/en-us/store", UriKind.Absolute);
            task.Show();
        }

        private void Learn_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri("http://www.josemanriquez.com", UriKind.Absolute);
            task.Show();
        }
    }
}