using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServerExperienceModificatorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6237;

        public override ushort MessageID => ProtocolId;

        public ushort ExperiencePercent { get; set; }
        public ServerExperienceModificatorMessage() { }

        public ServerExperienceModificatorMessage( ushort ExperiencePercent ){
            this.ExperiencePercent = ExperiencePercent;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ExperiencePercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperiencePercent = reader.ReadVarUhShort();
        }
    }
}
