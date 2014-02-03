using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LateralMenus.Resources;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Xml.Linq;
using System.IO;
using System.IO.IsolatedStorage;


namespace LateralMenus
{
    public partial class AddBook: PhoneApplicationPage
    {
        public AddBook()
        {
            InitializeComponent();
        }
      
        

        public void book(object sender, System.EventArgs e) 
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
           
            if (isoStore.FileExists("TestStore.txt"))
            {
                Console.WriteLine("The file already exists!");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("TestStore.txt", FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {

                        System.Diagnostics.Debug.WriteLine("Reading contents:");
                        System.Diagnostics.Debug.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            else
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("TestStore.txt", FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine("Hello Isolated Storage");
                        System.Diagnostics.Debug.WriteLine("You have written to the file.");
                    }
                }
            }
        }
            
            /*
            var file = IsolatedStorageFile.GetUserStoreForApplication(); 
            var stream = new IsolatedStorageFileStream("file.xml", FileMode.OpenOrCreate, file);

            XDocument xDoc = new XDocument("test.xml");
            XDocument xDoc2 = XDocument.Load("file.xml");
            var contactsElement = new XElement("Contacts", 
                                         new XElement("Contact",
                                              new XElement("Name", "ABC"),
                                              new XElement("PhoneNumber", "1234"),
                                              new XElement("Email", "abc@abc.com")));
             xDoc2.Add(contactsElement);
             xDoc2.Save(...);*/
        


       

        

       

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        /* double preFlickX;
         double preFlickY;
         bool firstTime = false;
         int id = -1;
         void Touch_FrameReported(object sender, TouchFrameEventArgs e)
         {
             TouchPointCollection tpc = e.GetTouchPoints(canvas);
             if (id == -1)
             {
                 if ((tpc.Count == 1) && (tpc[0].Action == TouchAction.Down))
                 {
                     id = tpc[0].TouchDevice.Id;
                     X = tpc[0].Position.X;
                     preFlickX = Canvas.GetLeft(LayoutRoot);
                     firstTime = true;
                     ((Storyboard)canvas.Resources["moveAnimation"]).Stop();
                 }
             }
             else
             {
                 foreach (var tpoint in tpc)
                     if (tpoint.TouchDevice.Id == id)
                     {
                         var delta = tpoint.Position.X - X;
                         System.Diagnostics.Debug.WriteLine(delta + " " + X + " " + tpoint.Position.X);
                         if ((Math.Abs(delta) > 10) && ((((Storyboard)canvas.Resources["moveAnimation"]).GetCurrentState() == ClockState.Filling) || (((Storyboard)canvas.Resources["moveAnimation"]).GetCurrentState() == ClockState.Stopped)))
                         {
                             if ((Math.Abs(delta) > 50) && (firstTime))
                                 id = -1;
                             else
                             {
                                 firstTime = false;
                                 X = tpoint.Position.X;
                                 ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = Math.Min(Math.Max(-840, Canvas.GetLeft(LayoutRoot) + delta), 0);
                                 ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
                             }

                         }

                         if ((tpoint.Action == TouchAction.Up) || (id == -1))
                         {

                             var left = Canvas.GetLeft(LayoutRoot);
                             id = -1;
                             ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
                             if ((left - preFlickX > 100) || (delta > 50))
                             {
                                 //right flick
                                 if (((VisualStateGroup)VisualStateManager.GetVisualStateGroups(canvas as FrameworkElement)[0]).CurrentState.Name == "RightMenuOpened")
                                 {
                                     ApplicationBar.IsVisible = true;
                                     VisualStateManager.GoToState(this, "Normal", true);
                                 }
                                 else
                                 {
                                     ApplicationBar.IsVisible = false;
                                     VisualStateManager.GoToState(this, "LeftMenuOpened", true);
                                 }
                                 return;
                             }
                             if ((left - preFlickX < -100) || (delta < -50))
                             {
                                 //right flick
                                 if (((VisualStateGroup)VisualStateManager.GetVisualStateGroups(canvas as FrameworkElement)[0]).CurrentState.Name == "LeftMenuOpened")
                                 {
                                     ApplicationBar.IsVisible = true;
                                     VisualStateManager.GoToState(this, "Normal", true);
                                 }
                                 else
                                 {
                                     ApplicationBar.IsVisible = false;
                                     VisualStateManager.GoToState(this, "RightMenuOpened", true);
                                 }
                                 return;
                             }
                             Canvas.SetLeft(LayoutRoot, preFlickX);
                         }
                     }
             }

         }
         double X;*/


    }
}