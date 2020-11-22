using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicWhoIsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 180;

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
        public sbyte PlayerState { get; set; }
        public BasicWhoIsMessage() { }

        public BasicWhoIsMessage( bool Self, bool Verbose, sbyte Position, string AccountNickname, int AccountId, string PlayerName, ulong PlayerId, short AreaId, short ServerId, short OriginServerId, List<AbstractSocialGroupInfos> SocialGroups, sbyte PlayerState ){
            this.Self = Self;
            this.Verbose = Verbose;
            this.Position = Position;
            this.AccountNickname = AccountNickname;
            this.AccountId = AccountId;
            this.PlayerName = PlayerName;
            this.PlayerId = PlayerId;
            this.AreaId = AreaId;
            this.ServerId = ServerId;
            this.OriginServerId = OriginServerId;
            this.SocialGroups = SocialGroups;
            this.PlayerState = PlayerState;
        }

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
			writer.WriteShort((short)SocialGroups.Count);
			foreach (var x in SocialGroups)
			{
				x.Serialize(writer);
			}
            writer.WriteSByte(PlayerState);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Self = BooleanByteWrapper.GetFlag(flag, 0);;
			Verbose = BooleanByteWrapper.GetFlag(flag, 1);;
            Position = reader.ReadSByte();
            AccountNickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarUhLong();
            AreaId = reader.ReadShort();
            ServerId = reader.ReadShort();
            OriginServerId = reader.ReadShort();
            var SocialGroupsCount = reader.ReadShort();
            SocialGroups = new List<AbstractSocialGroupInfos>();
            for (var i = 0; i < SocialGroupsCount; i++)
            {
                AbstractSocialGroupInfos objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                SocialGroups.Add(objectToAdd);
            }
            PlayerState = reader.ReadSByte();
        }
    }
}
