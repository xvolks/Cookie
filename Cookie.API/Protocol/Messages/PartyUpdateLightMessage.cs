using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyUpdateLightMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 6054;

        public override ushort MessageID => ProtocolId;

        public ulong Id { get; set; }
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort Prospecting { get; set; }
        public byte RegenRate { get; set; }
        public PartyUpdateLightMessage() { }

        public PartyUpdateLightMessage( ulong Id, uint LifePoints, uint MaxLifePoints, ushort Prospecting, byte RegenRate ){
            this.Id = Id;
            this.LifePoints = LifePoints;
            this.MaxLifePoints = MaxLifePoints;
            this.Prospecting = Prospecting;
            this.RegenRate = RegenRate;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Id);
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Id = reader.ReadVarUhLong();
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            Prospecting = reader.ReadVarUhShort();
            RegenRate = reader.ReadByte();
        }
    }
}
