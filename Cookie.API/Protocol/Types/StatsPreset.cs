using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class StatsPreset : Preset
    {
        public new const ushort ProtocolId = 521;

        public override ushort TypeID => ProtocolId;

        public List<SimpleCharacterCharacteristicForPreset> Stats { get; set; }
        public StatsPreset() { }

        public StatsPreset( List<SimpleCharacterCharacteristicForPreset> Stats ){
            this.Stats = Stats;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Stats.Count);
			foreach (var x in Stats)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var StatsCount = reader.ReadShort();
            Stats = new List<SimpleCharacterCharacteristicForPreset>();
            for (var i = 0; i < StatsCount; i++)
            {
                var objectToAdd = new SimpleCharacterCharacteristicForPreset();
                objectToAdd.Deserialize(reader);
                Stats.Add(objectToAdd);
            }
        }
    }
}
