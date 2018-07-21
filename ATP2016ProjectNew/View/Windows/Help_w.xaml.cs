using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATP2016ProjectNew.View.Windows
{
    /// <summary>
    /// Interaction logic for Help_w.xaml
    /// </summary>
    public partial class Help_w : Window
    {
        private IModel m_model;
        private IView m_view;

        /// <summary>
        /// click help button
        /// </summary>
        public Help_w()
        {
            InitializeComponent();
        }

        /// <summary>
        /// click help button
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public Help_w(IModel model, IView view)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
            MazeCell1 wall = new MazeCell1();
            GrassCell grass = new GrassCell();
            StepsCell steps = new StepsCell();
            ArrowControl jumper = new ArrowControl();
            StartControl start = new StartControl();
            EndControl end = new EndControl();
            Grass.Children.Add(grass);
            Wall.Children.Add(wall);
            Steps.Children.Add(steps);
            Jumper.Children.Add(jumper);
            Start.Children.Add(start);
            Goal.Children.Add(end);


        }
    }
}
