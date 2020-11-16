using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFactsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6415;

        public override ushort MessageID => ProtocolId;

        public GuildFactSheetInformations Infos { get; set; }
        public int CreationDate { get; set; }
        public ushort NbTaxCollectors { get; set; }
        public List<CharacterMinimalGuildPublicInformations> Members { get; set; }
        public GuildFactsMessage() { }

        public GuildFactsMessage( GuildFactSheetInformations Infos, int CreationDate, ushort NbTaxCollectors, List<CharacterMinimalGuildPublicInformations> Members ){
            this.Infos = Infos;
            this.CreationDate = CreationDate;
            this.NbTaxCollectors = NbTaxCollectors;
            this.Members = Members;
        }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
            writer.WriteInt(CreationDate);
            writer.WriteVarUhShort(NbTaxCollectors);
			writer.WriteShort((short)Members.Count);
			foreach (var x in Members)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Infos.Deserialize(reader);
            CreationDate = reader.ReadInt();
            NbTaxCollectors = reader.ReadVarUhShort();
            var MembersCount = reader.ReadShort();
            Members = new List<CharacterMinimalGuildPublicInformations>();
            for (var i = 0; i < MembersCount; i++)
            {
                var objectToAdd = new CharacterMinimalGuildPublicInformations();
                objectToAdd.Deserialize(reader);
                Members.Add(objectToAdd);
            }
        }
    }
}
