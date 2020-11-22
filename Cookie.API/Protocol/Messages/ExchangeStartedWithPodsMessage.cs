using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
    {
        public new const ushort ProtocolId = 6129;

        public override ushort MessageID => ProtocolId;

        public double FirstCharacterId { get; set; }
        public uint FirstCharacterCurrentWeight { get; set; }
        public uint FirstCharacterMaxWeight { get; set; }
        public double SecondCharacterId { get; set; }
        public uint SecondCharacterCurrentWeight { get; set; }
        public uint SecondCharacterMaxWeight { get; set; }
        public ExchangeStartedWithPodsMessage() { }

        public ExchangeStartedWithPodsMessage( double FirstCharacterId, uint FirstCharacterCurrentWeight, uint FirstCharacterMaxWeight, double SecondCharacterId, uint SecondCharacterCurrentWeight, uint SecondCharacterMaxWeight ){
            this.FirstCharacterId = FirstCharacterId;
            this.FirstCharacterCurrentWeight = FirstCharacterCurrentWeight;
            this.FirstCharacterMaxWeight = FirstCharacterMaxWeight;
            this.SecondCharacterId = SecondCharacterId;
            this.SecondCharacterCurrentWeight = SecondCharacterCurrentWeight;
            this.SecondCharacterMaxWeight = SecondCharacterMaxWeight;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(FirstCharacterId);
            writer.WriteVarUhInt(FirstCharacterCurrentWeight);
            writer.WriteVarUhInt(FirstCharacterMaxWeight);
            writer.WriteDouble(SecondCharacterId);
            writer.WriteVarUhInt(SecondCharacterCurrentWeight);
            writer.WriteVarUhInt(SecondCharacterMaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstCharacterId = reader.ReadDouble();
            FirstCharacterCurrentWeight = reader.ReadVarUhInt();
            FirstCharacterMaxWeight = reader.ReadVarUhInt();
            SecondCharacterId = reader.ReadDouble();
            SecondCharacterCurrentWeight = reader.ReadVarUhInt();
            SecondCharacterMaxWeight = reader.ReadVarUhInt();
        }
    }
}
