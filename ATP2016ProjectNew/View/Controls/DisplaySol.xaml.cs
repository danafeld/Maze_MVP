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
    /// Interaction logic for DisplaySol.xaml
    /// </summary>
    public partial class DisplaySol : UserControl
    {
        private IModel m_model;
        private IView m_view;
        string m_name;

        /// <summary>
        /// constructor of display solution window
        /// </summary>
        public DisplaySol()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor of display solution  window
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public DisplaySol(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// click display option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void displaysolution_Click(object sender, RoutedEventArgs e)
        {
            string[] parameters = new string[1];
            m_name = Name_Maze_sol.Text;
            if (m_name == "")
            {
                MessageBox.Show("The name is empty!");
            }
            else
            {
                parameters[0] = m_name;
                m_view.startEvent(sender, new EventArgMaze(parameters));
                Maze new_maze = m_view.GetMaze();
                Solution new_sol = m_view.GetSolution();
                if (new_maze != null && new_sol != null)
                {
                    MazeSolution maze_wall_sol = new MazeSolution(new_maze, m_model, m_view, new_sol);
                    display.Children.Add(maze_wall_sol);
                }
            }
        }
    }
}
