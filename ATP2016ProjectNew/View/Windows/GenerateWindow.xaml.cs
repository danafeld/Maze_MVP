using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using ProjectModel2016;
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

namespace ATP2016ProjectNew
{
    /// <summary>
    /// Interaction logic for GenerateWindow.xaml
    /// </summary>
    public partial class GenerateWindow : Window
    {
        private string m_name;
        private int m_width;
        private int m_length;
        private int m_depth;
        private IModel m_model;
        private IView m_view;

        /// <summary>
        /// get the name of maze
        /// </summary>
        public string NameMaze
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// get the width of maze
        /// </summary>
        public int WIDTH
        {
            get { return m_width; }
            set { m_width = value; }
        }

        /// <summary>
        /// set and get of maze length
        /// </summary>
        public int LENGTH
        {
            get { return m_length; }
            set { m_length = value; }
        }

        /// <summary>
        /// set and get of depth maze
        /// </summary>
        public int DEPTH
        {
            get { return m_depth; }
            set { m_depth = value; }
        }

        /// <summary>
        /// set and get od maze model
        /// </summary>
        public IModel MODEL
        {
            get { return m_model; }
        }

        /// <summary>
        /// set and get of view mode
        /// </summary>
        public IView VIEW
        {
            get { return m_view; }
        }

        /// <summary>
        /// constructor of generate window
        /// </summary>
        public GenerateWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor of generate window
        /// </summary>
        /// <param name="view">View IVIEw</param>
        /// <param name="model">model IMOdel</param>
        public GenerateWindow(IModel model, IView view)
        {
            InitializeComponent();
            m_view = view;
            m_model = model;
        }
        /// <summary>
        /// click cancel option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// click generate option button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args e</param>
        private void Genreate_Click(object sender, RoutedEventArgs e)
        {
            string[] parameters = new string[4];
            m_name = NameTextBox.Text;
            if (m_name == "")
            {
                MessageBox.Show("The name is empty!");
            }
            else
            {
                m_depth = Int32.Parse(DepthTextBox.Text);
                m_length = Int32.Parse(LengthTextBox.Text);
                m_width = Int32.Parse(WidthTextBox.Text);
                parameters[0] = m_name;
                parameters[1] = m_length.ToString();
                parameters[2] = m_width.ToString();
                parameters[3] = m_depth.ToString();
                EventArgMaze event_maze = new EventArgMaze(parameters);
                m_view.startEvent(sender, event_maze);
                this.Close();
            }

        }
    }
}
