using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DungeonKeyRingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6299;

        public override ushort MessageID => ProtocolId;

        public List<short> Availables { get; set; }
        public List<short> Unavailables { get; set; }
        public DungeonKeyRingMessage() { }

        public DungeonKeyRingMessage( List<short> Availables, List<short> Unavailables ){
            this.Availables = Availables;
            this.Unavailables = Unavailables;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Availables.Count);
			foreach (var x in Availables)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)Unavailables.Count);
			foreach (var x in Unavailables)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var AvailablesCount = reader.ReadShort();
            Availables = new List<short>();
            for (var i = 0; i < AvailablesCount; i++)
            {
                Availables.Add(reader.ReadVarShort());
            }
            var UnavailablesCount = reader.ReadShort();
            Unavailables = new List<short>();
            for (var i = 0; i < UnavailablesCount; i++)
            {
                Unavailables.Add(reader.ReadVarShort());
            }
        }
    }
}
