using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountRidingMessage : NetworkMessage
    {
        public const uint ProtocolId = 5967;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsRiding = false;
        public bool IsAutopilot = false;

        public MountRidingMessage()
        {
        }

        public MountRidingMessage(
            bool isRiding,
            bool isAutopilot
        )
        {
            IsRiding = isRiding;
            IsAutopilot = isAutopilot;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, IsRiding);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsAutopilot);
            writer.WriteByte(box0);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            IsRiding = BooleanByteWrapper.GetFlag(box0, 1);
            IsAutopilot = BooleanByteWrapper.GetFlag(box0, 2);
        }
    }
}