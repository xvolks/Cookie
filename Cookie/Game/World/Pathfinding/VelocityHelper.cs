using System.Collections.Generic;
using System.Linq;

namespace Cookie.Game.World.Pathfinding
{
    public class VelocityHelper
    {
        public static int GetVelocity(CellWithOrientation cell, MovementTypeEnum moveType)
        {
            if (cell.Orientation % 2 == 0)
            {
                if (cell.Orientation % 4 == 0)
                    switch (moveType)
                    {
                        case MovementTypeEnum.Mounted:
                            return 200;
                        case MovementTypeEnum.Parable:
                            return 500;
                        case MovementTypeEnum.Running:
                            return 255;
                        case MovementTypeEnum.Slide:
                            return 255 * 3;
                        case MovementTypeEnum.Walking:
                            return 510;
                    }

                switch (moveType)
                {
                    case MovementTypeEnum.Mounted:
                        return 120;
                    case MovementTypeEnum.Parable:
                        return 450;
                    case MovementTypeEnum.Running:
                        return 150;
                    case MovementTypeEnum.Slide:
                        return 150 * 3;
                    case MovementTypeEnum.Walking:
                        return 425;
                }
            }

            switch (moveType)
            {
                case MovementTypeEnum.Mounted:
                    return 135;
                case MovementTypeEnum.Parable:
                    return 400;
                case MovementTypeEnum.Running:
                    return 170;
                case MovementTypeEnum.Slide:
                    return 170 * 3;
                case MovementTypeEnum.Walking:
                    return 480;
            }
            return 0;
        }

        public static int GetPathVelocity(List<CellWithOrientation> cells, MovementTypeEnum moveType)
        {
            return cells
                .Aggregate(0, (current, cell) => current + GetVelocity(cell, moveType));
        }
    }
}