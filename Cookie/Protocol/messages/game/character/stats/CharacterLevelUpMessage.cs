using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterLevelUpMessage : NetworkMessage
    {
        public const uint ProtocolId = 5670;
        public override uint MessageID { get { return ProtocolId; } }

        public short NewLevel = 0;

        public CharacterLevelUpMessage()
        {
        }

        public CharacterLevelUpMessage(
            short newLevel
        )
        {
            NewLevel = newLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(NewLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NewLevel = reader.ReadVarShort();
        }
    }
}