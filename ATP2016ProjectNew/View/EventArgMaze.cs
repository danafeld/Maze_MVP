using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016ProjectNew.View
{
    public class EventArgMaze : EventArgs
    {
        private string[] m_UserParamters; // array of string

        /// <summary>
        /// string of get to the parametrs
        /// </summary>
        public string[] UserParam
        {
            get { return m_UserParamters; }
            set { m_UserParamters = value; }
        }

        /// <summary>
        /// change the array string of parameters
        /// </summary>
        /// <param name="user_params">string of array of parameters</param>
        public EventArgMaze(params string[] user_params)
        {
            m_UserParamters = user_params;
        }
    }
}
