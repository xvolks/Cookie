using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInformationsGeneralMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5557;

        public override ushort MessageID => ProtocolId;

        public bool AbandonnedPaddock { get; set; }
        public byte Level { get; set; }
        public ulong ExpLevelFloor { get; set; }
        public ulong Experience { get; set; }
        public ulong ExpNextLevelFloor { get; set; }
        public int CreationDate { get; set; }
        public ushort NbTotalMembers { get; set; }
        public ushort NbConnectedMembers { get; set; }
        public GuildInformationsGeneralMessage() { }

        public GuildInformationsGeneralMessage( bool AbandonnedPaddock, byte Level, ulong ExpLevelFloor, ulong Experience, ulong ExpNextLevelFloor, int CreationDate, ushort NbTotalMembers, ushort NbConnectedMembers ){
            this.AbandonnedPaddock = AbandonnedPaddock;
            this.Level = Level;
            this.ExpLevelFloor = ExpLevelFloor;
            this.Experience = Experience;
            this.ExpNextLevelFloor = ExpNextLevelFloor;
            this.CreationDate = CreationDate;
            this.NbTotalMembers = NbTotalMembers;
            this.NbConnectedMembers = NbConnectedMembers;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(AbandonnedPaddock);
            writer.WriteByte(Level);
            writer.WriteVarUhLong(ExpLevelFloor);
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhLong(ExpNextLevelFloor);
            writer.WriteInt(CreationDate);
            writer.WriteVarUhShort(NbTotalMembers);
            writer.WriteVarUhShort(NbConnectedMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            AbandonnedPaddock = reader.ReadBoolean();
            Level = reader.ReadByte();
            ExpLevelFloor = reader.ReadVarUhLong();
            Experience = reader.ReadVarUhLong();
            ExpNextLevelFloor = reader.ReadVarUhLong();
            CreationDate = reader.ReadInt();
            NbTotalMembers = reader.ReadVarUhShort();
            NbConnectedMembers = reader.ReadVarUhShort();
        }
    }
}
