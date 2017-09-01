using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Dungeon
{
    public class DungeonKeyRingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6299;

        public DungeonKeyRingMessage(List<ushort> availables, List<ushort> unavailables)
        {
            Availables = availables;
            Unavailables = unavailables;
        }

        public DungeonKeyRingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> Availables { get; set; }
        public List<ushort> Unavailables { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Availables.Count);
            for (var availablesIndex = 0; availablesIndex < Availables.Count; availablesIndex++)
                writer.WriteVarUhShort(Availables[availablesIndex]);
            writer.WriteShort((short) Unavailables.Count);
            for (var unavailablesIndex = 0; unavailablesIndex < Unavailables.Count; unavailablesIndex++)
                writer.WriteVarUhShort(Unavailables[unavailablesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var availablesCount = reader.ReadUShort();
            Availables = new List<ushort>();
            for (var availablesIndex = 0; availablesIndex < availablesCount; availablesIndex++)
                Availables.Add(reader.ReadVarUhShort());
            var unavailablesCount = reader.ReadUShort();
            Unavailables = new List<ushort>();
            for (var unavailablesIndex = 0; unavailablesIndex < unavailablesCount; unavailablesIndex++)
                Unavailables.Add(reader.ReadVarUhShort());
        }
    }
}