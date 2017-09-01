namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Character;
    using Types.Game.Context.Roleplay;
    using Types.Game.Social;
    using System.Collections.Generic;
    using Utils.IO;

    public class GuildInAllianceFactsMessage : GuildFactsMessage
    {
        public new const ushort ProtocolId = 6422;
        public override ushort MessageID => ProtocolId;
        public BasicNamedAllianceInformations AllianceInfos { get; set; }

        public GuildInAllianceFactsMessage(BasicNamedAllianceInformations allianceInfos)
        {
            AllianceInfos = allianceInfos;
        }

        public GuildInAllianceFactsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicNamedAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }

    }
}
