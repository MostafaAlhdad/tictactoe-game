namespace Components
{
    public static class State{
        public enum state { Undecided, X, O };

        public static state CharToState(char Char)
        {
            switch (Char)
            {
                case 'x':
                    return state.X;
                case 'o':
                    return state.O;
                default:
                    return state.X;
            }
        }
    }
}
