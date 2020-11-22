using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 455;

        public override ushort TypeID => ProtocolId;

        public ushort CreatureGenericId { get; set; }
        public GameFightFighterMonsterLightInformations() { }

        public GameFightFighterMonsterLightInformations( ushort CreatureGenericId ){
            this.CreatureGenericId = CreatureGenericId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CreatureGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarUhShort();
        }
    }
}
