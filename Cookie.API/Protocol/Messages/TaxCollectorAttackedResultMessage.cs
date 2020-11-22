using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorAttackedResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5635;

        public override ushort MessageID => ProtocolId;

        public bool DeadOrAlive { get; set; }
        public TaxCollectorBasicInformations BasicInfos { get; set; }
        public BasicGuildInformations Guild { get; set; }
        public TaxCollectorAttackedResultMessage() { }

        public TaxCollectorAttackedResultMessage( bool DeadOrAlive, TaxCollectorBasicInformations BasicInfos, BasicGuildInformations Guild ){
            this.DeadOrAlive = DeadOrAlive;
            this.BasicInfos = BasicInfos;
            this.Guild = Guild;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(DeadOrAlive);
            BasicInfos.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            DeadOrAlive = reader.ReadBoolean();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}
