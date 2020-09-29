using ConsoleG.Interfaces.Graphics.Drawing;
using ConsoleG.Interfaces.Maps;
using ConsoleG.Interfaces.Movement;
using Priority_Queue;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SHMUP.App.Movement
{
    public class MovementController : IMovementController
    {
        private readonly Dictionary<IMovable, SimplePriorityQueue<IMoveCommand, int>> _queues;
        private readonly int _renderInterval;
        private List<IMoveCommand> _commands;

        public IGridMap Map { get; }

        public MovementController(
            CancellationToken token,
            IGridMap map,
            int interval)
        {
            Map = map;
            _queues = new Dictionary<IMovable, SimplePriorityQueue<IMoveCommand, int>>();
            _renderInterval = interval;
            _commands = new List<IMoveCommand>();

            Task.Run(() => MoveEnqueued(token));
        }

        public void MoveAfter(IMovable movable, IMoveCommand command)
        {
            if (!_queues.Keys.Contains(movable))
                _queues.Add(movable, new SimplePriorityQueue<IMoveCommand, int>());

            _queues[movable].Enqueue(command, command.Delay);
            _commands.Add(command);
        }

        private void MoveEnqueued(CancellationToken token)
        {
            IMoveCommand found = null;
            int timeWaited = 0;

            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(_renderInterval);
                timeWaited += _renderInterval;

                var toMove = _queues.Where(q => q.Value.TryFirst(out found) && found.Delay - timeWaited <= 0);

                if (toMove.Any())
                {
                    foreach (var command in _commands.ToList())
                        command.CountDown(timeWaited);

                    foreach (var movable in toMove.ToList())
                    {
                        lock (Map)
                        {
                            var command = movable.Value.Dequeue();
                            _commands.Remove(command);
                            bool moved = Map.TryMove(movable.Key, command.Direction, command.Distance);

                            if (!moved)
                            {
                                var queuesToRemove = _queues.Where(q => q.Key.State == DrawStates.Deleted);

                                if (queuesToRemove.Any())
                                {
                                    _commands = _commands.Except(queuesToRemove.SelectMany(q => q.Value)).ToList();

                                    foreach (var pariToRemove in queuesToRemove)
                                        _queues.Remove(pariToRemove.Key);
                                }
                            }
                        }
                    }

                    timeWaited = 0;
                }
            }
        }
    }
}
