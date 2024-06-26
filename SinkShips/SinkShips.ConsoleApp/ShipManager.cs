namespace SinkShips.ConsoleApp
{
    public class ShipManager
    {
        /// <summary>
        /// This method places a ship vertically.
        /// It iterates and checks if the counter exceeds the given coordinates.
        ///
        /// Nor `row` neither `column` can be negative, because there are no negative coordinates
        /// => That's why `isShipCell` doesn't check for negatives
        ///
        /// ONLY THE  COMBINATION WORKS!!!
        /// `isShipCell` => check for cell being bigger than given coordinates
        /// `isShipLength` => check for ship to not being displayed bigger than it's actual size
        /// 
        /// `lengthCount` starts at 1, because ships are at least 1 block long
        /// </summary>
        public void PlaceShipVertically(string[,] gameBoard, int shipLength,
            (int xAxisStartPoint, int yAxisStartPoint) location)
        {
            int lengthCount = 1;
            // Row iterator
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                // Column Iterator
                for (int column = 0; column < gameBoard.GetLength(1); column++)
                {
                    // READ Doc-Comment from above
                    bool isShipCell = row >= location.yAxisStartPoint && column == location.xAxisStartPoint;
                    bool isShipLength = lengthCount <= shipLength;
                    if (!isShipCell || !isShipLength) continue;
                    gameBoard[row, column] = "*";
                    lengthCount++;
                }
            }
        }

        /// <summary>
        /// 1st if => gets the direct row
        /// 2nd if => sets only those cells to '*' that are >= than given xAxisPoint
        /// </summary>
        public void PlaceShipHorizontally(string[,] gameBoard, int shipLength,
            (int xAxisStartPoint, int yAxisStartPoint) location)
        {
            int lengthCount = 1;
            // Row iterator
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                if (row != location.yAxisStartPoint) continue;
                // Columns iterator
                for (int column = 0; column <= gameBoard.GetLength(1); column++)
                {
                    bool isShipCell = column >= location.xAxisStartPoint;
                    bool isShipLength = lengthCount <= shipLength;

                    if (!isShipCell || !isShipLength) continue;
                    gameBoard[row, column] = "*";
                    lengthCount++;
                }

                break;
            }
        }
    }
}