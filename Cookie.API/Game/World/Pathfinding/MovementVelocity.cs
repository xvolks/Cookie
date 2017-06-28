using System.Linq;
using Cookie.API.Game.World.Pathfinding.Positions;

namespace Cookie.API.Game.World.Pathfinding
{
    public static class MovementVelocity
    {
        public enum MovementTypeEnum
        {
            MOUNTED,
            PARABLE,
            RUNNING,
            SLIDE,
            WALKING
        }

        public static uint GetPathVelocity(MovementPath cells, MovementTypeEnum moveType)
        {
            return cells.Cells.Aggregate<PathElement, uint>(0,
                (current, cell) => current + GetVelocity(cell, moveType));
        }

        public static uint GetVelocity(PathElement cell, MovementTypeEnum moveType)
        {
            if (cell.Orientation % 2 == 0)
            {
                if (cell.Orientation % 4 == 0)
                    switch (moveType)
                    {
                        case MovementTypeEnum.MOUNTED:
                            return 200;
                        case MovementTypeEnum.PARABLE:
                            return 500;
                        case MovementTypeEnum.RUNNING:
                            return 255;
                        case MovementTypeEnum.SLIDE:
                            return 255 * 3;
                        case MovementTypeEnum.WALKING:
                            return 510;
                    }

                // VERTICAL DIAGONAL VELOCITY

                switch (moveType)
                {
                    case MovementTypeEnum.MOUNTED:
                        return 120;
                    case MovementTypeEnum.PARABLE:
                        return 450;
                    case MovementTypeEnum.RUNNING:
                        return 150;
                    case MovementTypeEnum.SLIDE:
                        return 150 * 3;
                    case MovementTypeEnum.WALKING:
                        return 425;
                }
            }

            // LINEAR VELOCITY

            switch (moveType)
            {
                case MovementTypeEnum.MOUNTED:
                    return 135;
                case MovementTypeEnum.PARABLE:
                    return 400;
                case MovementTypeEnum.RUNNING:
                    return 170;
                case MovementTypeEnum.SLIDE:
                    return 170 * 3;
                case MovementTypeEnum.WALKING:
                    return 480;
            }

            return 0;
        }
    }
}