using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildModificationStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6324;
        public override uint MessageID { get { return ProtocolId; } }

        public bool CanChangeName = false;
        public bool CanChangeEmblem = false;

        public GuildModificationStartedMessage()
        {
        }

        public GuildModificationStartedMessage(
            bool canChangeName,
            bool canChangeEmblem
        )
        {
            CanChangeName = canChangeName;
            CanChangeEmblem = canChangeEmblem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, CanChangeName);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, CanChangeEmblem);
            writer.WriteByte(box0);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            CanChangeName = BooleanByteWrapper.GetFlag(box0, 1);
            CanChangeEmblem = BooleanByteWrapper.GetFlag(box0, 2);
        }
    }
}