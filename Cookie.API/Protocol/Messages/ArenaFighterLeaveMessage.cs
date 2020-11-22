using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ArenaFighterLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6700;

        public override ushort MessageID => ProtocolId;

        public CharacterBasicMinimalInformations Leaver { get; set; }
        public ArenaFighterLeaveMessage() { }

        public ArenaFighterLeaveMessage( CharacterBasicMinimalInformations Leaver ){
            this.Leaver = Leaver;
        }

        public override void Serialize(IDataWriter writer)
        {
            Leaver.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Leaver = new CharacterBasicMinimalInformations();
            Leaver.Deserialize(reader);
        }
    }
}
