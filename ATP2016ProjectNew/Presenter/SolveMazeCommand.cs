using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel2016;

namespace ATP2016ProjectNew.Presenter
{
    class SolveMazeCommand : ACommand
    {
        /// <summary>
        /// constructor of the saveCommand
        /// </summary>
        /// <param name="model">interface of model</param>
        /// <param name="view">interface of the view</param>
        public SolveMazeCommand(IModel model, IView view) : base(model, view)
        {
        }

        /// <summary>
        /// do the command from the menu
        /// </summary>
        /// <param name="parameters">params of the command</param>
        public override void DoCommand(params string[] parameters)
        {
            //Maze maze = parameters[0];
            string name = parameters[0];
            // string alg = parameters[1];
            Maze m = m_model.getMaze(name);
            if (m == null)
            {
                m_view.Output("The maze <" + name + "> doesent exist! ");
            }
            else
            {
                m_model.SolveMaze(m, name);
            }
        }
    }
}
