using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows;

namespace ATP2016ProjectNew
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            MessageBox.Show("Application lunched!");
            //SpeechSynthesizer speech = new SpeechSynthesizer();
            //speech.Speak("Welcome to Maze! please choose from the menu");
            MainWindow main = new MainWindow();
            main.Show();
        }


        protected override void OnExit(ExitEventArgs e)
        {
            MessageBox.Show("You didnt exit right! all the data lost! bye bye!");
        }
    }
}
