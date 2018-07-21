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
    /// Interaction logic for PlayControl.xaml
    /// </summary>
    public partial class PlayControl : UserControl
    {
        private IModel m_model;
        private IView m_view;
        private string m_name;
        private MazeCanvas maze_canv;

        /// <summary>
        /// constructor of play
        /// </summary>
        public PlayControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor of play
        /// </summary>
        ///   /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public PlayControl(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// function of play control, when the key Up
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        public void Func(object sender, KeyEventArgs e)
        {
            if (maze_canv != null)
            {
                maze_canv.Grid_KeyUp(sender, e);
            }

        }
        /// <summary>
        /// click play option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void playmaze_Click(object sender, RoutedEventArgs e)
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
                    Maze3d maze3d = new_maze as Maze3d;
                    maze_canv = new MazeCanvas(maze3d);
                    maze_canv.Focus();
                    display.Children.Clear();
                    display.Children.Add(maze_canv);
                    TextB_MazeWall.Text = maze_canv.writeMazeSLevel(); //"You are in level 0";
                    TextB_GoalPois.Text = maze_canv.writeFinalLevel();
                    TextB_SizeMaze.Text = maze_canv.writeMazeSizes();
                }
            }
        }
    }
}
