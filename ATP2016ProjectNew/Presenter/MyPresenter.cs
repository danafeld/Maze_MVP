using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;

namespace ATP2016ProjectNew.Presenter
{
    public class MyPresenter
    {
        private IModel m_model;
        private IView m_view;
        private Dictionary<string, ACommand> commands;

        /// <summary>
        /// constructor of the Mypresenter
        /// </summary>
        /// <param name="model">interface of model</param>
        /// <param name="view">interface of view</param>
        public MyPresenter(IModel model, IView view)
        {
            m_model = model;
            m_view = view;
            m_view.SetCommands(GetCommands());
            SetEvents();
        }

        /// <summary>
        /// Init the dictionary of the commands
        /// </summary>
        /// <returns>dictionary of the commands</returns>

        public Dictionary<string, ACommand> GetCommands()
        {
            commands = new Dictionary<string, ACommand>();
            ACommand generate3dmaze = new Generate3dMazeCommand(m_model, m_view);
            ACommand savemaze = new SaveMazeCommand(m_model, m_view);
            ACommand loadmaze = new LoadMazeCommand(m_model, m_view);
            ACommand exit = new ExitCommand(m_model, m_view);
            ACommand solvemaze = new SolveMazeCommand(m_model, m_view);
            ACommand displaysolution = new DisplaySolutionCommand(m_model, m_view);
            ACommand displaymaze = new DisplayMazeCommand(m_model, m_view);
            ACommand playmaze = new PlayMazeCommand(m_model, m_view);
            commands.Add("savemaze", savemaze);
            commands.Add("loadmaze", loadmaze);
            commands.Add("exit", exit);
            commands.Add("solvemaze", solvemaze);
            commands.Add("displaysolution", displaysolution);
            commands.Add("displaymaze", displaymaze);
            commands.Add("generate3dmaze", generate3dmaze);
            commands.Add("playmaze", playmaze);
            return commands;
        }

        /// <summary>
        /// set the events of model and view
        /// </summary>
        private void SetEvents()
        {
            m_model.ModelChanged += M_model_ModelChanged;
            m_view.ViewChanged += M_view_ViewChanged;
        }

        /// <summary>
        /// model changed. do the command
        /// </summary>
        /// <param name="model_case">string of model case</param>
        /// <param name="name">name of the maze</param>
        private void M_model_ModelChanged(string model_case, string name)
        {
            if (model_case != null)
            {
                switch (model_case)
                {
                    case "MazeExists":
                        {
                            MessageBox.Show("The maze <" + name + "> is already exist!");
                            break;
                        }

                    case "NameIsntExists":
                        {
                            MessageBox.Show("The maze <" + name + "> is not exist!");
                            break;
                        }

                    case "SolutionExists":
                        {
                            MessageBox.Show("The solution for the maze <" + name + "> is already exist!");
                            break;
                        }

                    case "SolutionIsReady":
                        {
                            MessageBox.Show("The solution for the maze <" + name + "> is ready!");
                            break;
                        }

                    case "MazeIsReady":
                        {
                            MessageBox.Show("The maze <" + name + "> is ready!");
                            break;
                        }

                    case "DisplayMaze":
                        {
                            MessageBox.Show("The maze <" + name + "> is ready!");
                            break;
                        }

                    case "ErrorInDisplayMaze":
                        {
                            MessageBox.Show("The maze coudln't be loaded!");
                            break;
                        }

                    case "ErrorInLoadMaze":
                        {
                            MessageBox.Show("The maze <" + name + "> coudln't be loaded!");
                            break;
                        }

                    case "ErrorInSaveMaze":
                        {
                            MessageBox.Show("The maze <" + name + "> coudln't be saved!");
                            break;
                        }

                    case "ErrorInLoadSolution":
                        {
                            MessageBox.Show("The solution coudln't be loaded!");
                            break;
                        }


                    case "MazeSaved":
                        {
                            MessageBox.Show("The maze <" + name + "> saved succesfully!");
                            break;
                        }

                    case "MazeLoaded":
                        {
                            MessageBox.Show("The maze <" + name + "> loaded succesfully!");
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// the view changed. do the commands
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void M_view_ViewChanged(object sender, EventArgs e)
        {
            string name_command;
            EventArgMaze event_m = e as EventArgMaze;
            if (sender is Button)
            {
                Button s = sender as Button;
                name_command = s.Name;
                commands[name_command].DoCommand(event_m.UserParam);
            }
            else if (sender is MenuItem)
            {
                MenuItem s = sender as MenuItem;
                name_command = s.Name;
                commands[name_command].DoCommand(event_m.UserParam);
            }
        }
    }
}
