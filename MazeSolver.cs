using System;

namespace MazeProjekt
{
    /// <summary>
    ///  Bone class for all the maze solving algorithms.
    /// </summary>
     internal class MazeSolver
    {
        public static int sleepTime = 300;
        /// <summary>
        /// Reads the map and prints it to the console.
        /// </summary>
        /// <param name="map">The 2D array of Tile objects representing the generated map</param>
        public static void ReadMap(Tile[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write(map[i][j].ToString());
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Generates a copy of the provided map.
        /// </summary>
        /// <param name="map">The 2D array of Tile objects representing the generated map</param>
        /// <returns>A 2D array of Tile objects representing the copied map.</returns>
        public static Tile[][] CopyMap(Tile[][] map)
        {
            Tile[][] mapCopy = new Tile[map.Length][];
            for (int i = 0; i < map.Length; i++)
            {
                mapCopy[i] = new Tile[map[i].Length];
            }
            for (int i = 0; i < mapCopy.Length; i++)
            {
                for (int j = 0; j < mapCopy[i].Length; j++)
                {
                    mapCopy[i][j] = new Tile(map[i][j].GetKindOfTile());
                }
            }
            return mapCopy;
        }
        /// <summary>
        /// Reads the map and prints it to the console. (Heat map)
        /// <param name="map">The 2D array of Tile objects representing the generated map</param>
        /// </summary>
        public static void ReadHeatMap(Tile[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write(map[i][j].ToStringHeat());
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Finds the player on the map and sets the player's x and y coordinates.
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="player"> Player object.</param>
        public static void FindPlayer(Tile[][] map, Player player)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j].GetKindOfTile() == Items.Player)
                    {
                        player.SetX(i);
                        player.SetY(j);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Simple method checking for nearby end.
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool FindEnd(Tile[][] map, Player player)
        {
            int x = player.GetX();
            int y = player.GetY();
            if (map[x][y + 1].GetKindOfTile() == Items.End)
            {
                map[x][y + 1].SetKindOfTile(Items.Player);
                map[x][y].SetKindOfTile(Items.None);
                player.SetY(y + 1);
                return true;
            }
            else if (map[x][y - 1].GetKindOfTile() == Items.End)
            {
                map[x][y - 1].SetKindOfTile(Items.Player);
                map[x][y].SetKindOfTile(Items.None);
                player.SetY(y - 1);
                return true;
            }
            else if (map[x - 1][y].GetKindOfTile() == Items.End)
            {
                map[x - 1][y].SetKindOfTile(Items.Player);
                map[x][y].SetKindOfTile(Items.None);
                player.SetX(x - 1);
                return true;
            }
            else if (map[x + 1][y].GetKindOfTile() == Items.End)
            {
                map[x + 1][y].SetKindOfTile(Items.Player);
                map[x][y].SetKindOfTile(Items.None);
                player.SetX(x + 1);
                return true;
            }
            return false;
        }
    }
}
