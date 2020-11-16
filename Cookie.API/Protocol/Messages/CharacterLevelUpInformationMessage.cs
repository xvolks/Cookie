using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
    {
        public new const ushort ProtocolId = 6076;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public ulong Id { get; set; }
        public CharacterLevelUpInformationMessage() { }

        public CharacterLevelUpInformationMessage( string Name, ulong Id ){
            this.Name = Name;
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarUhLong(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Id = reader.ReadVarUhLong();
        }
    }
}
