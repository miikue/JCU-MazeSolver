using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MazeProjekt
{
    internal class Program
    {
        private static int sleepTime = 700;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // For better looking console output
            // Default walkthrough of the program.
            //Guide();
            // Custom walkthrough of the program.
            Tile[][] map = ReadFormFileMap(@"pathformaze");

            //Tile[][] mapCopy = CopyMap(map);
            BogoWalk.Solve(map, 0);
            Console.ReadKey();

        }
        public static void Guide()
        {
            Console.WriteLine("Welcome to the maze solver!");
            Console.WriteLine("You can add your own mazes by adding them to the mazes folder. \n(.txt file format and x = wall, o = nothing (path), a = player, b = end)");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Choose a maze to solve: (number)");
            string ddirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string directoryPath = ddirectoryPath + @"mazes\";

            try
            {
                string[] files = Directory.GetFiles(directoryPath);
                string[] fileNamesWithoutExtension = files.Select(Path.GetFileNameWithoutExtension).ToArray();


                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine(i+1 + ". " + fileNamesWithoutExtension[i]);
                }
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Tile[][] map = ReadFormFileMap(files[choice-1]);
                Console.WriteLine("You chose: " + fileNamesWithoutExtension[choice-1]);
                Console.WriteLine("1. Left hand rule");
                Console.WriteLine("2. Bogo walk (For meme :D)");
                Console.WriteLine("3. Don't look back");
                Console.WriteLine("Choose a solving algorithm: (number)");
                int choice2 = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (choice2 == 1)
                {
                    LeftHandRule.Solve(map);
                }
                else if (choice2 == 2)
                {
                    BogoWalk.Solve(map);                }
                else if (choice2 == 3)
                {
                    DontLookBack.Solve(map);
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                }
                Console.WriteLine("You can see the heat map of the maze. (How many times the player walked on the tile)");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading files!");
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Generates a map based on the file path provided.
        /// </summary>
        /// <param name="filepath">The file path to generate the map from</param>
        /// <returns>A 2D array of Tile objects representing the generated map</returns>
        public static Tile[][] ReadFormFileMap(string filepath)
        {
            // Read the file to get the dimensions of the map and them close it.
            StreamReader ss = new StreamReader(filepath);
            int mapWidht = ss.ReadLine().Length;
            ss.Close();
            int mapHeight = 0;
            ss = new StreamReader(filepath);
            while (!ss.EndOfStream) 
            {
                ss.ReadLine();
                mapHeight++;
            }
            ss.Close();


            // Create the map array and populate it with Tile objects based on the file contents
            Tile[][] map = new Tile[mapHeight][];
            for (int i = 0; i < mapHeight; i++)
            {
                map[i] = new Tile[mapWidht];
            }


            Tile[,] tiles = new Tile[mapHeight, mapWidht];
            int width = tiles.GetLength(0);
            int height = tiles.GetLength(1);
            Console.WriteLine(width + "w    " + height);
            StreamReader sc = new StreamReader(filepath);
            for (int i = 0; i < map.Length; i++)
            {
                string line = sc.ReadLine();
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (line[j] == 'x')
                    {
                        map[i][j] = new Tile(Items.Wall);
                    }
                    else if (line[j] == 'a')
                    {
                        map[i][j] = new Tile(Items.Player);
                    }
                    else if (line[j] == 'b')
                    {
                        map[i][j] = new Tile(Items.End);
                    }
                    else 
                    {
                        map[i][j] = new Tile(Items.None);
                    }
                }
            }
            sc.Close();
            return map;
        }



    }
}
