using System;
using System.Threading;

namespace MazeProjekt
{
    /// <summary>
    /// Left hand rule algorithm.
    /// Author: Vít Miikue Horčička
    /// </summary>
    internal class LeftHandRule : MazeSolver
    {
        /// <summary>
        /// Walks the player through the maze using the left hand rule.
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        public static void Solve(Tile[][] map)
        {
            Player player = new Player();
            FindPlayer(map, player);
            Items direction = Items.Left;
            while (direction != Items.End)
            {
                ReadMap(map);
                OneStep(map, player, ref direction);
                Thread.Sleep(sleepTime);
                Console.Clear();
            }
            Console.Clear();
            ReadHeatMap(map);
            Console.WriteLine("I found end and walked " + player.GetSteps() + " steps.");
        }
        /// <summary>
        /// Walks the player through the maze using the left hand rule. (With custom sleep time)
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="time"> The sleep time between the steps.</param></param>
        public static void Solve(Tile[][] map, int time)
        {
            sleepTime = time;
            Solve(map);
        }
        /// <summary>
        ///     One step of the left hand rule.
        /// </summary>
        /// <param name="map"> The 2D array of Tile objects representing the map</param>
        /// <param name="direction"> Direction of the player.</param>
        /// <param name="player"> Player object.</param>
        private static void OneStep(Tile[][] map, Player player, ref Items direction)
        {
            int x = player.GetX();
            int y = player.GetY();
            if (direction == Items.Left)
            {
                if (map[x - 1][y].GetKindOfTile() == Items.End)
                {
                    map[x - 1][y].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    direction = Items.End;
                    player.SetX(x - 1);
                }
                else if (map[x - 1][y].GetKindOfTile() == Items.None)
                {
                    map[x - 1][y].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    player.SetX(x - 1);
                    if (map[x - 1][y - 1].GetKindOfTile() == Items.None)
                    {
                        direction = Items.Down;
                    }
                }
                else
                {
                    direction = Items.Top;
                }
            }
            else if (direction == Items.Down)
            {
                if (map[x][y - 1].GetKindOfTile() == Items.End)
                {
                    map[x][y - 1].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    direction = Items.End;
                    player.SetY(y - 1);
                }
                else if (map[x][y - 1].GetKindOfTile() == Items.None)
                {
                    map[x][y - 1].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    player.SetY(y - 1);
                    if (map[x + 1][y - 1].GetKindOfTile() == Items.None)
                    {
                        direction = Items.Right;
                    }
                }
                else
                {
                    direction = Items.Left;
                }
            }
            else if (direction == Items.Right)
            {
                if (map[x + 1][y].GetKindOfTile() == Items.End)
                {
                    map[x + 1][y].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    direction = Items.End;
                    player.SetX(x + 1);
                }
                else if (map[x + 1][y].GetKindOfTile() == Items.None)
                {
                    map[x + 1][y].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    player.SetX(x + 1);
                    if (map[x + 1][y + 1].GetKindOfTile() == Items.None)
                    {
                        direction = Items.Top;
                    }
                }
                else
                {
                    direction = Items.Down;
                }
            }
            else if (direction == Items.Top)
            {
                if (map[x][y + 1].GetKindOfTile() == Items.End)
                {
                    map[x][y + 1].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    direction = Items.End;
                    player.SetY(y + 1);
                }
                else if (map[x][y + 1].GetKindOfTile() == Items.None)
                {
                    map[x][y + 1].SetKindOfTile(Items.Player);
                    map[x][y].SetKindOfTile(Items.None);
                    player.SetY(y + 1);
                    if (map[x - 1][y + 1].GetKindOfTile() == Items.None)
                    {
                        direction = Items.Left;
                    }
                }
                else
                {
                    direction = Items.Right;
                }
            }
        }
    }
}
