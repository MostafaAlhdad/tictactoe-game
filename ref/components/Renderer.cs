using System;
using static Components.State;

namespace Components
{
    public class Renderer
    {
        /// <summary>
        /// draw the tictactoe board
        /// </summary>
        public void Render(Board board)
        {
            Console.Clear();

            char[,] symbols = new char[3, 3];
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    symbols[row, column] = SymbolFor(board.GetStateFromPosition(new Position(row, column)), NumberForPosition(new Position(row, column)));

            Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 1]} | {symbols[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[1, 0]} | {symbols[1, 1]} | {symbols[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[2, 0]} | {symbols[2, 1]} | {symbols[2, 2]} ");

        }

        /// <summary>
        /// Gets a number represent the position
        /// </summary>
        /// <returns>return a number between (1-9) if position if valid otherwise return 0</returns>
        protected int NumberForPosition(Position pos)
        {
            if (new Position(2, 0) == pos) return 1;
            if (new Position(2, 1) == pos) return 2;
            if (new Position(2, 2) == pos) return 3;
            if (new Position(1, 0) == pos) return 4;
            if (new Position(1, 1) == pos) return 5;
            if (new Position(1, 2) == pos) return 6;
            if (new Position(0, 0) == pos) return 7;
            if (new Position(0, 1) == pos) return 8;
            if (new Position(0, 2) == pos) return 9;
            else return 0;
        }


        protected char SymbolFor(state _state, int pos)
        {
            switch (_state)
            {
                case state.O: return 'O';
                case state.X: return 'X';
                default: return (""+pos)[0];
            }
        }

        /// <summary>
        /// Renders Whose win
        /// </summary>
        public void RenderResults(state winner)
        {
            Console.Clear();
            switch (winner)
            {
                case state.O:
                case state.X:
                    Console.WriteLine(SymbolFor(winner, 0) + " Wins!");
                    break;
                case state.Undecided:
                    Console.WriteLine("Draw!");
                    break;
            }
        }
    }

}
