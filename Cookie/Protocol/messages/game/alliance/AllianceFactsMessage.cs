using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceFactsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6414;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceFactSheetInformations Infos;
        public List<GuildInAllianceInformations> Guilds;
        public List<short> ControlledSubareaIds;
        public long LeaderCharacterId = 0;
        public string LeaderCharacterName;

        public AllianceFactsMessage()
        {
        }

        public AllianceFactsMessage(
            AllianceFactSheetInformations infos,
            List<GuildInAllianceInformations> guilds,
            List<short> controlledSubareaIds,
            long leaderCharacterId,
            string leaderCharacterName
        )
        {
            Infos = infos;
            Guilds = guilds;
            ControlledSubareaIds = controlledSubareaIds;
            LeaderCharacterId = leaderCharacterId;
            LeaderCharacterName = leaderCharacterName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Infos.TypeId);
            Infos.Serialize(writer);
            writer.WriteShort((short)Guilds.Count());
            foreach (var current in Guilds)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)ControlledSubareaIds.Count());
            foreach (var current in ControlledSubareaIds)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteVarLong(LeaderCharacterId);
            writer.WriteUTF(LeaderCharacterName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var infosTypeId = reader.ReadShort();
            Infos = new AllianceFactSheetInformations();
            Infos.Deserialize(reader);
            var countGuilds = reader.ReadShort();
            Guilds = new List<GuildInAllianceInformations>();
            for (short i = 0; i < countGuilds; i++)
            {
                GuildInAllianceInformations type = new GuildInAllianceInformations();
                type.Deserialize(reader);
                Guilds.Add(type);
            }
            var countControlledSubareaIds = reader.ReadShort();
            ControlledSubareaIds = new List<short>();
            for (short i = 0; i < countControlledSubareaIds; i++)
            {
                ControlledSubareaIds.Add(reader.ReadVarShort());
            }
            LeaderCharacterId = reader.ReadVarLong();
            LeaderCharacterName = reader.ReadUTF();
        }
    }
}