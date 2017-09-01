using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Types.Game.Guild.Tax;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TaxCollectorAttackedResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5635;

        public TaxCollectorAttackedResultMessage(bool deadOrAlive, TaxCollectorBasicInformations basicInfos,
            BasicGuildInformations guild)
        {
            DeadOrAlive = deadOrAlive;
            BasicInfos = basicInfos;
            Guild = guild;
        }

        public TaxCollectorAttackedResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool DeadOrAlive { get; set; }
        public TaxCollectorBasicInformations BasicInfos { get; set; }
        public BasicGuildInformations Guild { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(DeadOrAlive);
            BasicInfos.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            DeadOrAlive = reader.ReadBoolean();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}