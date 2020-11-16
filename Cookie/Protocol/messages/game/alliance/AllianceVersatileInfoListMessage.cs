using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceVersatileInfoListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6436;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AllianceVersatileInformations> Alliances;

        public AllianceVersatileInfoListMessage()
        {
        }

        public AllianceVersatileInfoListMessage(
            List<AllianceVersatileInformations> alliances
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
            Alliances = new List<AllianceVersatileInformations>();
            for (short i = 0; i < countAlliances; i++)
            {
                AllianceVersatileInformations type = new AllianceVersatileInformations();
                type.Deserialize(reader);
                Alliances.Add(type);
            }
        }
    }
}