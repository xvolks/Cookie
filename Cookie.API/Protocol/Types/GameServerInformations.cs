using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameServerInformations : NetworkType
    {
        public const ushort ProtocolId = 25;

        public override ushort TypeID => ProtocolId;

        public bool IsMonoAccount { get; set; }
        public bool IsSelectable { get; set; }
        public ushort Id { get; set; }
        public sbyte Type { get; set; }
        public sbyte Status { get; set; }
        public sbyte Completion { get; set; }
        public sbyte CharactersCount { get; set; }
        public sbyte CharactersSlots { get; set; }
        public double Date { get; set; }
        public GameServerInformations() { }

        public GameServerInformations( bool IsMonoAccount, bool IsSelectable, ushort Id, sbyte Type, sbyte Status, sbyte Completion, sbyte CharactersCount, sbyte CharactersSlots, double Date ){
            this.IsMonoAccount = IsMonoAccount;
            this.IsSelectable = IsSelectable;
            this.Id = Id;
            this.Type = Type;
            this.Status = Status;
            this.Completion = Completion;
            this.CharactersCount = CharactersCount;
            this.CharactersSlots = CharactersSlots;
            this.Date = Date;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, IsMonoAccount);
			flag = BooleanByteWrapper.SetFlag(1, flag, IsSelectable);
			writer.WriteByte(flag);
            writer.WriteVarUhShort(Id);
            writer.WriteSByte(Type);
            writer.WriteSByte(Status);
            writer.WriteSByte(Completion);
            writer.WriteSByte(CharactersCount);
            writer.WriteSByte(CharactersSlots);
            writer.WriteDouble(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			IsMonoAccount = BooleanByteWrapper.GetFlag(flag, 0);
			IsSelectable = BooleanByteWrapper.GetFlag(flag, 1);
            Id = reader.ReadVarUhShort();
            Type = reader.ReadSByte();
            Status = reader.ReadSByte();
            Completion = reader.ReadSByte();
            CharactersCount = reader.ReadSByte();
            CharactersSlots = reader.ReadSByte();
            Date = reader.ReadDouble();
        }
    }
}
