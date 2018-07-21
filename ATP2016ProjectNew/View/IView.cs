using ATP2016ProjectNew.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel2016;
using static ATP2016ProjectNew.View.MyView;

namespace ATP2016ProjectNew.View
{
    public delegate void viewEventDelegate();

    public interface IView
    {
        /// <summary>
        /// Event Delegate of view
        /// </summary>
        event ViewEventDelegate ViewChanged;
        /// <summary>
        /// set the dictionary of commands
        /// </summary>
        /// <param name="commands">dictionary of commands</param>
        void SetCommands(Dictionary<string, ACommand> commands);
        /// <summary>
        /// output of the view
        /// </summary>
        /// <param name="s">striong to output</param>
        void Output(string s);
        /// <summary>
        /// event of view change
        /// </summary>
        /// <param name="sender"> object sender</param>
        /// <param name="e"> event args e</param>
        void startEvent(object sender, EventArgs e);
        /// <summary>
        /// set the maze
        /// </summary>
        /// <param name="m">maze to set</param>
        void SetMaze(Maze m);
        /// <summary>
        /// get the maze
        /// </summary>
        /// <returns>maze 3d</returns>
        Maze GetMaze();
        /// <summary>
        /// get the solution of the maze
        /// </summary>
        /// <returns>solution of the maze</returns>
        Solution GetSolution();
        /// <summary>
        /// set the solution
        /// </summary>
        /// <param name="s">soltion to set</param>
        void SetSolution(Solution s);

    }
}
