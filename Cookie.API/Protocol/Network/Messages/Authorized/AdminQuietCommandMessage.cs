using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Authorized
{
    public class AdminQuietCommandMessage : AdminCommandMessage
    {
        public new const ushort ProtocolId = 5662;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}