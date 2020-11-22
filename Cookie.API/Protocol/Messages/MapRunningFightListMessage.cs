using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapRunningFightListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5743;

        public override ushort MessageID => ProtocolId;

        public List<FightExternalInformations> Fights { get; set; }
        public MapRunningFightListMessage() { }

        public MapRunningFightListMessage( List<FightExternalInformations> Fights ){
            this.Fights = Fights;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Fights.Count);
			foreach (var x in Fights)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FightsCount = reader.ReadShort();
            Fights = new List<FightExternalInformations>();
            for (var i = 0; i < FightsCount; i++)
            {
                var objectToAdd = new FightExternalInformations();
                objectToAdd.Deserialize(reader);
                Fights.Add(objectToAdd);
            }
        }
    }
}
