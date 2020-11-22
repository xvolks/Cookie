using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 471;

        public override ushort TypeID => ProtocolId;

        public ushort NpcId { get; set; }
        public GameRolePlayTreasureHintInformations() { }

        public GameRolePlayTreasureHintInformations( ushort NpcId ){
            this.NpcId = NpcId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarUhShort();
        }
    }
}
