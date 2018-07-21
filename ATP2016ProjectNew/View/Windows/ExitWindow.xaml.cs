using ATP2016ProjectNew.Model;
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

namespace ATP2016ProjectNew.View
{
    /// <summary>
    /// Interaction logic for ExitWindow.xaml
    /// </summary>
    public partial class ExitWindow : Window
    {
        private IModel m_model;
        private IView m_view;
        /// <summary>
        /// constructor of Exit window
        /// </summary>
        public ExitWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor of Exit window
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public ExitWindow(IView view, IModel model)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// click yes option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            m_view.startEvent(sender, new EventArgMaze("exit"));
            this.Close();
        }

        /// <summary>
        /// click no option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
