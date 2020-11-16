using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceModificationStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6444;
        public override uint MessageID { get { return ProtocolId; } }

        public bool CanChangeName = false;
        public bool CanChangeTag = false;
        public bool CanChangeEmblem = false;

        public AllianceModificationStartedMessage()
        {
        }

        public AllianceModificationStartedMessage(
            bool canChangeName,
            bool canChangeTag,
            bool canChangeEmblem
        )
        {
            CanChangeName = canChangeName;
            CanChangeTag = canChangeTag;
            CanChangeEmblem = canChangeEmblem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, CanChangeName);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, CanChangeTag);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, CanChangeEmblem);
            writer.WriteByte(box0);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            CanChangeName = BooleanByteWrapper.GetFlag(box0, 1);
            CanChangeTag = BooleanByteWrapper.GetFlag(box0, 2);
            CanChangeEmblem = BooleanByteWrapper.GetFlag(box0, 3);
        }
    }
}