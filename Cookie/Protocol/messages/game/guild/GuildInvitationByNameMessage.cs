using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInvitationByNameMessage : NetworkMessage
    {
        public const uint ProtocolId = 6115;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;

        public GuildInvitationByNameMessage()
        {
        }

        public GuildInvitationByNameMessage(
            string name
        )
        {
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
        }
    }
}