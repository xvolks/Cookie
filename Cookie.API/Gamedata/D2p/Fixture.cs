using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    public class Fixture
    {
        // Fields
        public int Alpha;

        public int BlueMultiplier;
        public int FixtureId;
        public int GreenMultiplier;
        public int Hue;
        public int OffsetX;
        public int OffsetY;
        public int RedMultiplier;
        public int Rotation;
        public int xScale;

        public int yScale;

        // Methods
        internal void Init(IDataReader Reader)
        {
            FixtureId = Reader.ReadInt();
            OffsetX = Reader.ReadShort();
            OffsetY = Reader.ReadShort();
            Rotation = Reader.ReadShort();
            xScale = Reader.ReadShort();
            yScale = Reader.ReadShort();
            RedMultiplier = Reader.ReadSByte();
            GreenMultiplier = Reader.ReadSByte();
            BlueMultiplier = Reader.ReadSByte();
            Hue = RedMultiplier | GreenMultiplier | BlueMultiplier;
            Alpha = Reader.ReadByte();
        }
    }
}