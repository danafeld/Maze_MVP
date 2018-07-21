using System;
using System.Collections.Generic;
using System.IO;
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

namespace ATP2016ProjectNew.View.Controls
{
    /// <summary>
    /// Interaction logic for EndControl.xaml
    /// </summary>
    public partial class EndControl : UserControl
    {
        /// <summary>
        /// end control
        /// </summary>
        public EndControl()
        {
            InitializeComponent();
            goal.Source = new BitmapImage(new Uri(string.Concat(Directory.GetCurrentDirectory(), "\\goal.png")));
        }
    }
}
