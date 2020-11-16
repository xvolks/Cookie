using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 712;

        public override ushort MessageID => ProtocolId;

        public List<Idol> Idols { get; set; }
        public GameFightStartMessage() { }

        public GameFightStartMessage( List<Idol> Idols ){
            this.Idols = Idols;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Idols.Count);
			foreach (var x in Idols)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var IdolsCount = reader.ReadShort();
            Idols = new List<Idol>();
            for (var i = 0; i < IdolsCount; i++)
            {
                var objectToAdd = new Idol();
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }
    }
}
