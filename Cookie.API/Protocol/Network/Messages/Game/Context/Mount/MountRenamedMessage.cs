using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountRenamedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5983;

        public MountRenamedMessage(int mountId, string name)
        {
            MountId = mountId;
            Name = name;
        }

        public MountRenamedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
            Name = reader.ReadUTF();
        }
    }
}