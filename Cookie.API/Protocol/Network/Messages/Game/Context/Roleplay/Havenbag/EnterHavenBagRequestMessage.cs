using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class EnterHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6636;

        public EnterHavenBagRequestMessage(ulong havenBagOwner)
        {
            HavenBagOwner = havenBagOwner;
        }

        public EnterHavenBagRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong HavenBagOwner { get; set; }

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