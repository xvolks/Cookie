using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class IgnoredOnlineInformations : IgnoredInformations
    {
        public new const ushort ProtocolId = 105;

        public override ushort TypeID => ProtocolId;

        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public IgnoredOnlineInformations() { }

        public IgnoredOnlineInformations( ulong PlayerId, string PlayerName, sbyte Breed, bool Sex ){
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
            this.Breed = Breed;
            this.Sex = Sex;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }
    }
}
