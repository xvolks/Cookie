using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceFactsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6414;

        public override ushort MessageID => ProtocolId;

        public AllianceFactSheetInformations Infos { get; set; }
        public List<GuildInAllianceInformations> Guilds { get; set; }
        public List<short> ControlledSubareaIds { get; set; }
        public ulong LeaderCharacterId { get; set; }
        public string LeaderCharacterName { get; set; }
        public AllianceFactsMessage() { }

        public AllianceFactsMessage( AllianceFactSheetInformations Infos, List<GuildInAllianceInformations> Guilds, List<short> ControlledSubareaIds, ulong LeaderCharacterId, string LeaderCharacterName ){
            this.Infos = Infos;
            this.Guilds = Guilds;
            this.ControlledSubareaIds = ControlledSubareaIds;
            this.LeaderCharacterId = LeaderCharacterId;
            this.LeaderCharacterName = LeaderCharacterName;
        }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
			writer.WriteShort((short)Guilds.Count);
			foreach (var x in Guilds)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)ControlledSubareaIds.Count);
			foreach (var x in ControlledSubareaIds)
			{
				writer.WriteVarShort(x);
			}
            writer.WriteVarUhLong(LeaderCharacterId);
            writer.WriteUTF(LeaderCharacterName);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Infos.Deserialize(reader);
            var GuildsCount = reader.ReadShort();
            Guilds = new List<GuildInAllianceInformations>();
            for (var i = 0; i < GuildsCount; i++)
            {
                var objectToAdd = new GuildInAllianceInformations();
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
            var ControlledSubareaIdsCount = reader.ReadShort();
            ControlledSubareaIds = new List<short>();
            for (var i = 0; i < ControlledSubareaIdsCount; i++)
            {
                ControlledSubareaIds.Add(reader.ReadVarShort());
            }
            LeaderCharacterId = reader.ReadVarUhLong();
            LeaderCharacterName = reader.ReadUTF();
        }
    }
}
