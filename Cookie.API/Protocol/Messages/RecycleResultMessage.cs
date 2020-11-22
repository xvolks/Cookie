using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class RecycleResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6601;

        public override ushort MessageID => ProtocolId;

        public uint NuggetsForPrism { get; set; }
        public uint NuggetsForPlayer { get; set; }
        public RecycleResultMessage() { }

        public RecycleResultMessage( uint NuggetsForPrism, uint NuggetsForPlayer ){
            this.NuggetsForPrism = NuggetsForPrism;
            this.NuggetsForPlayer = NuggetsForPlayer;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(NuggetsForPrism);
            writer.WriteVarUhInt(NuggetsForPlayer);
        }

        public override void Deserialize(IDataReader reader)
        {
            NuggetsForPrism = reader.ReadVarUhInt();
            NuggetsForPlayer = reader.ReadVarUhInt();
        }
    }
}
