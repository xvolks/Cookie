using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p.Elements
{
    public class SoundElement : BasicElement
    {
        // Fields
        public int BaseVolume;

        public int FullVolumeDistance;
        public int MaxDelayBetweenLoops;
        public int MinDelayBetweenLoops;
        public int NullVolumeDistance;

        public int SoundId;

        // Methods
        internal override void Init(IDataReader Reader, int MapVersion)
        {
            SoundId = Reader.ReadInt();
            BaseVolume = Reader.ReadShort();
            FullVolumeDistance = Reader.ReadInt();
            NullVolumeDistance = Reader.ReadInt();
            MinDelayBetweenLoops = Reader.ReadShort();
            MaxDelayBetweenLoops = Reader.ReadShort();
        }
    }
}