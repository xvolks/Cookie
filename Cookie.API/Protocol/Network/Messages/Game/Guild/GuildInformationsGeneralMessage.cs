using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInformationsGeneralMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5557;

        public GuildInformationsGeneralMessage(bool abandonnedPaddock, byte level, ulong expLevelFloor,
            ulong experience, ulong expNextLevelFloor, int creationDate, ushort nbTotalMembers,
            ushort nbConnectedMembers)
        {
            AbandonnedPaddock = abandonnedPaddock;
            Level = level;
            ExpLevelFloor = expLevelFloor;
            Experience = experience;
            ExpNextLevelFloor = expNextLevelFloor;
            CreationDate = creationDate;
            NbTotalMembers = nbTotalMembers;
            NbConnectedMembers = nbConnectedMembers;
        }

        public GuildInformationsGeneralMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool AbandonnedPaddock { get; set; }
        public byte Level { get; set; }
        public ulong ExpLevelFloor { get; set; }
        public ulong Experience { get; set; }
        public ulong ExpNextLevelFloor { get; set; }
        public int CreationDate { get; set; }
        public ushort NbTotalMembers { get; set; }
        public ushort NbConnectedMembers { get; set; }

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