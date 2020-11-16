using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FullStatsPreset : Preset
    {
        public new const ushort ProtocolId = 532;

        public override ushort TypeID => ProtocolId;

        public List<CharacterCharacteristicForPreset> Stats { get; set; }
        public FullStatsPreset() { }

        public FullStatsPreset( List<CharacterCharacteristicForPreset> Stats ){
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
            Stats = new List<CharacterCharacteristicForPreset>();
            for (var i = 0; i < StatsCount; i++)
            {
                var objectToAdd = new CharacterCharacteristicForPreset();
                objectToAdd.Deserialize(reader);
                Stats.Add(objectToAdd);
            }
        }
    }
}
