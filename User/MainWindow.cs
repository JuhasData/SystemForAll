using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SystemForAll.User
{
    partial class MainWindow : Window
    {

        private Button myBtn = new Button();

        public MainWindow(string windowTitle, int height, int width)
        {
            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;
            this.MouseMove += MainWindow_MouseMove;
            this.Closing += MainWindow_Closing;
            //this.Closed += MainWindow_Closed;

            this.Title = windowTitle;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Height = height;
            this.Width = width;

            myBtn.Height = 25;
            myBtn.Width = 100;
            myBtn.FontSize = 10;
            myBtn.Content = "Exit Application";
            myBtn.Click += new RoutedEventHandler(btnExitApp_Clicked);


            // A fancy brush for the background.
            LinearGradientBrush fancyBruch =
            new LinearGradientBrush(Colors.DarkGreen, Colors.LightGreen, 45);
            myBtn.Background = fancyBruch;
            myBtn.Foreground = new SolidColorBrush(Colors.Yellow);

            // Configure button and set the child control.
            //btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
            //btnExitApp.Content = "Exit Application";
            //btnExitApp.Height = 25;
            //btnExitApp.Width = 100;

            // Set the content of this window to a single button.
            this.Content = myBtn;
        }

        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            // Did user enable /godmode?
            if ((bool)Application.Current.Properties["GodMode"])
            {
                MessageBox.Show("GodMode Out!");
            }
            else
            {
                MessageBox.Show("Good Done");
            }

            this.Close();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // See if the user really wants to shut down this window.
            string msg = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(msg,
            "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure.
                e.Cancel = true;
            }
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya!");
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            // Set the title of the window to the current (x,y) of the mouse.
            this.Title = e.GetPosition(this).ToString();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            // Display key press on the button.
            myBtn.Content = e.Key.ToString();
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {

            // Display key press on the button.
            myBtn.Content = "Exit Application";
        }
    }
}