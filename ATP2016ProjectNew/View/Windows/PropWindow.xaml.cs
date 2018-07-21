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

namespace ATP2016ProjectNew.View.Windows
{
    /// <summary>
    /// Interaction logic for PropWindow.xaml
    /// </summary>
    public partial class PropWindow : Window

    {

        private IModel m_model;
        private IView m_view;

        /// <summary>
        /// constructior of properties window
        /// </summary>
        public PropWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructior of properties window
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public PropWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
            Algo.Text = SettingsMaze.Default.Algorithm;
            NumOfThreads.Text = (SettingsMaze.Default.ThreadsNum).ToString();

        }
    }
}
