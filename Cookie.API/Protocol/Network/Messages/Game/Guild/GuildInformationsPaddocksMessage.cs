namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Paddock;
    using System.Collections.Generic;
    using Utils.IO;

    public class GuildInformationsPaddocksMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5959;
        public override ushort MessageID => ProtocolId;
        public byte NbPaddockMax { get; set; }
        public List<PaddockContentInformations> PaddocksInformations { get; set; }

        public GuildInformationsPaddocksMessage(byte nbPaddockMax, List<PaddockContentInformations> paddocksInformations)
        {
            NbPaddockMax = nbPaddockMax;
            PaddocksInformations = paddocksInformations;
        }

        public GuildInformationsPaddocksMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NbPaddockMax);
            writer.WriteShort((short)PaddocksInformations.Count);
            for (var paddocksInformationsIndex = 0; paddocksInformationsIndex < PaddocksInformations.Count; paddocksInformationsIndex++)
            {
                var objectToSend = PaddocksInformations[paddocksInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            NbPaddockMax = reader.ReadByte();
            var paddocksInformationsCount = reader.ReadUShort();
            PaddocksInformations = new List<PaddockContentInformations>();
            for (var paddocksInformationsIndex = 0; paddocksInformationsIndex < paddocksInformationsCount; paddocksInformationsIndex++)
            {
                var objectToAdd = new PaddockContentInformations();
                objectToAdd.Deserialize(reader);
                PaddocksInformations.Add(objectToAdd);
            }
        }

    }
}
