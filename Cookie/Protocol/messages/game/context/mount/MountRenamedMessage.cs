using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountRenamedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5983;
        public override uint MessageID { get { return ProtocolId; } }

        public int MountId = 0;
        public string Name;

        public MountRenamedMessage()
        {
        }

        public MountRenamedMessage(
            int mountId,
            string name
        )
        {
            MountId = mountId;
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MountId = reader.ReadVarInt();
            Name = reader.ReadUTF();
        }
    }
}