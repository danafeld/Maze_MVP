using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using ATP2016ProjectNew.View;
using ProjectModel2016;
using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.Presenter;
using ATP2016ProjectNew.View.Controls;
using ATP2016ProjectNew.View.Windows;
using Microsoft.Win32;
using System.IO;

namespace ATP2016ProjectNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DockPanel DockPanel_main;
        private IModel m_model;
        private IView m_view;
        private PlayControl play;

        /// <summary>
        /// constructor of main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            m_view = new MyView();
            m_model = new MyModel();
            DockPanel_main = new DockPanel();
            Options.Background = new ImageBrush(new BitmapImage(new Uri(string.Concat(Directory.GetCurrentDirectory(), "\\slide.png"))));
            Grid_generate.Background = new ImageBrush(new BitmapImage(new Uri(string.Concat(Directory.GetCurrentDirectory(), "\\background.png"))));
            MyPresenter presnter = new MyPresenter(m_model, m_view);
            Grid_generate.Children.Add(DockPanel_main);

        }

        /// <summary>
        ///  constructor of main window
        /// </summary>
        /// <param name="model"> model of IModel</param>
        /// <param name="view">view of IView</param>
        public MainWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_view = view;
            m_model = model;
            DockPanel_main = new DockPanel();
            Grid_generate.Children.Add(DockPanel_main);
        }

        /// <summary>
        /// when window is loaded
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> options = new List<string>();
            options.Add("Display Maze");
            options.Add("Solve Maze");
            options.Add("Display Solution");
            options.Add("Get Maze Size");
            options.Add("Play");
            Options.ItemsSource = options;
        }

        /// <summary>
        /// list of selected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// select option chnged
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Options_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = Options.SelectedItem.ToString();
            int IndexStart = selection.IndexOf(":");
            selection = selection.Substring(IndexStart + 2); // after the : and the space, then +2
            switch (selection)
            {
                case "Display Maze":
                    {
                        Grid_generate.Children.Clear();
                        DisplayControl dis_c = new DisplayControl(m_model, m_view);
                        Grid_generate.Children.Add(dis_c);
                        break;
                    }

                case "Display Solution":
                    {
                        Grid_generate.Children.Clear();
                        DisplaySol dis_s = new DisplaySol(m_model, m_view);
                        Grid_generate.Children.Add(dis_s);
                        break;
                    }

                case "Solve Maze":
                    {
                        Grid_generate.Children.Clear();
                        SolveWindow solve_w = new SolveWindow(m_model, m_view);
                        solve_w.Show();
                        break;
                    }

                case "Play":
                    {
                        e.Handled = true;
                        Grid_generate.Focus();
                        Grid_generate.Children.Clear();
                        play = new PlayControl(m_model, m_view);
                        Grid_generate.Children.Add(play);
                        break;
                    }
            }
        }

        /// <summary>
        /// click on new
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void New_Click(object sender, RoutedEventArgs e)
        {
            Grid_generate.Children.Clear();
            GenerateWindow gen_w = new GenerateWindow(m_model, m_view);
            gen_w.Show();

        }

        /// <summary>
        /// click on save
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Grid_generate.Children.Clear();
            SaveWindow save_w = new SaveWindow(m_model, m_view);
            save_w.Show();
        }

        /// <summary>
        /// click on load
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            //Grid_generate.Children.Clear();
            //LoadWindow load_w = new LoadWindow(m_model, m_view);
            //load_w.Show();
            string[] parameters = new string[1];
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "maze only(*.maze)|*.maze";
            if (a.ShowDialog() == true)
            {
                parameters[0] = a.FileNames[0];
                m_view.startEvent(sender, new EventArgMaze(parameters));
            }
        }

        /// <summary>
        /// click on properties
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Properties_Click(object sender, RoutedEventArgs e)
        {
            Grid_generate.Children.Clear();
            PropWindow prop_w = new PropWindow(m_model, m_view);
            prop_w.Show();
        }

        /// <summary>
        /// click on exit
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Grid_generate.Children.Clear();
            ExitWindow exit_w = new ExitWindow(m_view, m_model);
            exit_w.Show();
        }

        /// <summary>
        /// click on help
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Grid_generate.Children.Clear();
            Help_w help_window = new Help_w(m_model, m_view);
            help_window.Show();
        }

        /// <summary>
        /// click on about
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void About_Click(object sender, RoutedEventArgs e)
        {
            Grid_generate.Children.Clear();
            AboutWindow about_window = new AboutWindow(m_model, m_view);
            about_window.Show();
        }

        /// <summary>
        /// click on keyDown play control
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (play != null)
            {
                play.Func(sender, e);
            }
        }
    }
}
