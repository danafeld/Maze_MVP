using ATP2016ProjectNew.Model;
using ATP2016ProjectNew.View.Controls;
using ProjectModel2016;
using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATP2016ProjectNew.View
{
    /// <summary>
    /// Interaction logic for MazeSolution.xaml
    /// </summary>
    public partial class MazeSolution : UserControl
    {
        private IModel m_model;
        private IView m_view;
        private Maze m_maze;
        private String m_name;
        static int m_layer;
        Solution m_solution;
        Dictionary<int, Grid> m_layerOfGrid; // list of maze 2d - MazeWall
        /// <summary>
        /// construcotr of maze solution
        /// </summary>
        public MazeSolution()
        {
            InitializeComponent();
        }
        /// <summary>
        /// construcotr of maze solution
        /// </summary>
        /// <param name="maze">maze m</param>
        /// <param name="model">IModel model</param>
        /// <param name="view">IView view</param>
        /// <param name="sol">Solution sol</param>
        public MazeSolution(Maze maze, IModel model, IView view, Solution sol)
        {
            InitializeComponent();
            m_model = model;
            m_view = view;
            m_maze = maze;
            Maze3d maze3d = maze as Maze3d;
            int Dim_x = maze3d.MX;
            int Dim_y = maze3d.MY;
            int Dim_z = maze3d.MZ;
            m_layerOfGrid = new Dictionary<int, Grid>();
            m_layer = 0;
            m_solution = sol;
            CreateMazeGrid(Dim_x, Dim_y, 0);
            colorMazeWall(m_layerOfGrid[0], ((Maze2d)maze3d.MAZE3dArray[0]), 0, Dim_z, sol);
            int level_maze_xmal = Dim_z - 1;
            TextB_GoalPois.Text = "The Goal is in level " + level_maze_xmal.ToString();
            TextB_SizeMaze.Text = "The Maze sizes are: (" + (Dim_x * 2 - 1).ToString() + "," + (Dim_y * 2 - 1).ToString() + "," + Dim_z.ToString() + ")";
        }

        /// <summary>
        /// create the maze grid
        /// </summary>
        /// <param name="x">dim x</param>
        /// <param name="y">dim y</param>
        /// <param name="z">dim z</param>
        private void CreateMazeGrid(int x, int y, int z)
        {
            Grid mazeGrid = new Grid();
            for (int row = 0; row < x * 2 - 1; row++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                mazeGrid.RowDefinitions.Add(r);
            }
            for (int column = 0; column < y * 2 - 1; column++)
            {
                ColumnDefinition c = new ColumnDefinition();
                c.Width = new GridLength(1, GridUnitType.Star);
                mazeGrid.ColumnDefinitions.Add(c);
            }
            m_layerOfGrid[z] = mazeGrid;
            DockP_MSOL.Children.Add(mazeGrid);
        }

        /// <summary>
        /// color the maze
        /// </summary>
        /// <param name="mazewall2d">maze 2d</param>
        /// <param name="maze">maze 3d m</param>
        /// <param name="curr_layer">current layer</param>
        /// <param name="final_layer">final layer</param>
        /// <param name="s">name of maze</param>
        private void colorMazeWall(Grid mazewall2d, Maze maze, int curr_layer, int final_layer, Solution s)
        {
            Maze2d maze2d = maze as Maze2d;
            ArrayList list_pos_sol = getSolution(maze, s);
            MarkGrid(list_pos_sol, maze2d, curr_layer);
            for (int row = 0; row < maze2d.MX * 2 - 1; row++)
            {
                for (int column = 0; column < maze2d.MY * 2 - 1; column++)
                {
                    if (curr_layer == 0 && maze2d.getStartPosition().X == row && maze2d.getStartPosition().Y == column)
                    {
                        StartControl StartCell = new StartControl();
                        Grid.SetColumn(StartCell, column);
                        Grid.SetRow(StartCell, row);
                        mazewall2d.Children.Add(StartCell);
                    }

                    else
                    {
                        if (curr_layer == final_layer - 1 && maze2d.getGoalPosition().X == row && maze2d.getGoalPosition().Y == column)
                        {
                            EndControl EndCell = new EndControl();
                            Grid.SetColumn(EndCell, column);
                            Grid.SetRow(EndCell, row);
                            mazewall2d.Children.Add(EndCell);
                        }
                        else
                        {
                            if (maze2d.MAZE2d[row, column] == 1)
                            {
                                MazeCell1 CellWall = new MazeCell1();
                                Grid.SetColumn(CellWall, column);
                                Grid.SetRow(CellWall, row);
                                mazewall2d.Children.Add(CellWall);
                            }

                            else
                            {
                                if (maze2d.MAZE2d[row, column] == 0)
                                {
                                    GrassCell grassCell = new GrassCell();
                                    Grid.SetColumn(grassCell, column);
                                    Grid.SetRow(grassCell, row);
                                    mazewall2d.Children.Add(grassCell);
                                }

                                else
                                {
                                    if (maze2d.MAZE2d[row, column] == 2)
                                    {
                                        StepsCell StepCell = new StepsCell();
                                        Grid.SetColumn(StepCell, column);
                                        Grid.SetRow(StepCell, row);
                                        mazewall2d.Children.Add(StepCell);
                                    }
                                }

                            }
                        }
                    }

                }

            }
            m_layerOfGrid[curr_layer] = mazewall2d;
        }

        /// <summary>
        /// get the solution
        /// </summary>
        /// <param name="maze">maze m</param>
        /// <param name="s">solution s</param>
        /// <returns></returns>
        private ArrayList getSolution(Maze maze, Solution s)
        {
            ArrayList positions_sol = new ArrayList();
            ArrayList states = s.GetSolutionPath();
            foreach (AState state in states)
            {
                MazeState ms = state as MazeState;
                Position p = ms.Position;
                positions_sol.Add(p);
            }
            return positions_sol;
        }
        /// <summary>
        /// mark the grid
        /// </summary>
        /// <param name="list_pos">array list of positions</param>
        /// <param name="maze2d">maze2d maze</param>
        /// <param name="curr_layer">current layer</param>
        private void MarkGrid(ArrayList list_pos, Maze2d maze2d, int curr_layer)
        {
            int x;
            int y;
            ArrayList new_a = new ArrayList();
            new_a = addPoints(list_pos);
            foreach (Position p in new_a)
            {
                x = (p.X);
                y = (p.Y);
                if (curr_layer == p.Z)
                {
                    if (p.X == 0)
                    {
                        x = 0;
                    }
                    if (p.Y == 0)
                    {
                        y = 0;
                    }
                    maze2d.MAZE2d[x, y] = 2;
                }
            }
        }

        /// <summary>
        /// check and add the points to solution
        /// </summary>
        /// <param name="list_pos">list of positions</param>
        /// <returns>array list of positions</returns>
        private ArrayList addPoints(ArrayList list_pos)
        {
            Position prev = null;
            ArrayList new_list = new ArrayList();
            List<Position> list_p = new List<Position>();
            foreach (Position p in list_pos)
            {
                list_p.Add(p);
            }

            List<Position> added = new List<Position>();
            int count = list_p.Count();
            int i = 0;
            while (i < count)
            {
                if (prev != null)
                {
                    if (prev.Z == list_p[i].Z)
                    {
                        if (prev.X + 2 == list_p[i].X)
                        {
                            added.Add(new Position(prev.X + 1, prev.Y, list_p[i].Z));
                        }

                        if (prev.X - 2 == list_p[i].X)
                        {
                            added.Add(new Position(prev.X - 1, prev.Y, list_p[i].Z));
                        }

                        if (prev.Y + 2 == list_p[i].Y)
                        {
                            added.Add(new Position(prev.X, prev.Y + 1, list_p[i].Z));
                        }

                        if (prev.Y - 2 == list_p[i].Y)
                        {
                            added.Add(new Position(prev.X, prev.Y - 1, list_p[i].Z));
                        }
                    }
                }
                prev = list_p[i];
                i++;
            }

            list_p.AddRange(added);
            i = 0;
            new_list.AddRange(list_p);
            return new_list;
        }

        /// <summary>
        /// click down button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs e</param>
        private void button_down_Click(object sender, RoutedEventArgs e)
        {
            Maze3d maze = m_maze as Maze3d;
            if (m_layer == 0)
            {
                MessageBox.Show("This is the Minimum level!");
            }
            else
            {
                m_layer--;
                DockP_MSOL.Children.Clear();
                if (m_layerOfGrid.ContainsKey(m_layer))
                {
                    TextB_MazeSol.Text = "You are in level " + m_layer;
                    DockP_MSOL.Children.Add(m_layerOfGrid[m_layer]);
                }
                else
                {
                    CreateMazeGrid(m_maze.MX, m_maze.MY, m_layer);
                    colorMazeWall(m_layerOfGrid[m_layer], ((Maze2d)maze.MAZE3dArray[m_layer]), m_layer, m_maze.MZ, m_solution);
                    TextB_MazeSol.Text = "You are in level " + m_layer;
                }
            }
        }

        /// <summary>
        /// click  up button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs e</param>
        private void button_up_Click(object sender, RoutedEventArgs e)
        {
            Maze3d maze = m_maze as Maze3d;
            if (m_layer == m_maze.MZ - 1 || m_maze.MZ == 0 || m_maze.MZ == 1)
            {
                MessageBox.Show("This is the Maximun level!");
                return;
            }
            else
            {
                m_layer++;
                DockP_MSOL.Children.Clear();
                if (m_layerOfGrid.ContainsKey(m_layer))
                {
                    DockP_MSOL.Children.Add(m_layerOfGrid[m_layer]);
                    TextB_MazeSol.Text = "You are in level " + m_layer;
                }
                else
                {
                    CreateMazeGrid(m_maze.MX, m_maze.MY, m_layer);
                    colorMazeWall(m_layerOfGrid[m_layer], ((Maze2d)maze.MAZE3dArray[m_layer]), m_layer, m_maze.MZ, m_solution);
                    TextB_MazeSol.Text = "You are in level " + m_layer;
                }
            }
        }
    }

}
