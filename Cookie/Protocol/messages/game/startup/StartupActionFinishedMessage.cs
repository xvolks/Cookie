using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StartupActionFinishedMessage : NetworkMessage
    {
        public const uint ProtocolId = 1304;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Success = false;
        public bool AutomaticAction = false;
        public int ActionId = 0;

        public StartupActionFinishedMessage()
        {
        }

        public StartupActionFinishedMessage(
            bool success,
            bool automaticAction,
            int actionId
        )
        {
            Success = success;
            AutomaticAction = automaticAction;
            ActionId = actionId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Success);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, AutomaticAction);
            writer.WriteByte(box0);
            writer.WriteInt(ActionId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(box0, 1);
            AutomaticAction = BooleanByteWrapper.GetFlag(box0, 2);
            ActionId = reader.ReadInt();
        }
    }
}