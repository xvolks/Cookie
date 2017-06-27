using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Connection
{
    public class GameServerInformations : NetworkType
    {
        public const short ProtocolId = 25;

        public GameServerInformations()
        {
        }

        public GameServerInformations(ushort objectId, byte serverType, byte status, byte completion, bool isSelectable,
            byte charactersCount, byte charactersSlots, double date)
        {
            ObjectID = objectId;
            ServerType = serverType;
            Status = status;
            Completion = completion;
            IsSelectable = isSelectable;
            CharactersCount = charactersCount;
            CharactersSlots = charactersSlots;
            Date = date;
        }

        public override short TypeID => ProtocolId;

        public ushort ObjectID { get; set; }
        public byte ServerType { get; set; }
        public byte Status { get; set; }
        public byte Completion { get; set; }
        public bool IsSelectable { get; set; }
        public byte CharactersCount { get; set; }
        public byte CharactersSlots { get; set; }
        public double Date { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectID);
            writer.WriteByte(ServerType);
            writer.WriteByte(Status);
            writer.WriteByte(Completion);
            writer.WriteBoolean(IsSelectable);
            writer.WriteByte(CharactersCount);
            writer.WriteByte(CharactersSlots);
            writer.WriteDouble(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectID = reader.ReadVarUhShort();
            ServerType = reader.ReadByte();
            Status = reader.ReadByte();
            Completion = reader.ReadByte();
            IsSelectable = reader.ReadBoolean();
            CharactersCount = reader.ReadByte();
            CharactersSlots = reader.ReadByte();
            Date = reader.ReadDouble();
        }
    }
}