using Cookie.IO;
using System;

namespace Cookie
{
    public abstract class NetworkType : MarshalByRefObject
    {
        public abstract short TypeId { get; }

        public abstract void Serialize(ICustomDataOutput writer);
        public abstract void Deserialize(ICustomDataInput reader);
    }
}
