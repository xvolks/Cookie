using System;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol
{
    public abstract class NetworkType : MarshalByRefObject
    {
        public abstract ushort TypeID { get; }

        public abstract void Serialize(IDataWriter writer);
        public abstract void Deserialize(IDataReader reader);
    }
}