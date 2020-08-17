namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class EnterHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6636;
        public override ushort MessageID => ProtocolId;
        public ulong HavenBagOwner { get; set; }

        public EnterHavenBagRequestMessage(ulong havenBagOwner)
        {
            HavenBagOwner = havenBagOwner;
        }

        public EnterHavenBagRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(HavenBagOwner);
        }

        public override void Deserialize(IDataReader reader)
        {
            HavenBagOwner = reader.ReadVarUhLong();
        }

    }
}
