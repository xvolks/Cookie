using Cookie.IO;

namespace Cookie
{
    public abstract class NetworkMessage
    {
        public abstract uint MessageID { get; }

        public abstract void Serialize(ICustomDataOutput writer);
        public abstract void Deserialize(ICustomDataInput reader);
    }
}