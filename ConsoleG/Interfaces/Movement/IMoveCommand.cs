namespace ConsoleG.Interfaces.Movement
{
    public interface IMoveCommand
    {
        void CountDown(int time);
        MoveDirections Direction { get; }
        int Delay { get; }
        int Distance { get; }
    }
}
