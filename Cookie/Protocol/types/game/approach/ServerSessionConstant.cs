using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ServerSessionConstant : NetworkType
    {
        public const short ProtocolId = 430;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;

        public ServerSessionConstant()
        {
        }

        public ServerSessionConstant(
            short id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
        }
    }
}