using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using System.Windows;

namespace ATP2016ProjectNew.Presenter
{
    class ExitCommand : ACommand
    {
        /// <summary>
        /// constructor of the exit
        /// </summary>
        /// <param name="model">interface of model</param>
        /// <param name="view">interface of view</param>
        public ExitCommand(IModel model, IView view) : base(model, view)
        {

        }
        /// <summary>
        /// do the command
        /// </summary>
        /// <param name="parameters">list of paraters</param>
        public override void DoCommand(params string[] parameters)
        {
            m_model.Stop();
            Environment.Exit(0);

        }

    }
}
