using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage
    {
        public new const ushort ProtocolId = 6824;

        public override ushort MessageID => ProtocolId;

        public uint Floor { get; set; }
        public sbyte Room { get; set; }
        public PartyMemberInBreachFightMessage() { }

        public PartyMemberInBreachFightMessage( uint Floor, sbyte Room ){
            this.Floor = Floor;
            this.Room = Room;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Floor);
            writer.WriteSByte(Room);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Floor = reader.ReadVarUhInt();
            Room = reader.ReadSByte();
        }
    }
}
