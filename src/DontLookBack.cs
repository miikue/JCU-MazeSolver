using System;
using System.Collections.Generic;

namespace MazeProjekt
{
    /// <summary>
    /// DontLookBack algorithm.
    /// Author: Vít Miikue Horčička
    /// </summary>
    internal class DontLookBack : MazeSolver
    {
        /// <summary>
        /// Walks the player through the maze using the DontLookBack algorithm. (The player never goes back where he already was.)
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        public static void Solve(Tile[][] map)
        {
            // Make player object and set his start position.
            Player player = new Player();
            FindPlayer(map, player);

            // Main loop for the DontLookBack walk
            Items start = Items.Left;
            while (start != Items.End)
            {
                Console.Clear();
                DontLookBackOneStep(map, player, ref start);
                ReadMap(map);
                System.Threading.Thread.Sleep(sleepTime);
            }
            Console.Clear();
            ReadHeatMap(map);
            Console.WriteLine("I found end and walked " + player.GetSteps() + " steps.");
        }
        /// <summary>
        /// Walks the player through the maze using the DontLookBack algorithm.(With custom sleep time)
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="time"> The sleep time between the steps.</param></param>
        public static void Solve(Tile[][] map, int time)
        {
            sleepTime = time;
            Solve(map);
        }
        /// <summary>
        /// One step of the DontLookBack algorithm.
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="player"> Player object.</param>
        /// <param name="start"> The start position of the player.</param>
        private static void DontLookBackOneStep(Tile[][] map, Player player, ref Items start)
        {
            // Check all awailable directions.
            var directions = DirectionsToChoose(map, player, 1);
            int[] xx = directions.Item1;
            int[] yy = directions.Item2;
            if (xx.Length == 0) // If there is no awailable directions go back.
            {
                directions = DirectionsToChoose(map, player, 2);
                xx = directions.Item1;
                yy = directions.Item2;
                map[player.GetX()][player.GetY()].SetKindOfTile(Items.Player); // Fix tile under player. (Can get stuck without this)
                if (xx.Length == 0) // Fix For the case when the player is stuck in chicken leg like maze situation.
                {
                    directions = DirectionsToChoose(map, player, 3);
                    xx = directions.Item1;
                    yy = directions.Item2;
                    map[player.GetX()][player.GetY()].SetKindOfTile(Items.Player);
                    if (xx.Length == 0)  // Fix For the case when the player is stuck in x like maze situation.
                    {
                        directions = DirectionsToChoose(map, player, 4);
                        xx = directions.Item1;
                        yy = directions.Item2;
                        map[player.GetX()][player.GetY()].SetKindOfTile(Items.Player);
                        if (xx.Length == 0) Console.WriteLine("I'm stuck!"); return;
                    }

                }
            }
            // Check if the player is at the end.
            int x = player.GetX();
            int y = player.GetY();
            if (map[x + 1][y].GetKindOfTile() == Items.End)
            {
                start = Items.End;
                map[x + 1][y].SetKindOfTile(Items.Player);
                map[player.GetX()][player.GetY()].SetKindOfTile(Items.None);
                return;
            }
            else if (map[x - 1][y].GetKindOfTile() == Items.End)
            {
                start = Items.End;
                map[x - 1][y].SetKindOfTile(Items.Player);
                map[player.GetX()][player.GetY()].SetKindOfTile(Items.None);
                return;
            }
            else if (map[x][y + 1].GetKindOfTile() == Items.End)
            {
                start = Items.End;
                map[x][y + 1].SetKindOfTile(Items.Player);
                map[player.GetX()][player.GetY()].SetKindOfTile(Items.None);
                return;
            }
            else if (map[x][y - 1].GetKindOfTile() == Items.End)
            {
                start = Items.End;
                map[x][y - 1].SetKindOfTile(Items.Player);
                map[player.GetX()][player.GetY()].SetKindOfTile(Items.None);
                return;
            }

            // Choose a random direction and go there.
            Random random = new Random();
            int direction = random.Next(0, xx.Length);
            map[xx[direction]][yy[direction]].SetKindOfTile(Items.Player);
            map[player.GetX()][player.GetY()].SetKindOfTile(Items.None);
            player.SetX(xx[direction]);
            player.SetY(yy[direction]);
        }
        /// <summary>
        /// Returns the directions in which the player can go.
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="player"> Player object.</param>
        /// <param name="maxStep"> the maximum number of steps on tile to be able to go there.</param>
        /// <returns> Arrays of x and y coordinates where the player can go.</returns>
        private static (int[], int[]) DirectionsToChoose(Tile[][] map, Player player, int maxStep)
        {
            int x = player.GetX();
            int y = player.GetY();
            List<int> directionsx = new List<int>();
            List<int> directionsy = new List<int>();
            if (map[x][y - 1].GetKindOfTile() == Items.None && map[x][y - 1].GetStep() < maxStep)
            {
                directionsx.Add(x);
                directionsy.Add(y - 1);
            }
            if (map[x - 1][y].GetKindOfTile() == Items.None && map[x - 1][y].GetStep() < maxStep)
            {
                directionsx.Add(x - 1);
                directionsy.Add(y);
            }
            if (map[x][y + 1].GetKindOfTile() == Items.None && map[x][y + 1].GetStep() < maxStep)
            {
                directionsx.Add(x);
                directionsy.Add(y + 1);
            }
            if (map[x + 1][y].GetKindOfTile() == Items.None && map[x + 1][y].GetStep() < maxStep)
            {
                directionsx.Add(x + 1);
                directionsy.Add(y);
            }
            int[] directionsxx = directionsx.ToArray();
            int[] directionsyy = directionsy.ToArray();
            return (directionsxx, directionsyy);
        }
    }
}
