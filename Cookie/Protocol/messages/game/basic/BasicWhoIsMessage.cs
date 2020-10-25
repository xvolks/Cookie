using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicWhoIsMessage : NetworkMessage
    {
        public const uint ProtocolId = 180;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Self = false;
        public bool Verbose = false;
        public byte Position = unchecked((byte)-1);
        public string AccountNickname;
        public int AccountId = 0;
        public string PlayerName;
        public long PlayerId = 0;
        public short AreaId = 0;
        public short ServerId = 0;
        public short OriginServerId = 0;
        public List<AbstractSocialGroupInfos> SocialGroups;
        public byte PlayerState = 99;

        public BasicWhoIsMessage()
        {
        }

        public BasicWhoIsMessage(
            bool self,
            bool verbose,
            byte position,
            string accountNickname,
            int accountId,
            string playerName,
            long playerId,
            short areaId,
            short serverId,
            short originServerId,
            List<AbstractSocialGroupInfos> socialGroups,
            byte playerState
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Self);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Verbose);
            writer.WriteByte(box0);
            writer.WriteByte(Position);
            writer.WriteUTF(AccountNickname);
            writer.WriteInt(AccountId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarLong(PlayerId);
            writer.WriteShort(AreaId);
            writer.WriteShort(ServerId);
            writer.WriteShort(OriginServerId);
            writer.WriteShort((short)SocialGroups.Count());
            foreach (var current in SocialGroups)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteByte(PlayerState);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Self = BooleanByteWrapper.GetFlag(box0, 1);
            Verbose = BooleanByteWrapper.GetFlag(box0, 2);
            Position = reader.ReadByte();
            AccountNickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarLong();
            AreaId = reader.ReadShort();
            ServerId = reader.ReadShort();
            OriginServerId = reader.ReadShort();
            var countSocialGroups = reader.ReadShort();
            SocialGroups = new List<AbstractSocialGroupInfos>();
            for (short i = 0; i < countSocialGroups; i++)
            {
                var socialGroupstypeId = reader.ReadShort();
                AbstractSocialGroupInfos type = new AbstractSocialGroupInfos();
                type.Deserialize(reader);
                SocialGroups.Add(type);
            }
            PlayerState = reader.ReadByte();
        }
    }
}