using Cookie.API.IO;

namespace Cookie.API.Protocol
{
    public abstract class NetworkMessage
    {
        public abstract uint MessageID { get; }

        public abstract void Serialize(ICustomDataOutput writer);
        public abstract void Deserialize(ICustomDataInput reader);
    }
}