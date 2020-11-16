using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6791;

        public override ushort MessageID => ProtocolId;

        public uint Floor { get; set; }
        public sbyte Room { get; set; }
        public List<BreachBranch> Branches { get; set; }
        public MapComplementaryInformationsBreachMessage() { }

        public MapComplementaryInformationsBreachMessage( uint Floor, sbyte Room, List<BreachBranch> Branches ){
            this.Floor = Floor;
            this.Room = Room;
            this.Branches = Branches;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Floor);
            writer.WriteSByte(Room);
			writer.WriteShort((short)Branches.Count);
			foreach (var x in Branches)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Floor = reader.ReadVarUhInt();
            Room = reader.ReadSByte();
            var BranchesCount = reader.ReadShort();
            Branches = new List<BreachBranch>();
            for (var i = 0; i < BranchesCount; i++)
            {
                var objectToAdd = new BreachBranch();
                objectToAdd.Deserialize(reader);
                Branches.Add(objectToAdd);
            }
        }
    }
}
