namespace Cookie.API.Game.World.Pathfinding
{
    public class OpenSquare
    {
        public OpenSquare(int y, int x)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}