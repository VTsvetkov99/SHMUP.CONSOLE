using ConsoleG.Interfaces.Maps;

namespace ConsoleG.Interfaces.Movement
{
    public interface IMovementController
    {
        void MoveAfter(IMovable movable, IMoveCommand command);
        IGridMap Map { get; }
    }
}
