namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Types.Game.Prism;
    using System.Collections.Generic;
    using Utils.IO;

    public class PrismsListUpdateMessage : PrismsListMessage
    {
        public new const ushort ProtocolId = 6438;
        public override ushort MessageID => ProtocolId;

        public PrismsListUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
