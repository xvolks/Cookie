using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ShowCellSpectatorMessage : ShowCellMessage
    {
        public new const uint ProtocolId = 6158;
        public override uint MessageID { get { return ProtocolId; } }

        public string PlayerName;

        public ShowCellSpectatorMessage(): base()
        {
        }

        public ShowCellSpectatorMessage(
            double sourceId,
            short cellId,
            string playerName
        ): base(
            sourceId,
            cellId
        )
        {
            PlayerName = playerName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerName = reader.ReadUTF();
        }
    }
}