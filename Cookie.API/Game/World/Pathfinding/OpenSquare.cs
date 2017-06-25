namespace Cookie.API.Game.World.Pathfinding
{
    public class OpenSquare
    {
        public int X { get; set; }
        public int Y { get; set; }

        public OpenSquare(int y, int x)
        {
            this.X = x;
            this.Y = y;
        }
    }

}
