using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectModel2016;
using System.Collections;
using System.Collections.Concurrent;
using System.IO.Compression;
using Ionic.Zip;

namespace ATP2016ProjectNew.Model
{
    class MyModel : IModel
    {
        public event ModelEventDelegate ModelChanged;
        private Dictionary<string, Maze> m_DicOfMazes;
        private Dictionary<string, Solution> m_solutions;
        private Dictionary<Maze, Solution> m_mazeAndSolutions;
        private int m_Threads_num;
        private string m_alg;

        /// <summary>
        /// constructor of my model
        /// </summary>
        public MyModel()
        {
            uploadMazesAndSolutions();
            ActivateThreadPool(m_Threads_num);
            InitProperties();
        }

        /// <summary>
        /// init the properties
        /// </summary>
        public void InitProperties()
        {
            m_Threads_num = SettingsMaze.Default.ThreadsNum;
            m_alg = SettingsMaze.Default.Algorithm;
            m_mazeAndSolutions = new Dictionary<Maze, Solution>();
        }

        /// <summary>
        /// build the solution dictionary
        /// </summary>
        private void buildMazeSolutionDictionary()
        {
            m_mazeAndSolutions = new Dictionary<Maze, Solution>();
            if (m_mazeAndSolutions.Count != 0)
            {
                foreach (string mazeName in m_DicOfMazes.Keys)
                {
                    m_mazeAndSolutions[m_DicOfMazes[mazeName]] = m_solutions[mazeName];
                }
            }
        }

        /// <summary>
        /// upload Mazes and Solutions
        /// </summary>
        private void uploadMazesAndSolutions()
        {
            uploadTheMazeZip();
            uploadTheSolutionZip();
            buildMazeSolutionDictionary();
        }

        /// <summary>
        /// Activate the ThreadPool
        /// </summary>
        /// <param name="numThreads">num of threads</param>
        private void ActivateThreadPool(int numThreads)
        {
            // int workerThreads = 5;
            //int completionPortThreads = 5;
            ThreadPool.SetMaxThreads(numThreads, numThreads);
        }

        /// <summary>
        /// upload The MazeZip
        /// </summary>
        private void uploadTheMazeZip()
        {
            if (File.Exists("mazes.zip"))
            {
                m_DicOfMazes = new Dictionary<string, Maze>();
                unZipTheMazes();
            }
            else
            {
                m_DicOfMazes = new Dictionary<string, Maze>();
            }
        }

        /// <summary>
        /// upload The solution zip
        /// </summary>
        private void uploadTheSolutionZip()
        {
            if (File.Exists("solutions.zip"))
            {
                m_solutions = new Dictionary<string, Solution>();
                unZipTheSolutions();
            }
            else
            {
                m_solutions = new Dictionary<string, Solution>();
            }
        }


        /// <summary>
        /// generate 3d maze
        /// </summary>
        /// <param name="maze_name">name of maze</param>
        /// <param name="x">dim x</param>
        /// <param name="y">dim y</param>
        /// <param name="z">dim z</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void GenerateMaze3d(string maze_name, int x, int y, int z)
        {
            RunOfGenerate(maze_name, x, y, z);
        }

        /// <summary>
        /// run the generate 3d maze
        /// </summary>
        /// <param name="maze_name">name of maze</param>
        /// <param name="x">dim x</param>
        /// <param name="y">dim y</param>
        /// <param name="z">dim z</param>
        private void RunOfGenerate(string name, int x, int y, int z)
        {
            if (checkIfNameExist(name))
            {
                ModelChanged("MazeExists", name);
            }
            else
            {
                RunInThreadPoolOfGenerate(name, x, y, z);
            }
        }

        /// <summary>
        /// run the generate 3d maze in thread pool
        /// </summary>
        /// <param name="maze_name">name of maze</param>
        /// <param name="x">dim x</param>
        /// <param name="y">dim y</param>
        /// <param name="z">dim z</param>
        private void RunInThreadPoolOfGenerate(string name, int x, int y, int z)
        {
            ThreadPool.QueueUserWorkItem
            (
                new WaitCallback((state) =>
                {
                    MyMaze3dGenerator maze = new MyMaze3dGenerator();
                    Maze new_maze = maze.generate(x, y, z);
                    if (new_maze != null)
                    {
                        m_DicOfMazes.Add(name, new_maze); // add new maze to dictionary of mazes
                        ModelChanged("MazeIsReady", name);
                    }
                })
            );
        }

        /// <summary>
        /// save the maze to disk
        /// </summary>
        /// <param name="maze_name">name of the file</param>
        /// <param name="filePath">path of the file</param>
        public void SaveMazeToDisk(string maze_name, string filePath)
        {
            if (!checkIfNameExist(maze_name))
            {
                ModelChanged("NameIsntExists", maze_name);
            }
            else
            {
                try
                {
                    Maze3d maze3d = (Maze3d)m_DicOfMazes[maze_name];
                    byte[] inputSource = maze3d.toByteArray();
                    using (MemoryStream input = new MemoryStream(inputSource))
                    {
                        using (FileStream outputStream = new FileStream(filePath, FileMode.Create))
                        {
                            byte[] byteArray = new byte[100];
                            int r = 0;
                            while ((r = input.Read(byteArray, 0, byteArray.Length)) != 0)
                            {
                                outputStream.Write(byteArray, 0, r);
                                outputStream.Flush();
                                byteArray = new byte[100];
                            }
                        }
                    }
                    ModelChanged("MazeSaved", maze_name);
                }
                catch (Exception e)
                {
                    ModelChanged("ErrorInSaveMaze", maze_name);
                }
            }
        }

        /// <summary>
        /// load the maze from the disk
        /// </summary>
        /// <param name="filePath">path of the file</param>
        /// <param name="maze_name">name of the maze</param>
        public void LoadMazeFromDisk(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string mazeName = fileName.Substring(0, fileName.IndexOf('.'));
            try
            {
                using (FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[input.Length];
                    int numBytesToRead = (int)input.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = input.Read(bytes, numBytesRead, numBytesToRead); // Read may return anything from 0 to numBytesToRead.
                        if (n == 0)// Break when the end of the file is reached.
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    Maze3d maze = new Maze3d(bytes);
                    m_DicOfMazes[mazeName] = maze;
                }
                ModelChanged("MazeLoaded", mazeName);
            }
            catch
            {
                ModelChanged("ErrorInLoadMaze", mazeName);
            }
        }

        /// <summary>
        /// if the buffer smaller than 100 add vlaue by value
        /// </summary>
        /// <param name="byteMazeFromFile">list of bytes</param>
        /// <param name="byteFromFile">array of bytes</param>
        /// <param name="read_f">int of read</param>
        private void addToList(List<byte> byteMazeFromFile, byte[] byteFromFile, int read_f)
        {
            int counter = 0;
            while (counter < read_f)
            {
                byteMazeFromFile.Add(byteFromFile[counter]);
                counter++;
            }
        }

        /// <summary>
        /// solve the maze
        /// </summary>
        /// <param name="maze_name">name of the maze</param>
        /// <param name="alg">algorithem to solve the maze</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SolveMaze(Maze maze, string name)
        {
            RunOfSolution(maze, name);
        }


        /// <summary>
        /// rin the solve the maze
        /// </summary>
        /// <param name="maze_name">name of the maze</param>
        /// <param name="alg">algorithem to solve the maze</param>
        private void RunOfSolution(Maze maze, String name)
        {
            if (checkIfSolutionExist(maze))
            {
                ModelChanged("SolutionExists", name);
            }
            else
            {
                RunInThreadPoolOfSolution(maze, name);
            }
        }
        /// <summary>
        /// rin in thread pool the solution
        /// </summary>
        /// <param name="maze_name">name of the maze</param>
        /// <param name="alg">algorithem to solve the maze</param>
        private void RunInThreadPoolOfSolution(Maze maze, string name)
        {
            ThreadPool.QueueUserWorkItem
            (
            new WaitCallback((state) =>
            {
                ASearchingAlgorithm new_alg = checkAlg();
                Maze m_from_dic = m_DicOfMazes[name];
                Maze3d m_3d = m_from_dic as Maze3d;
                SearchableMaze3d maze3dS = new SearchableMaze3d(m_3d);
                Solution maze_solution = new_alg.Solve(maze3dS); // solve the maze

                m_solutions.Add(name, maze_solution); // add to dictionary of solutions
                m_mazeAndSolutions.Add(maze, maze_solution);
                ModelChanged("SolutionIsReady", name);
            })
            );
        }

        /// <summary>
        /// check if the algorithm exist and which algorithm it is
        /// </summary>
        /// <param name="alg">the algorithem to solve the maze</param>
        /// <returns>get the algorithm</returns>
        private ASearchingAlgorithm checkAlg()
        {
            if (m_alg.ToLower() == "bfs")
            {
                BreadthFirstSearch bfs = new BreadthFirstSearch();
                return bfs;
            }

            if (m_alg.ToLower() == "dfs")
            {
                DepthFirstSearch dfs = new DepthFirstSearch();
                return dfs;
            }
            return null;
        }

        /// <summary>
        /// get the maze from the dictionary
        /// </summary>
        /// <param name="name">name of the maze</param>
        /// <returns>the maze from the dictionary</returns>
        public Maze getMaze(string name)
        {
            if (m_DicOfMazes.ContainsKey(name))
                return m_DicOfMazes[name];
            else return null;
        }

        /// <summary>
        /// get the solution of the maze of positions
        /// </summary>
        /// <param name="name">name of the maze</param>
        /// <returns>get the solution of the maze</returns>
        public Solution GetSolution(Maze maze)
        {
            if (m_mazeAndSolutions.ContainsKey(maze))
                return m_mazeAndSolutions[maze];
            else return null;

        }
        /// <summary>
        /// get the solution dictionary name
        /// </summary>
        /// <param name="name_maze">name of maze</param>
        /// <returns>solution s</returns>
        public Solution GetSol_DicName_Sol(string name_maze)
        {
            if (m_solutions.ContainsKey(name_maze))
                return m_solutions[name_maze];
            else return null;

        }

        /// <summary>
        /// check if the solution exist
        /// </summary>
        /// <param name="maze">maze m</param>
        /// <returns>retrun true if the solution exist</returns>
        public bool checkIfSolutionExist(Maze maze)
        {
            if (m_mazeAndSolutions.ContainsKey(maze))
                return true;
            return false;

        }
        /// <summary>
        /// check if the name exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if the name exist</returns>
        private bool checkIfNameExist(string name)
        {
            if (m_DicOfMazes.ContainsKey(name))
                return true;
            return false;
        }

        /// <summary>
        /// check option to move
        /// </summary>
        /// <param name="list">list of move</param>
        /// <param name="x">the x</param>
        /// <param name="y">the y</param>
        /// <returns></returns>
        private string checkOptionToMove(ArrayList list, int x, int y)
        {
            foreach (Position p in list)
            {
                if (p.X > x)
                    return "down";
                if (p.X < x)
                    return "up";
                if (p.Y > y)
                    return "right";
                if (p.Y < y)
                    return "left";

            }
            return null;
        }
        /// <summary>
        /// stop all the things
        /// </summary>
        public void Stop()
        {
            compressZipMaze();
            compressZipSolutions();
        }

        /// <summary>
        /// compress Zip Solutions
        /// </summary>
        private void compressZipSolutions()
        {
            ZipFile zipFile = new ZipFile("Solutions.zip");
            foreach (Solution solution in m_solutions.Values)
            {
                string s = solution.ToString();
                string nameToSave = m_solutions.FirstOrDefault(x => x.Value == solution).Key;
                writeDataToDisk(s, nameToSave);
            }
            foreach (string maze3dName in m_solutions.Keys)
            {
                zipFile.AddFile(maze3dName);
            }
            zipFile.Save();
            deleteAllFiles();
        }

        /// <summary>
        /// change solution to string 
        /// </summary>
        /// <param name="solution">solution s</param>
        /// <returns>string of solution</returns>
        private string solutionTostring(Solution solution)
        {
            string s = "";
            foreach (AState state in solution.GetSolutionPath())
            {
                MazeState Ms = state as MazeState;

                s = s + (Ms.State);
            }
            return s;
        }

        /// <summary>
        /// compress Zip Maze
        /// </summary>
        private void compressZipMaze()
        {
            MyMaze3DCompressor compressor = new MyMaze3DCompressor();
            ZipFile zipFile = new ZipFile("Mazes.zip");
            foreach (Maze3d maze3d in m_DicOfMazes.Values)
            {
                byte[] compressedMaze = maze3d.toByteArray();
                string nameToSave = m_DicOfMazes.FirstOrDefault(x => x.Value == maze3d).Key;
                writeDataToDisk(compressedMaze, nameToSave);
            }
            foreach (string maze3dName in m_DicOfMazes.Keys)
            {
                zipFile.AddFile(maze3dName);
            }
            zipFile.Save();
            deleteAllFiles();
        }

        /// <summary>
        /// write the Data To Disk
        /// </summary>
        /// <param name="obj">object of obj to write</param>
        /// <param name="nameToSave">name to save</param>

        private void writeDataToDisk(object obj, string nameToSave)
        {
            byte[] inputSource;
            if (obj is byte[])
            {
                inputSource = obj as byte[];
            }
            else
            {
                string stringToConvert = obj as string;
                inputSource = Encoding.ASCII.GetBytes(stringToConvert);

            }
            using (MemoryStream input = new MemoryStream(inputSource))
            {
                using (FileStream outputStream = new FileStream(nameToSave, FileMode.Create))
                {
                    byte[] byteArray = new byte[100];
                    int r = 0;
                    while ((r = input.Read(byteArray, 0, byteArray.Length)) != 0)
                    {
                        outputStream.Write(byteArray, 0, r);
                        outputStream.Flush();
                        byteArray = new byte[100];
                    }
                }
            }
        }

        /// <summary>
        /// delete All the Files
        /// </summary>
        private void deleteAllFiles()
        {
            foreach (string mazeName in m_DicOfMazes.Keys)
            {
                File.Delete(mazeName);
            }
        }

        /// <summary>
        /// unZip The Mazes
        /// </summary>
        private void unZipTheMazes()
        {
            if (!File.Exists("Mazes.zip"))
            {
                return;
            }
            using (ZipFile zip = ZipFile.Read("Mazes.zip"))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(ExtractExistingFileAction.OverwriteSilently);
                    uploadMaze(e.FileName);
                }
            }
            deleteAllFiles();
            File.Delete("Mazes.zip");
        }

        /// <summary>
        /// uploade the maze
        /// </summary>
        /// <param name="fileName">name of file</param>
        private void uploadMaze(string fileName)
        {
            using (FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[input.Length];
                int numBytesToRead = (int)input.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = input.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                Maze3d maze = new Maze3d(bytes);
                m_DicOfMazes[fileName] = maze;
            }
        }

        /// <summary>
        ///  unZip The Solutions
        /// </summary>
        private void unZipTheSolutions()
        {
            if (!File.Exists("Solutions.zip"))
            {
                return;
            }
            using (ZipFile zip = ZipFile.Read("Solutions.zip"))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(ExtractExistingFileAction.OverwriteSilently);
                    uploadSolution(e.FileName);
                }
            }
            deleteAllFiles();
            File.Delete("Solutions.zip");
        }

        /// <summary>
        /// upload the solution
        /// </summary>
        /// <param name="fileName">name of file name</param>
        private void uploadSolution(string fileName)
        {
            using (FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[input.Length];
                int numBytesToRead = (int)input.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = input.Read(bytes, numBytesRead, numBytesToRead);// Read may return anything from 0 to numBytesToRead.
                    if (n == 0)   // Break when the end of the file is reached.
                        break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                string data = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    data = data + ((char)bytes[i]).ToString();
                }
                Solution solution = new Solution(data);
                m_solutions[fileName] = solution;
            }
        }

        /// <summary>
        /// start event in model change
        /// </summary>
        /// <param name="model_case">string of case model</param>
        /// <param name="name">string of name maze</param>
        public void StartEvent(string model_case, string name)
        {
            ModelChanged(model_case, name);
        }

    }
}
