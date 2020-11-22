using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5633;

        public override ushort MessageID => ProtocolId;

        public sbyte MovementType { get; set; }
        public TaxCollectorBasicInformations BasicInfos { get; set; }
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public TaxCollectorMovementMessage() { }

        public TaxCollectorMovementMessage( sbyte MovementType, TaxCollectorBasicInformations BasicInfos, ulong PlayerId, string PlayerName ){
            this.MovementType = MovementType;
            this.BasicInfos = BasicInfos;
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(MovementType);
            BasicInfos.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            MovementType = reader.ReadSByte();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
        }
    }
}
