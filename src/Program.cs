using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MazeProjekt
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Guide();
        }

        public static void Guide()
        {
            Console.WriteLine("Welcome to the maze solver!");
            Console.WriteLine("You can add your own mazes by adding them to the mazes folder. \n(.txt file format and x = wall, o = nothing (path), a = player, b = end)");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Choose a maze to solve: (number)");
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mazes");

            try
            {
                string[] files = Directory.GetFiles(directoryPath);
                string[] fileNamesWithoutExtension = files.Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();

                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + fileNamesWithoutExtension[i]);
                }
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Tile[][] map = ReadFormFileMap(files[choice - 1]);
                Console.WriteLine("You chose: " + fileNamesWithoutExtension[choice - 1]);
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
                    BogoWalk.Solve(map);
                }
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

        public static Tile[][] ReadFormFileMap(string filepath)
        {
            using StreamReader ss = new StreamReader(filepath);
            int mapWidth = ss.ReadLine()!.Length;
            int mapHeight = 0;
            while (!ss.EndOfStream)
            {
                ss.ReadLine();
                mapHeight++;
            }
            mapHeight++;

            Tile[][] map = new Tile[mapHeight][];
            for (int i = 0; i < mapHeight; i++)
                map[i] = new Tile[mapWidth];

            using StreamReader sc = new StreamReader(filepath);
            for (int i = 0; i < map.Length; i++)
            {
                string line = sc.ReadLine()!;
                for (int j = 0; j < map[i].Length; j++)
                {
                    map[i][j] = line[j] switch
                    {
                        'x' => new Tile(Items.Wall),
                        'a' => new Tile(Items.Player),
                        'b' => new Tile(Items.End),
                        _ => new Tile(Items.None)
                    };
                }
            }
            return map;
        }
    }
}
