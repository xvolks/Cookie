using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6312;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public uint Loss { get; set; }
        public uint PermanentDamages { get; set; }
        public int ElementId { get; set; }
        public GameActionFightLifePointsLostMessage() { }

        public GameActionFightLifePointsLostMessage( double TargetId, uint Loss, uint PermanentDamages, int ElementId ){
            this.TargetId = TargetId;
            this.Loss = Loss;
            this.PermanentDamages = PermanentDamages;
            this.ElementId = ElementId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(Loss);
            writer.WriteVarUhInt(PermanentDamages);
            writer.WriteVarInt(ElementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Loss = reader.ReadVarUhInt();
            PermanentDamages = reader.ReadVarUhInt();
            ElementId = reader.ReadVarInt();
        }
    }
}
