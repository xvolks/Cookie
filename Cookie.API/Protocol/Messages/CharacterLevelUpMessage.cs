using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5670;

        public override ushort MessageID => ProtocolId;

        public ushort NewLevel { get; set; }
        public CharacterLevelUpMessage() { }

        public CharacterLevelUpMessage( ushort NewLevel ){
            this.NewLevel = NewLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(NewLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewLevel = reader.ReadVarUhShort();
        }
    }
}
