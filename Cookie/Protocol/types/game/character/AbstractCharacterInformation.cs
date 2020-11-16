using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AbstractCharacterInformation : NetworkType
    {
        public const short ProtocolId = 400;
        public override short TypeId { get { return ProtocolId; } }

        public long Id_ = 0;

        public AbstractCharacterInformation()
        {
        }

        public AbstractCharacterInformation(
            long id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarLong();
        }
    }
}