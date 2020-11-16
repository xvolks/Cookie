using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementFinishedInformationMessage : AchievementFinishedMessage
    {
        public new const ushort ProtocolId = 6381;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public ulong PlayerId { get; set; }
        public AchievementFinishedInformationMessage() { }

        public AchievementFinishedInformationMessage( string Name, ulong PlayerId ){
            this.Name = Name;
            this.PlayerId = PlayerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            PlayerId = reader.ReadVarUhLong();
        }
    }
}
