using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyUpdateLightMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 6054;

        public PartyUpdateLightMessage(ulong objectId, uint lifePoints, uint maxLifePoints, ushort prospecting,
            byte regenRate)
        {
            ObjectId = objectId;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
        }

        public PartyUpdateLightMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong ObjectId { get; set; }
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort Prospecting { get; set; }
        public byte RegenRate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(ObjectId);
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectId = reader.ReadVarUhLong();
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            Prospecting = reader.ReadVarUhShort();
            RegenRate = reader.ReadByte();
        }
    }
}