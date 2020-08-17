namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Social;
    using System.Collections.Generic;
    using Utils.IO;

    public class GuildVersatileInfoListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6435;
        public override ushort MessageID => ProtocolId;
        public List<GuildVersatileInformations> Guilds { get; set; }

        public GuildVersatileInfoListMessage(List<GuildVersatileInformations> guilds)
        {
            Guilds = guilds;
        }

        public GuildVersatileInfoListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Guilds.Count);
            for (var guildsIndex = 0; guildsIndex < Guilds.Count; guildsIndex++)
            {
                var objectToSend = Guilds[guildsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var guildsCount = reader.ReadUShort();
            Guilds = new List<GuildVersatileInformations>();
            for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GuildVersatileInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
        }

    }
}
