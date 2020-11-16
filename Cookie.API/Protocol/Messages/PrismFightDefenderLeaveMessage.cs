using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightDefenderLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5892;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public ulong FighterToRemoveId { get; set; }
        public PrismFightDefenderLeaveMessage() { }

        public PrismFightDefenderLeaveMessage( ushort SubAreaId, ushort FightId, ulong FighterToRemoveId ){
            this.SubAreaId = SubAreaId;
            this.FightId = FightId;
            this.FighterToRemoveId = FighterToRemoveId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(FightId);
            writer.WriteVarUhLong(FighterToRemoveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            FightId = reader.ReadVarUhShort();
            FighterToRemoveId = reader.ReadVarUhLong();
        }
    }
}
