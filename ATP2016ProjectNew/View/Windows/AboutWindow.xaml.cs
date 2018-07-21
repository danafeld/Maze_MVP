using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View.Controls;
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

namespace ATP2016ProjectNew.View.Windows
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        private IModel m_model;
        private IView m_view;
        /// <summary>
        /// constructor of about window
        /// </summary>
        public AboutWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor of about window
        /// </summary>
        /// <param name="model"> model IModel</param>
        /// <param name="view">view IView</param>
        public AboutWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
            p_backG p = new p_backG();
            player.Children.Add(p);
        }
    }
}
