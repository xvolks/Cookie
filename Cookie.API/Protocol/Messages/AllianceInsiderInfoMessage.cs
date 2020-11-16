using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceInsiderInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6403;

        public override ushort MessageID => ProtocolId;

        public AllianceFactSheetInformations AllianceInfos { get; set; }
        public List<GuildInsiderFactSheetInformations> Guilds { get; set; }
        public List<PrismSubareaEmptyInfo> Prisms { get; set; }
        public AllianceInsiderInfoMessage() { }

        public AllianceInsiderInfoMessage( AllianceFactSheetInformations AllianceInfos, List<GuildInsiderFactSheetInformations> Guilds, List<PrismSubareaEmptyInfo> Prisms ){
            this.AllianceInfos = AllianceInfos;
            this.Guilds = Guilds;
            this.Prisms = Prisms;
        }

        public override void Serialize(IDataWriter writer)
        {
            AllianceInfos.Serialize(writer);
			writer.WriteShort((short)Guilds.Count);
			foreach (var x in Guilds)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Prisms.Count);
			foreach (var x in Prisms)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceInfos = new AllianceFactSheetInformations();
            AllianceInfos.Deserialize(reader);
            var GuildsCount = reader.ReadShort();
            Guilds = new List<GuildInsiderFactSheetInformations>();
            for (var i = 0; i < GuildsCount; i++)
            {
                var objectToAdd = new GuildInsiderFactSheetInformations();
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
            var PrismsCount = reader.ReadShort();
            Prisms = new List<PrismSubareaEmptyInfo>();
            for (var i = 0; i < PrismsCount; i++)
            {
                PrismSubareaEmptyInfo objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Prisms.Add(objectToAdd);
            }
        }
    }
}
