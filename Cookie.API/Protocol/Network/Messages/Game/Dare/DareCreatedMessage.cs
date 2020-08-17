using Cookie.API.Protocol.Network.Types.Game.Dare;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareCreatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6668;

        public DareCreatedMessage(DareInformations dareInfos, bool needNotifications)
        {
            DareInfos = dareInfos;
            NeedNotifications = needNotifications;
        }

        public DareCreatedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public DareInformations DareInfos { get; set; }
        public bool NeedNotifications { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            DareInfos.Serialize(writer);
            writer.WriteBoolean(NeedNotifications);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareInfos = new DareInformations();
            DareInfos.Deserialize(reader);
            NeedNotifications = reader.ReadBoolean();
        }
    }
}