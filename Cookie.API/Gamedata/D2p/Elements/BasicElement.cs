using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p.Elements
{
    public abstract class BasicElement
    {
        // Methods

        public static BasicElement GetElementFromType(int typeId)
        {
            switch (typeId)
            {
                case 2:
                    return new GraphicalElement();
                case 33:
                    return new SoundElement();
            }
            return null;
        }

        internal abstract void Init(IDataReader reader, int mapVersion);
    }
}