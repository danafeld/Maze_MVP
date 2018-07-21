using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016ProjectNew.Presenter
{
    class LoadMazeCommand : ACommand
    {
        /// <summary>
        /// constructor of load the maze
        /// </summary>
        /// <param name="model">interface of the model</param>
        /// <param name="view">interface of the view</param>
        public LoadMazeCommand(IModel model, IView view) : base(model, view)
        {

        }

        /// <summary>
        /// do the command from the menu
        /// </summary>
        /// <param name="parameters">params for the command</param>
        public override void DoCommand(params string[] parameters)
        {
            string path = parameters[0];
            m_model.LoadMazeFromDisk(path);
        }
    }
}
