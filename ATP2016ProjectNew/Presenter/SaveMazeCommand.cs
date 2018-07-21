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
    class SaveMazeCommand : ACommand
    {
        /// <summary>
        /// constructor of the saveMaze
        /// </summary>
        /// <param name="model">interface of model</param>
        /// <param name="view">interface of view</param>
        public SaveMazeCommand(IModel model, IView view) : base(model, view)
        {

        }
        /// <summary>
        /// do the command from the menu
        /// </summary>
        /// <param name="parameters">params for the command</param>
        public override void DoCommand(params string[] parameters)
        {
            string name = parameters[0];
            string filePath = parameters[1];
            m_model.SaveMazeToDisk(name, filePath);
        }
    }
}
