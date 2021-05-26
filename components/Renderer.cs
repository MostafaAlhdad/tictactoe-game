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
                    symbols[row, column] = SymbolFor(board.GetStateFromPosition(new Position(row, column)));

            Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 1]} | {symbols[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[1, 0]} | {symbols[1, 1]} | {symbols[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[2, 0]} | {symbols[2, 1]} | {symbols[2, 2]} ");

        }

        private char SymbolFor(state _state)
        {
            switch (_state)
            {
                case state.O: return 'O';
                case state.X: return 'X';
                default: return ' ';
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
                    Console.WriteLine(SymbolFor(winner) + " Wins!");
                    break;
                case state.Undecided:
                    Console.WriteLine("Draw!");
                    break;
            }
        }
    }

}
