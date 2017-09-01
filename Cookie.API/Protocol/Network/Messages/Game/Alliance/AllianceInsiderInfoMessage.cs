using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Prism;
using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceInsiderInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6403;

        public AllianceInsiderInfoMessage(AllianceFactSheetInformations allianceInfos,
            List<GuildInsiderFactSheetInformations> guilds, List<PrismSubareaEmptyInfo> prisms)
        {
            AllianceInfos = allianceInfos;
            Guilds = guilds;
            Prisms = prisms;
        }

        public AllianceInsiderInfoMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public AllianceFactSheetInformations AllianceInfos { get; set; }
        public List<GuildInsiderFactSheetInformations> Guilds { get; set; }
        public List<PrismSubareaEmptyInfo> Prisms { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            AllianceInfos.Serialize(writer);
            writer.WriteShort((short) Guilds.Count);
            for (var guildsIndex = 0; guildsIndex < Guilds.Count; guildsIndex++)
            {
                var objectToSend = Guilds[guildsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Prisms.Count);
            for (var prismsIndex = 0; prismsIndex < Prisms.Count; prismsIndex++)
            {
                var objectToSend = Prisms[prismsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceInfos = new AllianceFactSheetInformations();
            AllianceInfos.Deserialize(reader);
            var guildsCount = reader.ReadUShort();
            Guilds = new List<GuildInsiderFactSheetInformations>();
            for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
            {
                var objectToAdd = new GuildInsiderFactSheetInformations();
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
            var prismsCount = reader.ReadUShort();
            Prisms = new List<PrismSubareaEmptyInfo>();
            for (var prismsIndex = 0; prismsIndex < prismsCount; prismsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Prisms.Add(objectToAdd);
            }
        }
    }
}