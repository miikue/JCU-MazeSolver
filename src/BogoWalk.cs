using System;

namespace MazeProjekt
{
    /// <summary>
    ///  Bogo walk algorithm. (For meme :D)
    ///  Author: Vít Miikue Horčička
    /// </summary>
    internal class BogoWalk : MazeSolver
    {
        public static new int sleepTime = 10;
        /// <summary>
        /// Walks the player randomly through the maze.
        /// </summary>
        /// <param name="map"></param>
        public static void Solve(Tile[][] map)
        {
            // Make player object and set his start position.
            Player player = new Player();
            FindPlayer(map, player);

            // Main loop for the random walk
            Items start = Items.Left;
            while (start != Items.End)
            {
                Console.Clear();
                BogoWalkOneStep(map, ref start, player);
                ReadMap(map);
                System.Threading.Thread.Sleep(sleepTime);
            }
            Console.Clear();
            ReadHeatMap(map);
            Console.WriteLine("I found end and walked " + player.GetSteps() + " steps.");
        }
        /// <summary>
        /// Walks the player randomly through the maze. (With custom sleep time)
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="time"> The sleep time between the steps.</param></param>
        public static void Solve(Tile[][] map, int time)
        {
            sleepTime = time;
            Solve(map);
        }
        /// <summary>
        /// One step of the random walk.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="start"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private static void BogoWalkOneStep(Tile[][] map, ref Items start, Player player)
        {
            int x = player.GetX();
            int y = player.GetY();
            Random rnd = new Random();
            int direction = rnd.Next(0, 4);
            // Randomly choose a direction and check if the player can go there.
            if (FindEnd(map, player))
            {
                start = Items.End;
                return;
            }
            if (direction == 0) // top
            {
                if (x > 0 && map[x - 1][y].GetKindOfTile() == Items.None)
                {
                    map[x - 1][y].SetKindOfTile(Items.Player);
                    player.SetX(x - 1);
                    map[x][y].SetKindOfTile(Items.None);
                }
            }
            else if (direction == 1) // right
            {
                if (y < map[x].Length - 1 && map[x][y + 1].GetKindOfTile() == Items.None)
                {
                    map[x][y + 1].SetKindOfTile(Items.Player);
                    player.SetY(y + 1);
                    map[x][y].SetKindOfTile(Items.None);
                }
            }
            else if (direction == 2) // down
            {
                if (x < map.Length - 1 && map[x + 1][y].GetKindOfTile() == Items.None)
                {
                    map[x + 1][y].SetKindOfTile(Items.Player);
                    player.SetX(x + 1);
                    map[x][y].SetKindOfTile(Items.None);
                }
            }
            else // left
            {
                if (y > 0 && map[x][y - 1].GetKindOfTile() == Items.None)
                {
                    map[x][y - 1].SetKindOfTile(Items.Player);
                    player.SetY(y - 1);
                    map[x][y].SetKindOfTile(Items.None);
                }
            }
        }
    }
}
