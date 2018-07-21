using ATP2016ProjectNew.Model;
using ProjectModel2016;
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

namespace ATP2016ProjectNew.View.Controls
{
    /// <summary>
    /// Interaction logic for DisplayControl.xaml
    /// </summary>
    public partial class DisplayControl : UserControl
    {
        private string m_name;
        private IModel m_model;
        private IView m_view;

        /// <summary>
        /// constructor of display window
        /// </summary>
        public DisplayControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor of display window
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public DisplayControl(IModel model, IView view)
        {
            InitializeComponent();
            m_view = view;
            m_model = model;
        }

        /// <summary>
        /// click display option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void displaymaze_Click(object sender, RoutedEventArgs e)
        {
            string[] parameters = new string[1];
            m_name = NameMaze.Text;
            if (m_name == "")
            {
                MessageBox.Show("The name is empty!");
            }
            else
            {
                parameters[0] = m_name;
                m_view.startEvent(sender, new EventArgMaze(parameters));
                Maze new_maze = m_view.GetMaze();
                if (new_maze != null)
                {
                    MazeWall maze_wall = new MazeWall(new_maze, m_model, m_view);
                    display.Children.Clear();
                    display.Children.Add(maze_wall);
                }
            }
        }
    }
}
