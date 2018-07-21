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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATP2016ProjectNew.View.Controls
{
    /// <summary>
    /// Interaction logic for MazeCanvas.xaml
    /// </summary>
    public partial class MazeCanvas : UserControl
    {

        private Maze3d m_maze;
        private int cur_layer;
        private int goal_layer;
        private double cellWidth, cellHeight;
        private PlayerControl m_player;
        private int m_column, m_row;
        private int x, y, z;
        private int Start_x;
        private int Start_y;
        private double ScaleY, ScaleX;

        //for zoom in/out
        ScaleTransform Scale;
        ScrollViewer ScrollerView;
        private double m_ZoomX;
        private double m_ZoomY;
        private bool checkWindow;

        ////for move the object
        private object ObjMove;
        private bool dragged;
        private double downPixels;
        private double rightPixels;
        private double leftPixels;
        private double upPixels;
        public double StartX, StartY, StartAX, StartAY;

        /// <summary>
        /// constructor of maze canvas
        /// </summary>
        /// <param name="maze">Maze maze 3d</param>
        public MazeCanvas(Maze3d maze)
        {
            InitializeComponent();
            m_maze = maze;
            Start_x = m_maze.getStartPosition().X;
            Start_y = m_maze.getStartPosition().Y;
            //m_row = 0;
            //m_column = 0;
            m_row = Start_x;
            m_column = Start_y;
            x = m_maze.MX * 2 - 1;
            y = m_maze.MY * 2 - 1;
            z = m_maze.MZ;
            goal_layer = z - 1;
            cur_layer = 0;

            CreateTheMaze();
            // CreatePlayer();
            RestaerPlayer();

            //for zoom in/out
            m_ZoomX = 1;
            m_ZoomY = 1;

            //this.MouseWheel += new MouseWheelEventHandler(prevMouseWheel);
            this.PreviewMouseWheel += PrevMouseWheel;
            checkWindow = true;

            //
            dragged = false;
            ScrollerView = new ScrollViewer();//
        }
        /// <summary>
        /// write fianl level
        /// </summary>
        /// <returns>string of final level</returns>
        public string writeFinalLevel()
        {
            return "The Goal is in level " + goal_layer.ToString();
        }

        /// <summary>
        /// write the maze sizes
        /// </summary>
        /// <returns>string of sizes</returns>
        public string writeMazeSizes()
        {
            return "The Maze sizes are: (" + m_maze.MX.ToString() + "," + m_maze.MY.ToString() + "," + z.ToString() + ")";
        }

        /// <summary>
        /// write the maze level
        /// </summary>
        /// <returns>string of level</returns>
        public string writeMazeSLevel()
        {
            return "You are in level " + cur_layer.ToString();
        }
        /// <summary>
        /// preveiew the mouse wheel
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void PrevMouseWheel(object sender, MouseWheelEventArgs e)
        {
            bool move = (Keyboard.Modifiers & ModifierKeys.Control) > 0;
            if (!move)
                return;
            if (checkWindow)
            {
                Scale = new ScaleTransform(m_ZoomX, m_ZoomY);
                board_grid.RenderTransform = Scale;
                board_grid.Width = board_grid.ActualWidth;
                board_grid.Height = board_grid.ActualHeight;

                checkWindow = false;
            }
            if (e.Delta < 0)
            {
                m_ZoomX /= 1.1;
                m_ZoomY /= 1.1;
                Scale.ScaleX = m_ZoomX;
                Scale.ScaleY = m_ZoomY;
            }
            else
            {
                m_ZoomX *= 1.1;
                m_ZoomY *= 1.1;
                Scale.ScaleX = m_ZoomX;
                Scale.ScaleY = m_ZoomY;
            }
            if (m_ZoomX < 0.8)
            {
                m_ZoomX = 0.8;
                m_ZoomY = 0.8;
            }
            else if (m_ZoomX > 5)
            {
                m_ZoomX = 5;
                m_ZoomY = 5;
                return;
            }
            board_grid.Width = board_grid.ActualWidth;
            board_grid.Height = board_grid.ActualHeight;
            board_grid.UpdateLayout();

        }

        /// <summary>
        /// when the bottom up
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void mouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ObjMove = null;
            dragged = false;
        }

        /// <summary>
        /// when the buttom down
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Control SenderControl = sender as Control;
            StartX = e.GetPosition(SenderControl).X;
            StartY = e.GetPosition(SenderControl).Y;
            StartAX = e.GetPosition(SenderControl.Parent as Control).X - StartX;
            StartAY = e.GetPosition(SenderControl.Parent as Control).Y - StartY;
            ObjMove = sender;
        }

        /// <summary>
        /// when the mouse move
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                int downB, rightB;
                dragged = true;
                try
                {
                    ScaleX = e.GetPosition((ObjMove as FrameworkElement).Parent as FrameworkElement).X - StartX;
                    ScaleY = e.GetPosition((ObjMove as FrameworkElement).Parent as FrameworkElement).Y - StartY;
                }
                catch
                {
                    MessageBox.Show("Can't move the the mouse");
                }
                upPixels = ScaleY + (cellHeight / 30);
                leftPixels = ScaleX + (cellWidth / 30);
                downPixels = ScaleY + cellHeight - cellHeight / 3;
                downB = ((int)(downPixels / cellHeight));
                rightPixels = ScaleX + cellWidth - cellWidth / 3;
                rightB = ((int)(rightPixels / cellWidth));
                m_column = ((int)(leftPixels / cellWidth));
                m_row = ((int)(upPixels / cellHeight));

                if (ScaleY == 0)
                {
                    m_row = 0;
                }

                if (ScaleX == 0)
                {
                    m_column = 0;
                }

                if (ScaleX < 0)
                {
                    m_column = -1;
                }

                if (ScaleY < 0)
                {
                    m_row = -1;
                }

                if (CheckIfInLimits(m_row, m_column) == false || CheckIfInLimits(downB, m_column) == false || CheckIfInLimits(m_row, rightB) == false || CheckIfWall(m_row, m_column) == true || CheckIfWall(downB, m_column) == true || CheckIfWall(m_row, rightB) == true || CheckIfWall(downB, rightB) == true)
                {
                    dragged = false;
                    return;
                }
                checkIfFinished(m_row, m_column);
                try
                {
                    (ObjMove as FrameworkElement).SetValue(Canvas.LeftProperty, ScaleX);
                    (ObjMove as FrameworkElement).SetValue(Canvas.TopProperty, ScaleY);
                }
                catch
                {
                    MessageBox.Show("Can't Move the Mouse");
                }
            }
        }

        /// <summary>
        /// create the maze
        /// </summary>
        private void CreateTheMaze()
        {
            double PositionX = 0;
            double PositionY = 0;
            Maze2d maze2d = m_maze.MAZE3dArray[cur_layer] as Maze2d;
            for (int row = 0; row < maze2d.MX * 2 - 1; row++)
            {
                PositionX = 0;
                for (int column = 0; column < maze2d.MY * 2 - 1; column++)
                {
                    if (cur_layer == 0 && maze2d.getStartPosition().X == row && maze2d.getStartPosition().Y == column)
                    {
                        StartControl s = new StartControl();
                        s.Width = cellWidth;
                        s.Height = cellHeight;
                        Canvas.SetLeft(s, PositionX);
                        Canvas.SetTop(s, PositionY);
                        PanelDown.Children.Add(s);
                    }

                    else
                    {
                        if (cur_layer == goal_layer && maze2d.getGoalPosition().X == row && maze2d.getGoalPosition().Y == column)
                        {
                            EndControl EndCell = new EndControl();
                            EndCell.Width = cellWidth;
                            EndCell.Height = cellHeight;
                            Canvas.SetLeft(EndCell, PositionX);
                            Canvas.SetTop(EndCell, PositionY);
                            PanelDown.Children.Add(EndCell);
                        }
                        else
                        {
                            if (maze2d.getGoalPosition().X == row && maze2d.getGoalPosition().Y == column)
                            {
                                ArrowControl arrow = new ArrowControl();
                                arrow.Width = cellWidth;
                                arrow.Height = cellHeight;
                                Canvas.SetLeft(arrow, PositionX);
                                Canvas.SetTop(arrow, PositionY);
                                PanelDown.Children.Add(arrow);
                            }
                            else
                            {
                                if (maze2d.MAZE2d[row, column] == 1)
                                {
                                    MazeCell1 wall = new MazeCell1();
                                    wall.Width = cellWidth;
                                    wall.Height = cellHeight;
                                    Canvas.SetLeft(wall, PositionX);
                                    Canvas.SetTop(wall, PositionY);
                                    PanelDown.Children.Add(wall);
                                }

                                else
                                {
                                    if (maze2d.MAZE2d[row, column] == 0)
                                    {
                                        GrassCell grass = new GrassCell();
                                        grass.Width = cellWidth;
                                        grass.Height = cellHeight;
                                        Canvas.SetLeft(grass, PositionX);
                                        Canvas.SetTop(grass, PositionY);
                                        PanelDown.Children.Add(grass);
                                    }

                                }
                            }

                        }
                    }
                    PositionX += cellWidth;
                }
                PositionY += cellHeight;
            }

        }
        /// <summary>
        /// the size changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cellWidth = this.ActualWidth / (m_maze.MY * 2 - 1);
            cellHeight = this.ActualHeight / (m_maze.MX * 2 - 1);
            PanelDown.Children.Clear();
            PanelUp.Width = PanelDown.ActualWidth;
            PanelUp.Height = PanelDown.ActualHeight;
            CreateTheMaze();
            CreatePlayer();

        }

        /// <summary>
        /// when the key is up
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">eventargs e</param>
        public void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            ScaleY = Canvas.GetTop(m_player);
            ScaleX = Canvas.GetLeft(m_player);
            if (Double.IsNaN(ScaleY))
            {
                ScaleY = 0;
            }
            if (Double.IsNaN(ScaleX))
            {
                ScaleX = 0;
            }
            switch (e.Key)
            {
                case Key.Up:
                    {
                        if (CheckIfInLimits(m_row - 1, m_column) == true && CheckIfWall(m_row - 1, m_column) == false)
                        {
                            ScaleY -= cellHeight;
                            m_row--;
                            checkIfFinished(m_row, m_column);
                        }
                        break;
                    }

                case Key.Down:
                    {
                        if (CheckIfInLimits(m_row + 1, m_column) == true && CheckIfWall(m_row + 1, m_column) == false)
                        {
                            ScaleY += cellHeight;
                            m_row++;
                            checkIfFinished(m_row, m_column);
                        }
                        break;
                    }

                case Key.Left:
                    {
                        if (CheckIfInLimits(m_row, m_column - 1) == true && CheckIfWall(m_row, m_column - 1) == false)
                        {
                            ScaleX -= cellWidth;
                            m_column--;
                            checkIfFinished(m_row, m_column);
                        }
                        break;
                    }

                case Key.Right:
                    {
                        if (CheckIfInLimits(m_row, m_column + 1) == true && CheckIfWall(m_row, m_column + 1) == false)
                        {
                            ScaleX += cellWidth;
                            m_column++;
                            checkIfFinished(m_row, m_column);
                        }
                        break;
                    }

                case Key.PageUp:
                    {
                        Maze2d maze2d = ((Maze2d)m_maze.MAZE3dArray[cur_layer]);
                        if (maze2d.getGoalPosition().X == m_row && maze2d.getGoalPosition().Y == m_column)
                        {
                            if (cur_layer == goal_layer)
                            {
                                MessageBox.Show("You are in the final level!");
                            }
                            else
                            {
                                PanelUp.Children.Clear();
                                cur_layer++;
                                CreateTheMaze();
                                CreatePlayer();
                                checkIfFinished(m_row, m_column);
                            }
                        }
                        break;
                    }

                case Key.PageDown:
                    {
                        Maze2d maze2d = ((Maze2d)m_maze.MAZE3dArray[cur_layer]);
                        if (maze2d.getGoalPosition().X == m_row && maze2d.getGoalPosition().Y == m_column)
                        {
                            if (cur_layer == 0)
                            {
                                MessageBox.Show("You are in the lowest level!");
                            }
                            else
                            {
                                PanelUp.Children.Clear();
                                cur_layer--;
                                CreateTheMaze();
                                CreatePlayer();
                                checkIfFinished(m_row, m_column);
                            }
                        }
                        break;
                    }
            }
            Canvas.SetTop(m_player, ScaleY);
            Canvas.SetLeft(m_player, ScaleX);

        }

        /// <summary>
        /// check if finished the maze
        /// </summary>
        /// <param name="row">row in maze</param>
        /// <param name="column">column in maze</param>
        private void checkIfFinished(int row, int column)
        {
            Maze2d maze2d = (Maze2d)(m_maze.MAZE3dArray[cur_layer]);
            if (maze2d.getGoalPosition().X == row && maze2d.getGoalPosition().Y == column && cur_layer == goal_layer)
                MessageBox.Show(" ### Congratulaions! You finished the Maze! ###");
        }
        /// <summary>
        /// create the player
        /// </summary>
        private void CreatePlayer()
        {
            PanelUp.Children.Clear();
            m_player = new PlayerControl();
            //for the mouse move player
            m_player.MouseLeftButtonDown += mouseLeftButtonDown;
            m_player.MouseLeftButtonUp += mouseLeftButtonUp;
            m_player.MouseMove += mouseMove;
            //
            m_player.Width = cellWidth - cellWidth / 3;
            m_player.Height = cellHeight - cellHeight / 3;
            PanelUp.Children.Add(m_player);
            //
            Canvas.SetLeft(m_player, m_column * cellWidth);
            Canvas.SetTop(m_player, m_row * cellHeight);

        }

        /// <summary>
        /// restart the player
        /// </summary>
        private void RestaerPlayer()
        {
            PanelUp.Children.Clear();
            m_player = new PlayerControl();
            m_player.Width = cellWidth - cellWidth / 3;
            m_player.Height = cellHeight - cellHeight / 3;
            PanelUp.Children.Add(m_player);

            Canvas.SetLeft(m_player, m_column);
            Canvas.SetTop(m_player, m_row);

        }

        /// <summary>
        /// check if it is in limits of maze
        /// </summary>
        /// <param name="row">row in maze</param>
        /// <param name="column">column in maze</param>
        /// <returns>true  if there is a wall or false.</returns>
        private bool CheckIfInLimits(int row, int column)
        {
            if (row < 0 || row >= m_maze.MX * 2 - 1 || column >= m_maze.MY * 2 - 1 || column < 0)
                return false;
            return true;
        }

        /// <summary>
        /// check if it is a wall
        /// </summary>
        /// <param name="row">row in maze</param>
        /// <param name="column">column in maze</param>
        /// <returns>true  if there is a wall or false.</returns>
        private bool CheckIfWall(int row, int column)
        {
            Maze2d maze2d = (Maze2d)m_maze.MAZE3dArray[cur_layer];
            if (maze2d.MAZE2d[row, column] == 1)
                return true;
            return false;
        }

    }
}
