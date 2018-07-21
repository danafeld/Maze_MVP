using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModel2016;
using System.Threading;

namespace ATP2016ProjectNew.Model
{
    public delegate void ModelEventDelegate(string model_event, string name);// delegate model event
    public interface IModel
    {
        /// <summary>
        /// model event changed!
        /// </summary>
        event ModelEventDelegate ModelChanged;
        /// <summary>
        /// get solution
        /// </summary>
        /// <param name="maze">name maze</param>
        /// <returns>solution s</returns>
        Solution GetSolution(Maze maze);
        /// <summary>
        /// generate the maze
        /// </summary>
        /// <param name="maze_name">name of maze</param>
        /// <param name="x">dim x</param>
        /// <param name="y">dim y</param>
        /// <param name="z">dim z</param>
        void GenerateMaze3d(string maze_name, int x, int y, int z);
        /// <summary>
        /// save the maze to disk
        /// </summary>
        /// <param name="maze_name">name of maze</param>
        /// <param name="filePath">filepath of string</param>
        void SaveMazeToDisk(string maze_name, string filePath);
        /// <summary>
        /// load the maze
        /// </summary>
        /// <param name="filePath">filepath of string</param>
        void LoadMazeFromDisk(string filePath);
        /// <summary>
        /// solve the maze
        /// </summary>
        /// <param name="maze">maze m</param>
        /// <param name="name">name of maze</param>
        void SolveMaze(Maze maze, string name);
        /// <summary>
        /// get the maze
        /// </summary>
        /// <param name="name">string on name maze</param>
        /// <returns></returns>
        Maze getMaze(string name);
        /// <summary>
        /// check if the solution exist
        /// </summary>
        /// <param name="maze">name of maze</param>
        /// <returns></returns>
        bool checkIfSolutionExist(Maze maze);
        /// <summary>
        /// stop all
        /// </summary>
        void Stop();
        /// <summary>
        /// init the properties
        /// </summary>
        void InitProperties();
        /// <summary>
        /// start the Event 
        /// </summary>
        /// <param name="model_case">string of model case</param>
        /// <param name="name">string of name</param>
        void StartEvent(string model_case, string name);
        /// <summary>
        /// get soltion dic name
        /// </summary>
        /// <param name="name_maze">name of maze</param>
        /// <returns>get the solution</returns>
        Solution GetSol_DicName_Sol(string name_maze);

    }
}
