using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
    {
        public new const uint ProtocolId = 6425;
        public override uint MessageID { get { return ProtocolId; } }

        public short ObjectGID = 0;

        public GameRolePlayDelayedObjectUseMessage(): base()
        {
        }

        public GameRolePlayDelayedObjectUseMessage(
            double delayedCharacterId,
            byte delayTypeId,
            double delayEndTime,
            short objectGID
        ): base(
            delayedCharacterId,
            delayTypeId,
            delayEndTime
        )
        {
            ObjectGID = objectGID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(ObjectGID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarShort();
        }
    }
}