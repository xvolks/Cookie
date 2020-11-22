using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightSynchronizeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5921;

        public override ushort MessageID => ProtocolId;

        public List<GameFightFighterInformations> Fighters { get; set; }
        public GameFightSynchronizeMessage() { }

        public GameFightSynchronizeMessage( List<GameFightFighterInformations> Fighters ){
            this.Fighters = Fighters;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Fighters.Count);
			foreach (var x in Fighters)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FightersCount = reader.ReadShort();
            Fighters = new List<GameFightFighterInformations>();
            for (var i = 0; i < FightersCount; i++)
            {
                GameFightFighterInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Fighters.Add(objectToAdd);
            }
        }
    }
}
