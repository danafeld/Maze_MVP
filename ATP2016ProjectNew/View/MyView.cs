using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016ProjectNew.Presenter;
using ProjectModel2016;
using System.Windows;

namespace ATP2016ProjectNew.View
{
    public class MyView : IView
    {
        /// <summary>
        /// fields of the function myView
        /// </summary>
        private Maze m_maze;
        private Solution m_solution;
        public delegate void ViewEventDelegate(object sender, EventArgs e); // evetDelegate
        public event ViewEventDelegate ViewChanged; // event viewCahnged
        Dictionary<string, ACommand> m_commands;

        /// <summary>
        /// output the view
        /// </summary>
        /// <param name="s">string to output</param>
        public void Output(string s)
        {
            MessageBox.Show(s);
        }

        /// <summary>
        /// set the commands dictionary
        /// </summary>
        /// <param name="commands"> dictionary to set</param>
        public void SetCommands(Dictionary<string, ACommand> commands)
        {
            m_commands = commands;
        }

        /// <summary>
        /// start the event view changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event e</param>
        public void startEvent(object sender, EventArgs e)
        {
            ViewChanged(sender, e);
        }

        /// <summary>
        /// change the maze
        /// </summary>
        /// <param name="m">maze m to set</param>
        public void SetMaze(Maze m)
        {
            m_maze = m;
        }

        /// <summary>
        /// get the maze 
        /// </summary>
        /// <returns>maze m</returns>
        public Maze GetMaze()
        {
            return m_maze;
        }

        /// <summary>
        /// change the solution
        /// </summary>
        /// <param name="s">solution to set</param>
        public void SetSolution(Solution s)
        {
            m_solution = s;
        }

        /// <summary>
        /// get the solution
        /// </summary>
        /// <returns>solution of the maze</returns>
        public Solution GetSolution()
        {
            return m_solution;
        }
    }
}
