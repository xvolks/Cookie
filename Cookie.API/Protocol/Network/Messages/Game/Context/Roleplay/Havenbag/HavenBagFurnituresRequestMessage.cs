using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class HavenBagFurnituresRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6637;

        public HavenBagFurnituresRequestMessage(List<ushort> cellIds, List<int> funitureIds, List<byte> orientations)
        {
            CellIds = cellIds;
            FunitureIds = funitureIds;
            Orientations = orientations;
        }

        public HavenBagFurnituresRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> CellIds { get; set; }
        public List<int> FunitureIds { get; set; }
        public List<byte> Orientations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) CellIds.Count);
            for (var cellIdsIndex = 0; cellIdsIndex < CellIds.Count; cellIdsIndex++)
                writer.WriteVarUhShort(CellIds[cellIdsIndex]);
            writer.WriteShort((short) FunitureIds.Count);
            for (var funitureIdsIndex = 0; funitureIdsIndex < FunitureIds.Count; funitureIdsIndex++)
                writer.WriteInt(FunitureIds[funitureIdsIndex]);
            writer.WriteShort((short) Orientations.Count);
            for (var orientationsIndex = 0; orientationsIndex < Orientations.Count; orientationsIndex++)
                writer.WriteByte(Orientations[orientationsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var cellIdsCount = reader.ReadUShort();
            CellIds = new List<ushort>();
            for (var cellIdsIndex = 0; cellIdsIndex < cellIdsCount; cellIdsIndex++)
                CellIds.Add(reader.ReadVarUhShort());
            var funitureIdsCount = reader.ReadUShort();
            FunitureIds = new List<int>();
            for (var funitureIdsIndex = 0; funitureIdsIndex < funitureIdsCount; funitureIdsIndex++)
                FunitureIds.Add(reader.ReadInt());
            var orientationsCount = reader.ReadUShort();
            Orientations = new List<byte>();
            for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
                Orientations.Add(reader.ReadByte());
        }
    }
}