using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ArenaFighterLeaveMessage : NetworkMessage
    {
        public const uint ProtocolId = 6700;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterBasicMinimalInformations Leaver;

        public ArenaFighterLeaveMessage()
        {
        }

        public ArenaFighterLeaveMessage(
            CharacterBasicMinimalInformations leaver
        )
        {
            Leaver = leaver;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Leaver.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Leaver = new CharacterBasicMinimalInformations();
            Leaver.Deserialize(reader);
        }
    }
}