using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class EntityInformation : NetworkType
    {
        public const short ProtocolId = 546;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;
        public int Experience = 0;
        public bool Status = false;

        public EntityInformation()
        {
        }

        public EntityInformation(
            short id_,
            int experience,
            bool status
        )
        {
            Id_ = id_;
            Experience = experience;
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
            writer.WriteVarInt(Experience);
            writer.WriteBoolean(Status);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
            Experience = reader.ReadVarInt();
            Status = reader.ReadBoolean();
        }
    }
}