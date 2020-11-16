using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
    {
        public new const ushort ProtocolId = 6113;

        public override ushort MessageID => ProtocolId;

        public int BoostUID { get; set; }
        public GameActionFightDispellEffectMessage() { }

        public GameActionFightDispellEffectMessage( int BoostUID ){
            this.BoostUID = BoostUID;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(BoostUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BoostUID = reader.ReadInt();
        }
    }
}
