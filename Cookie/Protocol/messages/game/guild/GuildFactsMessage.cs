using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFactsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6415;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildFactSheetInformations Infos;
        public int CreationDate = 0;
        public short NbTaxCollectors = 0;
        public List<CharacterMinimalGuildPublicInformations> Members;

        public GuildFactsMessage()
        {
        }

        public GuildFactsMessage(
            GuildFactSheetInformations infos,
            int creationDate,
            short nbTaxCollectors,
            List<CharacterMinimalGuildPublicInformations> members
        )
        {
            Infos = infos;
            CreationDate = creationDate;
            NbTaxCollectors = nbTaxCollectors;
            Members = members;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Infos.TypeId);
            Infos.Serialize(writer);
            writer.WriteInt(CreationDate);
            writer.WriteVarShort(NbTaxCollectors);
            writer.WriteShort((short)Members.Count());
            foreach (var current in Members)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var infosTypeId = reader.ReadShort();
            Infos = new GuildFactSheetInformations();
            Infos.Deserialize(reader);
            CreationDate = reader.ReadInt();
            NbTaxCollectors = reader.ReadVarShort();
            var countMembers = reader.ReadShort();
            Members = new List<CharacterMinimalGuildPublicInformations>();
            for (short i = 0; i < countMembers; i++)
            {
                CharacterMinimalGuildPublicInformations type = new CharacterMinimalGuildPublicInformations();
                type.Deserialize(reader);
                Members.Add(type);
            }
        }
    }
}