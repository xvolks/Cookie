using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5698;

        public HouseKickRequestMessage(ulong objectId)
        {
            ObjectId = objectId;
        }

        public HouseKickRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhLong();
        }
    }
}