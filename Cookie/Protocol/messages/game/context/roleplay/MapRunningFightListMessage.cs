using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapRunningFightListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5743;
        public override uint MessageID { get { return ProtocolId; } }

        public List<FightExternalInformations> Fights;

        public MapRunningFightListMessage()
        {
        }

        public MapRunningFightListMessage(
            List<FightExternalInformations> fights
        )
        {
            Fights = fights;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Fights.Count());
            foreach (var current in Fights)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFights = reader.ReadShort();
            Fights = new List<FightExternalInformations>();
            for (short i = 0; i < countFights; i++)
            {
                FightExternalInformations type = new FightExternalInformations();
                type.Deserialize(reader);
                Fights.Add(type);
            }
        }
    }
}