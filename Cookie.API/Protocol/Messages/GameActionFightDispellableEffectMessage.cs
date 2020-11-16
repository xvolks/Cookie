using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6070;

        public override ushort MessageID => ProtocolId;

        public AbstractFightDispellableEffect Effect { get; set; }
        public GameActionFightDispellableEffectMessage() { }

        public GameActionFightDispellableEffectMessage( AbstractFightDispellableEffect Effect ){
            this.Effect = Effect;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Effect.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Effect = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Effect.Deserialize(reader);
        }
    }
}
