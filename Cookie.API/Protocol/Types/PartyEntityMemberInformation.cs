using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyEntityMemberInformation : PartyEntityBaseInformation
    {
        public new const ushort ProtocolId = 550;

        public override ushort TypeID => ProtocolId;

        public ushort Initiative { get; set; }
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort Prospecting { get; set; }
        public byte RegenRate { get; set; }
        public PartyEntityMemberInformation() { }

        public PartyEntityMemberInformation( ushort Initiative, uint LifePoints, uint MaxLifePoints, ushort Prospecting, byte RegenRate ){
            this.Initiative = Initiative;
            this.LifePoints = LifePoints;
            this.MaxLifePoints = MaxLifePoints;
            this.Prospecting = Prospecting;
            this.RegenRate = RegenRate;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Initiative);
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Initiative = reader.ReadVarUhShort();
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            Prospecting = reader.ReadVarUhShort();
            RegenRate = reader.ReadByte();
        }
    }
}
