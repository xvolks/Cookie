namespace Cookie.API.Gamedata.D2o.other
{
    public class Point : IDataObject
    {
        public double length;

        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}