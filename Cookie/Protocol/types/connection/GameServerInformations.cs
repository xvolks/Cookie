using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameServerInformations : NetworkType
    {
        public const short ProtocolId = 25;
        public override short TypeId { get { return ProtocolId; } }

        public bool IsMonoAccount = false;
        public bool IsSelectable = false;
        public short Id_ = 0;
        public byte Type = unchecked((byte)-1);
        public byte Status = 1;
        public byte Completion = 0;
        public byte CharactersCount = 0;
        public byte CharactersSlots = 0;
        public double Date = 0;

        public GameServerInformations()
        {
        }

        public GameServerInformations(
            bool isMonoAccount,
            bool isSelectable,
            short id_,
            byte type,
            byte status,
            byte completion,
            byte charactersCount,
            byte charactersSlots,
            double date
        )
        {
            IsMonoAccount = isMonoAccount;
            IsSelectable = isSelectable;
            Id_ = id_;
            Type = type;
            Status = status;
            Completion = completion;
            CharactersCount = charactersCount;
            CharactersSlots = charactersSlots;
            Date = date;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, IsMonoAccount);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsSelectable);
            writer.WriteByte(box0);
            writer.WriteVarShort(Id_);
            writer.WriteByte(Type);
            writer.WriteByte(Status);
            writer.WriteByte(Completion);
            writer.WriteByte(CharactersCount);
            writer.WriteByte(CharactersSlots);
            writer.WriteDouble(Date);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            IsMonoAccount = BooleanByteWrapper.GetFlag(box0, 1);
            IsSelectable = BooleanByteWrapper.GetFlag(box0, 2);
            Id_ = reader.ReadVarShort();
            Type = reader.ReadByte();
            Status = reader.ReadByte();
            Completion = reader.ReadByte();
            CharactersCount = reader.ReadByte();
            CharactersSlots = reader.ReadByte();
            Date = reader.ReadDouble();
        }
    }
}