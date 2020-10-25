using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInformationsGeneralMessage : NetworkMessage
    {
        public const uint ProtocolId = 5557;
        public override uint MessageID { get { return ProtocolId; } }

        public bool AbandonnedPaddock = false;
        public byte Level = 0;
        public long ExpLevelFloor = 0;
        public long Experience = 0;
        public long ExpNextLevelFloor = 0;
        public int CreationDate = 0;
        public short NbTotalMembers = 0;
        public short NbConnectedMembers = 0;

        public GuildInformationsGeneralMessage()
        {
        }

        public GuildInformationsGeneralMessage(
            bool abandonnedPaddock,
            byte level,
            long expLevelFloor,
            long experience,
            long expNextLevelFloor,
            int creationDate,
            short nbTotalMembers,
            short nbConnectedMembers
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(AbandonnedPaddock);
            writer.WriteByte(Level);
            writer.WriteVarLong(ExpLevelFloor);
            writer.WriteVarLong(Experience);
            writer.WriteVarLong(ExpNextLevelFloor);
            writer.WriteInt(CreationDate);
            writer.WriteVarShort(NbTotalMembers);
            writer.WriteVarShort(NbConnectedMembers);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AbandonnedPaddock = reader.ReadBoolean();
            Level = reader.ReadByte();
            ExpLevelFloor = reader.ReadVarLong();
            Experience = reader.ReadVarLong();
            ExpNextLevelFloor = reader.ReadVarLong();
            CreationDate = reader.ReadInt();
            NbTotalMembers = reader.ReadVarShort();
            NbConnectedMembers = reader.ReadVarShort();
        }
    }
}