
namespace MazeProjekt
{
    /// <summary>
    /// Object that represents a tile in the maze. Stores the number of steps taken on the tile and the kind of tile.
    /// </summary>
    internal class Tile
    {
        private int steps = 0;
        private Items kindOfTile;
        public Tile(Items  item)
        {
            kindOfTile = item;
            if (item == Items.Player)
            {
                steps++;
            }
        }
        // getters and setters
        public int GetStep()
        {
            return steps;
        }
        public Items GetKindOfTile()
        {
            return kindOfTile;
        }
        public void SetKindOfTile(Items item)
        {
            kindOfTile = item;
            if (item == Items.Player)
            {
                steps++;
            }
        }
        // Custom ToString() method for better looking console output
        /// <summary>
        /// Converts the Tile object to its string representation.
        /// </summary>
        /// <returns>The string representation of the Tile object.</returns>
        public override string ToString()
        {
            if (kindOfTile == Items.None)
            {
                return " ";
            }
            else if (kindOfTile == Items.Wall)
            {
                return "▓";
            }
            else if (kindOfTile == Items.Player)
            {
                return "λ";
            }
            else if (kindOfTile == Items.End)
            {
                return "O";
            }
            else
            {
                return "Error";
            }
        }
        /// <summary>
        /// Converts the Tile object to its string representation with steps. (Like heat map)
        /// </summary>
        /// <returns>The string representation of the Tile object.</returns>
        public string ToStringHeat()
        {
            if (kindOfTile == Items.None)
            {
                if (steps > 9)
                {
                    return "," + steps;
                }
                return steps + "";

            }else if (kindOfTile == Items.Wall)
            {
                return "▓";
            }
            else if (kindOfTile == Items.Player)
            {
                return "λ";
            }
            else if (kindOfTile == Items.End)
            {
                return "O";
            }
            else
            {
                return "Error";
            }
        }
    }
}
