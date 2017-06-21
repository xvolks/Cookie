using Cookie.Gamedata.D2o;

namespace Cookie.GameData.D2O
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