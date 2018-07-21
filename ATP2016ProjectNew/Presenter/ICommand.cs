using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016ProjectNew.Presenter
{
    public interface ICommand
    {
        /// <summary>
        /// do the command
        /// </summary>
        /// <param name="parameters">list of paraters</param>
        void DoCommand(params string[] parameters);
    }
}
