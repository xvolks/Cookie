using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
    {
        public new const ushort ProtocolId = 6013;

        public override ushort MessageID => ProtocolId;

        public ulong MemberId { get; set; }
        public string MemberName { get; set; }
        public int WorldId { get; set; }
        public CompassUpdatePvpSeekMessage() { }

        public CompassUpdatePvpSeekMessage( ulong MemberId, string MemberName, int WorldId ){
            this.MemberId = MemberId;
            this.MemberName = MemberName;
            this.WorldId = WorldId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(MemberId);
            writer.WriteUTF(MemberName);
            writer.WriteInt(WorldId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarUhLong();
            MemberName = reader.ReadUTF();
            WorldId = reader.ReadInt();
        }
    }
}
