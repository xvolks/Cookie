using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class RecycleResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6601;
        public override uint MessageID { get { return ProtocolId; } }

        public int NuggetsForPrism = 0;
        public int NuggetsForPlayer = 0;

        public RecycleResultMessage()
        {
        }

        public RecycleResultMessage(
            int nuggetsForPrism,
            int nuggetsForPlayer
        )
        {
            NuggetsForPrism = nuggetsForPrism;
            NuggetsForPlayer = nuggetsForPlayer;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(NuggetsForPrism);
            writer.WriteVarInt(NuggetsForPlayer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NuggetsForPrism = reader.ReadVarInt();
            NuggetsForPlayer = reader.ReadVarInt();
        }
    }
}