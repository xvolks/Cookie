using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInformationsPaddocksMessage : NetworkMessage
    {
        public const uint ProtocolId = 5959;
        public override uint MessageID { get { return ProtocolId; } }

        public byte NbPaddockMax = 0;
        public List<PaddockContentInformations> PaddocksInformations;

        public GuildInformationsPaddocksMessage()
        {
        }

        public GuildInformationsPaddocksMessage(
            byte nbPaddockMax,
            List<PaddockContentInformations> paddocksInformations
        )
        {
            NbPaddockMax = nbPaddockMax;
            PaddocksInformations = paddocksInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(NbPaddockMax);
            writer.WriteShort((short)PaddocksInformations.Count());
            foreach (var current in PaddocksInformations)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NbPaddockMax = reader.ReadByte();
            var countPaddocksInformations = reader.ReadShort();
            PaddocksInformations = new List<PaddockContentInformations>();
            for (short i = 0; i < countPaddocksInformations; i++)
            {
                PaddockContentInformations type = new PaddockContentInformations();
                type.Deserialize(reader);
                PaddocksInformations.Add(type);
            }
        }
    }
}