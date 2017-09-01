using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Connection
{
    public class GameServerInformations : NetworkType
    {
        public const ushort ProtocolId = 25;

        public GameServerInformations(ushort objectId, sbyte type, byte status, byte completion, bool isSelectable,
            byte charactersCount, byte charactersSlots, double date)
        {
            ObjectId = objectId;
            Type = type;
            Status = status;
            Completion = completion;
            IsSelectable = isSelectable;
            CharactersCount = charactersCount;
            CharactersSlots = charactersSlots;
            Date = date;
        }

        public GameServerInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ObjectId { get; set; }
        public sbyte Type { get; set; }
        public byte Status { get; set; }
        public byte Completion { get; set; }
        public bool IsSelectable { get; set; }
        public byte CharactersCount { get; set; }
        public byte CharactersSlots { get; set; }
        public double Date { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
            writer.WriteSByte(Type);
            writer.WriteByte(Status);
            writer.WriteByte(Completion);
            writer.WriteBoolean(IsSelectable);
            writer.WriteByte(CharactersCount);
            writer.WriteByte(CharactersSlots);
            writer.WriteDouble(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
            Type = reader.ReadSByte();
            Status = reader.ReadByte();
            Completion = reader.ReadByte();
            IsSelectable = reader.ReadBoolean();
            CharactersCount = reader.ReadByte();
            CharactersSlots = reader.ReadByte();
            Date = reader.ReadDouble();
        }
    }
}