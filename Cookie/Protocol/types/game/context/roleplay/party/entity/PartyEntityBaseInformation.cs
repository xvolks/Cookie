using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PartyEntityBaseInformation : NetworkType
    {
        public const short ProtocolId = 552;
        public override short TypeId { get { return ProtocolId; } }

        public byte IndexId = 0;
        public byte EntityModelId = 0;
        public EntityLook EntityLook_;

        public PartyEntityBaseInformation()
        {
        }

        public PartyEntityBaseInformation(
            byte indexId,
            byte entityModelId,
            EntityLook entityLook_
        )
        {
            IndexId = indexId;
            EntityModelId = entityModelId;
            EntityLook_ = entityLook_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(IndexId);
            writer.WriteByte(EntityModelId);
            EntityLook_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            IndexId = reader.ReadByte();
            EntityModelId = reader.ReadByte();
            EntityLook_ = new EntityLook();
            EntityLook_.Deserialize(reader);
        }
    }
}