using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class HavenBagFurnituresRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6637;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> CellIds;
        public List<int> FunitureIds;
        public List<byte> Orientations;

        public HavenBagFurnituresRequestMessage()
        {
        }

        public HavenBagFurnituresRequestMessage(
            List<short> cellIds,
            List<int> funitureIds,
            List<byte> orientations
        )
        {
            CellIds = cellIds;
            FunitureIds = funitureIds;
            Orientations = orientations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)CellIds.Count());
            foreach (var current in CellIds)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)FunitureIds.Count());
            foreach (var current in FunitureIds)
            {
                writer.WriteInt(current);
            }
            writer.WriteShort((short)Orientations.Count());
            foreach (var current in Orientations)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCellIds = reader.ReadShort();
            CellIds = new List<short>();
            for (short i = 0; i < countCellIds; i++)
            {
                CellIds.Add(reader.ReadVarShort());
            }
            var countFunitureIds = reader.ReadShort();
            FunitureIds = new List<int>();
            for (short i = 0; i < countFunitureIds; i++)
            {
                FunitureIds.Add(reader.ReadInt());
            }
            var countOrientations = reader.ReadShort();
            Orientations = new List<byte>();
            for (short i = 0; i < countOrientations; i++)
            {
                Orientations.Add(reader.ReadByte());
            }
        }
    }
}