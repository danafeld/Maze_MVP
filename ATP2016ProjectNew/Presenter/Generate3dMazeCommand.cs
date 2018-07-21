using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016ProjectNew.Presenter
{
    class Generate3dMazeCommand : ACommand
    {
        /// <summary>
        /// constructor od the ganarate 3d maze
        /// </summary>
        /// <param name="model">interface of the model</param>
        /// <param name="view">interface of the view</param>
        public Generate3dMazeCommand(IModel model, IView view) : base(model, view)
        {
        }

        /// <summary>
        /// do the command from the menu
        /// </summary>
        /// <param name="parameters">params for the command</param>
        public override void DoCommand(params string[] parameters)
        {
            int x, y, z; string name;
            name = parameters[0];
            x = Convert.ToInt32(parameters[1]);
            y = Convert.ToInt32(parameters[2]);
            z = Convert.ToInt32(parameters[3]);
            m_model.GenerateMaze3d(name, x, y, z);
        }
    }
}
