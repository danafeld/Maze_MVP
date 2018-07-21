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
    /// Interaction logic for ArrowControl.xaml
    /// </summary>
    public partial class ArrowControl : UserControl
    {
        /// <summary>
        /// the arrow control
        /// </summary>
        public ArrowControl()
        {
            InitializeComponent();
            kfitz.Source = new BitmapImage(new Uri(string.Concat(Directory.GetCurrentDirectory(), "\\kfitz.png")));
        }
    }
}
