using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
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
    /// Interaction logic for SolveWindow.xaml
    /// </summary>
    public partial class SolveWindow : Window
    {
        private string m_name;
        private IModel m_model;
        private IView m_view;

        /// <summary>
        /// constructior of solve window
        /// </summary>
        public SolveWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructior of solve window
        /// </summary>
        ///   /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public SolveWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
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

        /// <summary>
        /// click solve button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            string[] para = new string[1];
            m_name = NameTextBox.Text;
            if (m_name == "")
            {
                MessageBox.Show("The name is empty!");
            }
            else
            {
                para[0] = m_name;
                EventArgMaze event_maze = new EventArgMaze(para);
                m_view.startEvent(sender, event_maze);
                this.Close();
            }

        }
    }
}
