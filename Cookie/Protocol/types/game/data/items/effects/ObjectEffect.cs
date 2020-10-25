using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffect : NetworkType
    {
        public const short ProtocolId = 76;
        public override short TypeId { get { return ProtocolId; } }

        public short ActionId = 0;

        public ObjectEffect()
        {
        }

        public ObjectEffect(
            short actionId
        )
        {
            ActionId = actionId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ActionId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActionId = reader.ReadVarShort();
        }
    }
}