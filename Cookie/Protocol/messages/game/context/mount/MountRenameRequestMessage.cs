using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountRenameRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5987;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public int MountId = 0;

        public MountRenameRequestMessage()
        {
        }

        public MountRenameRequestMessage(
            string name,
            int mountId
        )
        {
            Name = name;
            MountId = mountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
            MountId = reader.ReadVarInt();
        }
    }
}