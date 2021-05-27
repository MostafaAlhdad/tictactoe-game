using System;
using Components;


public class Program
{
	static void Main(string[] args)
        {
            Console.Write("Choose Player(x/o)");
            string inp = Console.ReadLine().ToLower();

            Board board = new Board(State.CharToState(inp[0]));
            WinChecker winChecker = new WinChecker();
            Renderer renderer = new Renderer();

            Player player1 = new Player();
            Player player2 = new Player();

            while (!winChecker.IsDraw(board) && winChecker.Check(board) == State.state.Undecided)
            {
                renderer.Render(board);
                Position nextMove;
                if (board.NextTurn == State.state.X)
                	nextMove = player1.GetPosition(board);
                else
                	nextMove = player2.GetPosition(board);
                if (!board.SetStateToPosition(nextMove, board.NextTurn))
                	Console.WriteLine("That is not a legal move.");
            }

            	renderer.Render(board);
            	renderer.RenderResults(winChecker.Check(board));

        	Console.ReadKey();
	}
}
