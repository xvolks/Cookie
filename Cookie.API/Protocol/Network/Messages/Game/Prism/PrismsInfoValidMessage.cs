using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Prism;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismsInfoValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6451;

        public PrismsInfoValidMessage(List<PrismFightersInformation> fights)
        {
            Fights = fights;
        }

        public PrismsInfoValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<PrismFightersInformation> Fights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Fights.Count);
            for (var fightsIndex = 0; fightsIndex < Fights.Count; fightsIndex++)
            {
                var objectToSend = Fights[fightsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var fightsCount = reader.ReadUShort();
            Fights = new List<PrismFightersInformation>();
            for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
            {
                var objectToAdd = new PrismFightersInformation();
                objectToAdd.Deserialize(reader);
                Fights.Add(objectToAdd);
            }
        }
    }
}