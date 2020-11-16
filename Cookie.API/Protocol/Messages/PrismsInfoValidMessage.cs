using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismsInfoValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6451;

        public override ushort MessageID => ProtocolId;

        public List<PrismFightersInformation> Fights { get; set; }
        public PrismsInfoValidMessage() { }

        public PrismsInfoValidMessage( List<PrismFightersInformation> Fights ){
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
            Fights = new List<PrismFightersInformation>();
            for (var i = 0; i < FightsCount; i++)
            {
                var objectToAdd = new PrismFightersInformation();
                objectToAdd.Deserialize(reader);
                Fights.Add(objectToAdd);
            }
        }
    }
}
