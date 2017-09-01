using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6408;

        public AllianceListMessage(List<AllianceFactSheetInformations> alliances)
        {
            Alliances = alliances;
        }

        public AllianceListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<AllianceFactSheetInformations> Alliances { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Alliances.Count);
            for (var alliancesIndex = 0; alliancesIndex < Alliances.Count; alliancesIndex++)
            {
                var objectToSend = Alliances[alliancesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var alliancesCount = reader.ReadUShort();
            Alliances = new List<AllianceFactSheetInformations>();
            for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
            {
                var objectToAdd = new AllianceFactSheetInformations();
                objectToAdd.Deserialize(reader);
                Alliances.Add(objectToAdd);
            }
        }
    }
}