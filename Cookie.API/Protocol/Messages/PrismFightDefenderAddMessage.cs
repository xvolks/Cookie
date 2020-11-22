using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightDefenderAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5895;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public CharacterMinimalPlusLookInformations Defender { get; set; }
        public PrismFightDefenderAddMessage() { }

        public PrismFightDefenderAddMessage( ushort SubAreaId, ushort FightId, CharacterMinimalPlusLookInformations Defender ){
            this.SubAreaId = SubAreaId;
            this.FightId = FightId;
            this.Defender = Defender;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(FightId);
            Defender.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            FightId = reader.ReadVarUhShort();
            Defender = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Defender.Deserialize(reader);
        }
    }
}
