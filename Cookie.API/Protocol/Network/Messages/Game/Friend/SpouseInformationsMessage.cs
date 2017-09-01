using Cookie.API.Protocol.Network.Types.Game.Friend;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class SpouseInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6356;

        public SpouseInformationsMessage(FriendSpouseInformations spouse)
        {
            Spouse = spouse;
        }

        public SpouseInformationsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public FriendSpouseInformations Spouse { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Spouse.TypeID);
            Spouse.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Spouse = ProtocolTypeManager.GetInstance<FriendSpouseInformations>(reader.ReadUShort());
            Spouse.Deserialize(reader);
        }
    }
}