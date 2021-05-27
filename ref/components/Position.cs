namespace Components
{
    /// <summary>
    /// represent the slots position in the board
    /// </summary>
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Components.Position"/> class.
        /// </summary>
        /// <param name="row"><see langword="async"/> the vertical axis of the position </param>
        /// <param name="column"> the horizontal axis of the position </param>
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static bool operator== (Position a, Position b){
          if (a.Row == b.Row && b.Column == a.Column) {return true;}
          return false;
        }
        public static bool operator!= (Position a, Position b){
          if (a.Row == b.Row || b.Column == a.Column) {return false;}
          return true;
        }
    }

}
