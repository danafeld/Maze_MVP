using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016ProjectNew.Presenter
{
    public abstract class ACommand : ICommand
    {
        protected IModel m_model;
        protected IView m_view;

        /// <summary>
        /// constructor of command
        /// </summary>
        /// <param name="model">Imodel model</param>
        /// <param name="view">Iview view</param>
        public ACommand(IModel model, IView view)
        {
            m_model = model;
            m_view = view;
        }

        /// <summary>
        /// do the command
        /// </summary>
        /// <param name="parameters">list of paraters</param>
        public abstract void DoCommand(params string[] parameters);
    }
}
