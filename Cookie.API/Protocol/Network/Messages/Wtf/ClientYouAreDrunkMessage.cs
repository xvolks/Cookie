using Cookie.API.Protocol.Network.Messages.Debug;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Wtf
{
    public class ClientYouAreDrunkMessage : DebugInClientMessage
    {
        public new const ushort ProtocolId = 6594;

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