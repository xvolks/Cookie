using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6408;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AllianceFactSheetInformations> Alliances;

        public AllianceListMessage()
        {
        }

        public AllianceListMessage(
            List<AllianceFactSheetInformations> alliances
        )
        {
            Alliances = alliances;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Alliances.Count());
            foreach (var current in Alliances)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countAlliances = reader.ReadShort();
            Alliances = new List<AllianceFactSheetInformations>();
            for (short i = 0; i < countAlliances; i++)
            {
                AllianceFactSheetInformations type = new AllianceFactSheetInformations();
                type.Deserialize(reader);
                Alliances.Add(type);
            }
        }
    }
}