using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class BasicWhoIsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 180;

        public BasicWhoIsMessage(bool self, bool verbose, sbyte position, string accountNickname, int accountId,
            string playerName, ulong playerId, short areaId, short serverId, short originServerId,
            List<AbstractSocialGroupInfos> socialGroups, byte playerState)
        {
            Self = self;
            Verbose = verbose;
            Position = position;
            AccountNickname = accountNickname;
            AccountId = accountId;
            PlayerName = playerName;
            PlayerId = playerId;
            AreaId = areaId;
            ServerId = serverId;
            OriginServerId = originServerId;
            SocialGroups = socialGroups;
            PlayerState = playerState;
        }

        public BasicWhoIsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Self { get; set; }
        public bool Verbose { get; set; }
        public sbyte Position { get; set; }
        public string AccountNickname { get; set; }
        public int AccountId { get; set; }
        public string PlayerName { get; set; }
        public ulong PlayerId { get; set; }
        public short AreaId { get; set; }
        public short ServerId { get; set; }
        public short OriginServerId { get; set; }
        public List<AbstractSocialGroupInfos> SocialGroups { get; set; }
        public byte PlayerState { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Self);
            flag = BooleanByteWrapper.SetFlag(1, flag, Verbose);
            writer.WriteByte(flag);
            writer.WriteSByte(Position);
            writer.WriteUTF(AccountNickname);
            writer.WriteInt(AccountId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteShort(AreaId);
            writer.WriteShort(ServerId);
            writer.WriteShort(OriginServerId);
            writer.WriteShort((short) SocialGroups.Count);
            for (var socialGroupsIndex = 0; socialGroupsIndex < SocialGroups.Count; socialGroupsIndex++)
            {
                var objectToSend = SocialGroups[socialGroupsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteByte(PlayerState);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Self = BooleanByteWrapper.GetFlag(flag, 0);
            Verbose = BooleanByteWrapper.GetFlag(flag, 1);
            Position = reader.ReadSByte();
            AccountNickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarUhLong();
            AreaId = reader.ReadShort();
            ServerId = reader.ReadShort();
            OriginServerId = reader.ReadShort();
            var socialGroupsCount = reader.ReadUShort();
            SocialGroups = new List<AbstractSocialGroupInfos>();
            for (var socialGroupsIndex = 0; socialGroupsIndex < socialGroupsCount; socialGroupsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<AbstractSocialGroupInfos>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                SocialGroups.Add(objectToAdd);
            }
            PlayerState = reader.ReadByte();
        }
    }
}