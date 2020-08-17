using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    public class StartupActionsExecuteMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1302;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}