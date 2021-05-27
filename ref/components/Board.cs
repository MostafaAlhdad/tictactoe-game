using static Components.State;
namespace Components
{
    /// <summary>
    /// Board is class that have player difination and turns logic  
    /// </summary>
    public class Board
    {
        protected state[,] Currentstate;
        public state NextTurn { get; private set; }

        public Board(state FirstPlayer)
        {
            Currentstate = new state[3, 3];
            NextTurn = FirstPlayer;
        }

        public state GetStateFromPosition(Position position)
        {
            return Currentstate[position.Row, position.Column];
        }

        public bool SetStateToPosition(Position position, state newState)
        {
            if (newState != NextTurn) return false;
            if (Currentstate[position.Row, position.Column] != state.Undecided) return false;

            Currentstate[position.Row, position.Column] = newState;
            SwitchNextTurn();
            return true;
        }
       
        private void SwitchNextTurn()
        {
            // replaced if else statement with ?: statement here to make the code smaller
            NextTurn = NextTurn == state.X ? state.O : state.X;
        }
    }

}
