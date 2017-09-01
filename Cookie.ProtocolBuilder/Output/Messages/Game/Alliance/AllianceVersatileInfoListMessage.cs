namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Social;
    using System.Collections.Generic;
    using Utils.IO;

    public class AllianceVersatileInfoListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6436;
        public override ushort MessageID => ProtocolId;
        public List<AllianceVersatileInformations> Alliances { get; set; }

        public AllianceVersatileInfoListMessage(List<AllianceVersatileInformations> alliances)
        {
            Alliances = alliances;
        }

        public AllianceVersatileInfoListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Alliances.Count);
            for (var alliancesIndex = 0; alliancesIndex < Alliances.Count; alliancesIndex++)
            {
                var objectToSend = Alliances[alliancesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var alliancesCount = reader.ReadUShort();
            Alliances = new List<AllianceVersatileInformations>();
            for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
            {
                var objectToAdd = new AllianceVersatileInformations();
                objectToAdd.Deserialize(reader);
                Alliances.Add(objectToAdd);
            }
        }

    }
}
