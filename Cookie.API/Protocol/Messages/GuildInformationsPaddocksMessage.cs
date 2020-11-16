using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInformationsPaddocksMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5959;

        public override ushort MessageID => ProtocolId;

        public sbyte NbPaddockMax { get; set; }
        public List<PaddockContentInformations> PaddocksInformations { get; set; }
        public GuildInformationsPaddocksMessage() { }

        public GuildInformationsPaddocksMessage( sbyte NbPaddockMax, List<PaddockContentInformations> PaddocksInformations ){
            this.NbPaddockMax = NbPaddockMax;
            this.PaddocksInformations = PaddocksInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(NbPaddockMax);
			writer.WriteShort((short)PaddocksInformations.Count);
			foreach (var x in PaddocksInformations)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            NbPaddockMax = reader.ReadSByte();
            var PaddocksInformationsCount = reader.ReadShort();
            PaddocksInformations = new List<PaddockContentInformations>();
            for (var i = 0; i < PaddocksInformationsCount; i++)
            {
                var objectToAdd = new PaddockContentInformations();
                objectToAdd.Deserialize(reader);
                PaddocksInformations.Add(objectToAdd);
            }
        }
    }
}
