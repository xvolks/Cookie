namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Types.Game.Prism;
    using System.Collections.Generic;
    using Utils.IO;

    public class PrismsInfoValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6451;
        public override ushort MessageID => ProtocolId;
        public List<PrismFightersInformation> Fights { get; set; }

        public PrismsInfoValidMessage(List<PrismFightersInformation> fights)
        {
            Fights = fights;
        }

        public PrismsInfoValidMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Fights.Count);
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
