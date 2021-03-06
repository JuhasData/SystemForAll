﻿// A simple WPF application, written without XAML.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SystemForAll.User
{
    // In this first example, you are defining a single class type to
    // represent the application itself and the main window.
    class Program : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Handle the Startup and Exit events, and then run the application.
            Program app = new Program();
            app.Startup += AppStartUp;
            app.Exit += AppExit;
            app.Run(); // Fires the Startup event.
        }
        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited");
        }
        static void AppStartUp(object sender, StartupEventArgs e)
        {
            Current.Properties["GodMode"] = false;
            foreach (string arg in e.Args)
            {
                if (arg.ToLower() == "/godmode")
                {
                    Current.Properties["GodMode"] = true;

                    break;

                }
            }

            // Create a Window object and set some basic properties.
            // Create a MainWindow object.
            var main = new MainWindow("My better WPF App!", 200, 300);
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.Show();
        }

        
    }
}
