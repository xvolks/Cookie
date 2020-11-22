using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorAttackedResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5635;
        public override uint MessageID { get { return ProtocolId; } }

        public bool DeadOrAlive = false;
        public TaxCollectorBasicInformations BasicInfos;
        public BasicGuildInformations Guild;

        public TaxCollectorAttackedResultMessage()
        {
        }

        public TaxCollectorAttackedResultMessage(
            bool deadOrAlive,
            TaxCollectorBasicInformations basicInfos,
            BasicGuildInformations guild
        )
        {
            DeadOrAlive = deadOrAlive;
            BasicInfos = basicInfos;
            Guild = guild;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(DeadOrAlive);
            BasicInfos.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DeadOrAlive = reader.ReadBoolean();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}