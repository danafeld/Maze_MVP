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
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        private IModel m_model;
        private IView m_view;
        private string m_name;
        /// <summary>
        /// constructior of save window
        /// </summary>
        public SaveWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructior of properties window
        /// </summary>
        ///   /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public SaveWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// click save button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void SaveMaze_Click(object sender, RoutedEventArgs e)
        {
            string[] parameters = new string[2];
            m_name = MazeNameTextBox.Text;
            parameters[0] = m_name;
            if (m_name != "")
            {
                SaveFileDialog saveF = new SaveFileDialog();
                saveF.Filter = "maze only(*.maze)|*.maze";


                if (saveF.ShowDialog() == true)
                {
                    parameters[1] = saveF.FileNames[0];
                    m_view.startEvent(sender, new EventArgMaze(parameters));
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("The name is empty!");
            }
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

