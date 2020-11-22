using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HavenBagFurnituresRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6637;

        public override ushort MessageID => ProtocolId;

        public List<short> CellIds { get; set; }
        public List<int> FunitureIds { get; set; }
        public List<sbyte> Orientations { get; set; }
        public HavenBagFurnituresRequestMessage() { }

        public HavenBagFurnituresRequestMessage( List<short> CellIds, List<int> FunitureIds, List<sbyte> Orientations ){
            this.CellIds = CellIds;
            this.FunitureIds = FunitureIds;
            this.Orientations = Orientations;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)CellIds.Count);
			foreach (var x in CellIds)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)FunitureIds.Count);
			foreach (var x in FunitureIds)
			{
				writer.WriteInt(x);
			}
			writer.WriteShort((short)Orientations.Count);
			foreach (var x in Orientations)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CellIdsCount = reader.ReadShort();
            CellIds = new List<short>();
            for (var i = 0; i < CellIdsCount; i++)
            {
                CellIds.Add(reader.ReadVarShort());
            }
            var FunitureIdsCount = reader.ReadShort();
            FunitureIds = new List<int>();
            for (var i = 0; i < FunitureIdsCount; i++)
            {
                FunitureIds.Add(reader.ReadInt());
            }
            var OrientationsCount = reader.ReadShort();
            Orientations = new List<sbyte>();
            for (var i = 0; i < OrientationsCount; i++)
            {
                Orientations.Add(reader.ReadSByte());
            }
        }
    }
}
