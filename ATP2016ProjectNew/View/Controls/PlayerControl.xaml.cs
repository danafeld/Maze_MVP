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

namespace ATP2016ProjectNew.View
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        /// <summary>
        /// control of player
        /// </summary>
        public PlayerControl()
        {
            InitializeComponent();
            player.Source = new BitmapImage(new Uri(string.Concat(Directory.GetCurrentDirectory(), "\\Player.png")));
        }
    }
}
