using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountRenameRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5987;

        public MountRenameRequestMessage(string name, int mountId)
        {
            Name = name;
            MountId = mountId;
        }

        public MountRenameRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public int MountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            MountId = reader.ReadVarInt();
        }
    }
}