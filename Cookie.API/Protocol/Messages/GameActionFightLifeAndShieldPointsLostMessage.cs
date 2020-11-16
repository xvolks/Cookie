using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
    {
        public new const ushort ProtocolId = 6310;

        public override ushort MessageID => ProtocolId;

        public ushort ShieldLoss { get; set; }
        public GameActionFightLifeAndShieldPointsLostMessage() { }

        public GameActionFightLifeAndShieldPointsLostMessage( ushort ShieldLoss ){
            this.ShieldLoss = ShieldLoss;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ShieldLoss);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ShieldLoss = reader.ReadVarUhShort();
        }
    }
}
