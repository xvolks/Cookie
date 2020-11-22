using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismsInfoValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6451;
        public override uint MessageID { get { return ProtocolId; } }

        public List<PrismFightersInformation> Fights;

        public PrismsInfoValidMessage()
        {
        }

        public PrismsInfoValidMessage(
            List<PrismFightersInformation> fights
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
            Fights = new List<PrismFightersInformation>();
            for (short i = 0; i < countFights; i++)
            {
                PrismFightersInformation type = new PrismFightersInformation();
                type.Deserialize(reader);
                Fights.Add(type);
            }
        }
    }
}