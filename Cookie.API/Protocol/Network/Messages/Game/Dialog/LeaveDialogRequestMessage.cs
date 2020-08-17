using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dialog
{
    public class LeaveDialogRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5501;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}