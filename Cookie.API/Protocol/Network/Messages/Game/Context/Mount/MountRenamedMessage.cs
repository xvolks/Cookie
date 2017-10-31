namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountRenamedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5983;
        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }
        public string Name { get; set; }

        public MountRenamedMessage(int mountId, string name)
        {
            MountId = mountId;
            Name = name;
        }

        public MountRenamedMessage() { }

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
