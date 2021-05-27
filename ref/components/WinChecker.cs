using static Components.State;

namespace Components
{
    /// <summary>
    /// class have the most important logic
    /// win logic trys to detect if the player complete a row or a column or a diagonally line
    /// </summary>
    public class WinChecker
    {
        /// <summary>
        /// Check if player win or there is a draw or nothing happen
        /// </summary>
        public state Check(Board board)
        {
            if (CheckForWin(board, state.X)) return state.X;
            if (CheckForWin(board, state.O)) return state.O;
            return state.Undecided;
        }

        /// <summary>
        /// checks if player completed a line
        /// </summary>
        /// <returns><c>true</c>, if someone win or draw <c>false</c> if nothing happen </returns>
        private bool CheckForWin(Board board, state player)
        {
            for (int row = 0; row < 3; row++)
                if (AreAll(board, new Position[] {
                        new Position(row, 0),
                        new Position(row, 1),
                        new Position(row, 2) }, player))
                    return true;

            for (int column = 0; column < 3; column++)
                if (AreAll(board, new Position[] {
                        new Position(0, column),
                        new Position(1, column),
                        new Position(2, column) }, player))
                    return true;

            if (AreAll(board, new Position[] {
                    new Position(0, 0),
                    new Position(1, 1),
                    new Position(2, 2) }, player))
                return true;

            if (AreAll(board, new Position[] {
                    new Position(2, 0),
                    new Position(1, 1),
                    new Position(0, 2) }, player))
                return true;

            return false;
        }


        /// <returns><c>true</c>, if player in all positions <c>false</c> otherwise.</returns>
        private bool AreAll(Board board, Position[] positions, state state)
        {
            foreach (Position position in positions)
                if (board.GetStateFromPosition(position) != state) return false;

            return true;
        }


        /// <summary>
        /// checks if the players filled the board
        /// </summary>
        /// <returns><c>true</c>, if draw <c>false</c> if still there empty slots.</returns>
        public bool IsDraw(Board board)
        {
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    if (board.GetStateFromPosition(new Position(row, column)) == state.Undecided) return false;

            return true;
        }
    }
}
