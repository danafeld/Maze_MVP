using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace ATP2016ProjectNew
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private IModel m_model;
        private IView m_view;
        /// <summary>
        /// constructior of load window
        /// </summary>
        public LoadWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructior of load window
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public LoadWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// click load button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>

        private void LoadMaze_Click(object sender, RoutedEventArgs e)
        {
            //string[] parameters = new string[1];
            //OpenFileDialog a = new OpenFileDialog();

            //a.Filter = "maze only(*.maze)|*.maze";
            //if (a.ShowDialog() == true)
            //{
            //    parameters[0] = a.FileNames[0];
            //    m_view.startEvent(sender, new EventArgMaze(parameters));
            //}
            this.Close();
          
        }

        /// <summary>
        /// click cancel button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
