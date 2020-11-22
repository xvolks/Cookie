using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightAttackerAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5893;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public CharacterMinimalPlusLookInformations Attacker { get; set; }
        public PrismFightAttackerAddMessage() { }

        public PrismFightAttackerAddMessage( ushort SubAreaId, ushort FightId, CharacterMinimalPlusLookInformations Attacker ){
            this.SubAreaId = SubAreaId;
            this.FightId = FightId;
            this.Attacker = Attacker;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(FightId);
            Attacker.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            FightId = reader.ReadVarUhShort();
            Attacker = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Attacker.Deserialize(reader);
        }
    }
}
