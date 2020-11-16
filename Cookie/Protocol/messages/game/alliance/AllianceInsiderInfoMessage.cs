using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceInsiderInfoMessage : NetworkMessage
    {
        public const uint ProtocolId = 6403;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceFactSheetInformations AllianceInfos;
        public List<GuildInsiderFactSheetInformations> Guilds;
        public List<PrismSubareaEmptyInfo> Prisms;

        public AllianceInsiderInfoMessage()
        {
        }

        public AllianceInsiderInfoMessage(
            AllianceFactSheetInformations allianceInfos,
            List<GuildInsiderFactSheetInformations> guilds,
            List<PrismSubareaEmptyInfo> prisms
        )
        {
            AllianceInfos = allianceInfos;
            Guilds = guilds;
            Prisms = prisms;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            AllianceInfos.Serialize(writer);
            writer.WriteShort((short)Guilds.Count());
            foreach (var current in Guilds)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)Prisms.Count());
            foreach (var current in Prisms)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceInfos = new AllianceFactSheetInformations();
            AllianceInfos.Deserialize(reader);
            var countGuilds = reader.ReadShort();
            Guilds = new List<GuildInsiderFactSheetInformations>();
            for (short i = 0; i < countGuilds; i++)
            {
                GuildInsiderFactSheetInformations type = new GuildInsiderFactSheetInformations();
                type.Deserialize(reader);
                Guilds.Add(type);
            }
            var countPrisms = reader.ReadShort();
            Prisms = new List<PrismSubareaEmptyInfo>();
            for (short i = 0; i < countPrisms; i++)
            {
                var prismstypeId = reader.ReadShort();
                PrismSubareaEmptyInfo type = new PrismSubareaEmptyInfo();
                type.Deserialize(reader);
                Prisms.Add(type);
            }
        }
    }
}