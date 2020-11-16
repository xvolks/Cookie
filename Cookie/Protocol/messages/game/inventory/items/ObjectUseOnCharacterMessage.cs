using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectUseOnCharacterMessage : ObjectUseMessage
    {
        public new const uint ProtocolId = 3003;
        public override uint MessageID { get { return ProtocolId; } }

        public long CharacterId = 0;

        public ObjectUseOnCharacterMessage(): base()
        {
        }

        public ObjectUseOnCharacterMessage(
            int objectUID,
            long characterId
        ): base(
            objectUID
        )
        {
            CharacterId = characterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(CharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CharacterId = reader.ReadVarLong();
        }
    }
}