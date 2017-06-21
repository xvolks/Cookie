using System;
using Cookie.IO;

namespace Cookie
{
    public abstract class NetworkType : MarshalByRefObject
    {
        public abstract short TypeID { get; }

        public abstract void Serialize(ICustomDataOutput writer);
        public abstract void Deserialize(ICustomDataInput reader);
    }
}