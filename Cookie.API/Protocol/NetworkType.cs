using System;
using Cookie.API.IO;

namespace Cookie.API.Protocol
{
    public abstract class NetworkType : MarshalByRefObject
    {
        public abstract short TypeID { get; }

        public abstract void Serialize(ICustomDataOutput writer);
        public abstract void Deserialize(ICustomDataInput reader);
    }
}