using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using ProjectModel2016;

namespace ATP2016ProjectNew.Presenter
{
    class DisplaySolutionCommand : ACommand
    {
        /// <summary>
        /// constructor of the  DisplaySolution
        /// </summary>
        /// <param name="model">interface of model</param>
        /// <param name="view">interface of view</param>
        public DisplaySolutionCommand(IModel model, IView view) : base(model, view)
        {
        }

        /// <summary>
        /// do the command
        /// </summary>
        /// <param name="parameters">list of paraters</param>
        public override void DoCommand(params string[] parameters)
        {
            string name = parameters[0];
            Maze m = m_model.getMaze(name);
            if (m == null)
            {
                m_view.Output("The maze <" + name + "> dosent exist!");
            }
            else
            {
                Solution s = m_model.GetSol_DicName_Sol(name);
                if (s == null)
                {
                    m_view.Output("The Solution for the maze <" + name + "> dosent exist!");
                }
                else
                {
                    m_view.SetSolution(s);
                    m_view.SetMaze(m);
                }
            }
        }
    }
}
