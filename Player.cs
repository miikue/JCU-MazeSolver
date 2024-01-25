namespace MazeProjekt
{
    /// <summary>
    ///  Basic player class. Stores the player's position.
    ///  With x and y coordinates and the number of steps taken.
    /// </summary>
    internal class Player
    {
        // default values are -1, so that the player is outside the maze
        private int x = -1;
        private int y = -1;
        private int steps = 0;

        // getters and setters
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public int GetSteps()
        {
            return steps;
        }

        public void SetX(int x)
        {
            this.x = x;
            steps++;
        }
        public void SetY(int y)
        {
            this.y = y;
            steps++;
        }
    }
}
