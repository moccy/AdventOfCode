namespace Day2
{
    internal record Move
    {
        public MoveType Type;
        public int Value;
        public MoveType Beats;
        public MoveType LosesTo;
    }
}