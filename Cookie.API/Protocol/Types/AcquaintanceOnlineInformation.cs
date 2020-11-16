using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AcquaintanceOnlineInformation : AcquaintanceInformation
    {
        public new const ushort ProtocolId = 562;

        public override ushort TypeID => ProtocolId;

        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public ushort MoodSmileyId { get; set; }
        public PlayerStatus Status { get; set; }
        public AcquaintanceOnlineInformation() { }

        public AcquaintanceOnlineInformation( ulong PlayerId, string PlayerName, ushort MoodSmileyId, PlayerStatus Status ){
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
            this.MoodSmileyId = MoodSmileyId;
            this.Status = Status;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarUhShort(MoodSmileyId);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            MoodSmileyId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}
