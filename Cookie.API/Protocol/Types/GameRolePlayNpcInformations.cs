using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 156;

        public override ushort TypeID => ProtocolId;

        public ushort NpcId { get; set; }
        public bool Sex { get; set; }
        public ushort SpecialArtworkId { get; set; }
        public GameRolePlayNpcInformations() { }

        public GameRolePlayNpcInformations( ushort NpcId, bool Sex, ushort SpecialArtworkId ){
            this.NpcId = NpcId;
            this.Sex = Sex;
            this.SpecialArtworkId = SpecialArtworkId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(NpcId);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(SpecialArtworkId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarUhShort();
            Sex = reader.ReadBoolean();
            SpecialArtworkId = reader.ReadVarUhShort();
        }
    }
}
