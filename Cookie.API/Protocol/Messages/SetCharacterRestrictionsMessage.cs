using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SetCharacterRestrictionsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 170;

        public override ushort MessageID => ProtocolId;

        public double ActorId { get; set; }
        public ActorRestrictionsInformations Restrictions { get; set; }
        public SetCharacterRestrictionsMessage() { }

        public SetCharacterRestrictionsMessage( double ActorId, ActorRestrictionsInformations Restrictions ){
            this.ActorId = ActorId;
            this.Restrictions = Restrictions;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ActorId);
            Restrictions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActorId = reader.ReadDouble();
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
        }
    }
}
