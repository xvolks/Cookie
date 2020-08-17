using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    public class StartupActionFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1304;

        public StartupActionFinishedMessage(bool success, bool automaticAction, int actionId)
        {
            Success = success;
            AutomaticAction = automaticAction;
            ActionId = actionId;
        }

        public StartupActionFinishedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }
        public bool AutomaticAction { get; set; }
        public int ActionId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Success);
            flag = BooleanByteWrapper.SetFlag(1, flag, AutomaticAction);
            writer.WriteByte(flag);
            writer.WriteInt(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(flag, 0);
            AutomaticAction = BooleanByteWrapper.GetFlag(flag, 1);
            ActionId = reader.ReadInt();
        }
    }
}