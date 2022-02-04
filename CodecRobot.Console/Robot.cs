using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecRobot.Console
{
    public class Robot
    {
        public enum Direction : int
        {
            North = 1,
            East = 2,
            South = 3,
            West = 4
        }

        public string execute(string size, string movs)
        {
            var mapSize = new Tuple<int, int>(int.Parse(size[0].ToString()), int.Parse(size[2].ToString()));
            var position = new Tuple<int, int>(0, 0);
            var direction = Direction.North;
            foreach (char mov in movs)
                TryMov(mov, mapSize, ref direction, ref position);
            return (position.Item1 + 1) + "," + (position.Item2 + 1) + "," + direction.ToString();
        }

        public static Direction GetNextDirection(int nextDirection)
        {
            if (nextDirection == 0)
                return Direction.West;
            if (nextDirection > 4)
                return Direction.North;
            return (Direction)nextDirection;
        }

        public static Tuple<int, int>? GetNextPosition(Tuple<int, int> mapSize, Tuple<int, int> position, Direction direction)
        {
            Tuple<int, int> nextPosition = position;
            switch (direction)
            {
                case Direction.North:
                    nextPosition = new Tuple<int, int>(position.Item1, position.Item2 + 1);
                    break;
                case Direction.East:
                    nextPosition = new Tuple<int, int>(position.Item1 + 1, position.Item2);
                    break;
                case Direction.South:
                    nextPosition = new Tuple<int, int>(position.Item1, position.Item2 - 1);
                    break;
                case Direction.West:
                    nextPosition = new Tuple<int, int>(position.Item1 - 1, position.Item2);
                    break;
            }

            if (nextPosition.Item1 >= 0 && nextPosition.Item2 >= 0 && nextPosition.Item1 < mapSize.Item1 && nextPosition.Item2 < mapSize.Item2)
                return nextPosition;
            return null;
        }

        public static void TryMov(char mov, Tuple<int, int> mapSize, ref Direction direction, ref Tuple<int, int> position)
        {
            Direction nextDirection;
            switch (mov)
            {
                case 'L':
                    nextDirection = GetNextDirection((int)direction - 1);
                    if (GetNextPosition(mapSize, position, nextDirection) != null)
                        direction = nextDirection;
                    break;
                case 'R':
                    nextDirection = GetNextDirection((int)direction + 1);
                    if (GetNextPosition(mapSize, position, nextDirection) != null)
                        direction = nextDirection;
                    break;
                case 'F':
                    var nextPosition = GetNextPosition(mapSize, position, direction);
                    if (nextPosition != null)
                        position = nextPosition;
                    break;
            }
        }
    }
}
