namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Social;
    using System.Collections.Generic;
    using Utils.IO;

    public class AlliancePartialListMessage : AllianceListMessage
    {
        public new const ushort ProtocolId = 6427;
        public override ushort MessageID => ProtocolId;

        public AlliancePartialListMessage() { }

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
