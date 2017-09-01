using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Skill
{
    public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
    {
        public new const ushort ProtocolId = 6715;

        public InteractiveUseWithParamRequestMessage(int objectId)
        {
            ObjectId = objectId;
        }

        public InteractiveUseWithParamRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectId = reader.ReadInt();
        }
    }
}