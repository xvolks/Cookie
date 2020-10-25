using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const uint ProtocolId = 153;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterBaseInformations Infos;
        public bool IsCollectingStats = false;

        public CharacterSelectedSuccessMessage()
        {
        }

        public CharacterSelectedSuccessMessage(
            CharacterBaseInformations infos,
            bool isCollectingStats
        )
        {
            Infos = infos;
            IsCollectingStats = isCollectingStats;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Infos.Serialize(writer);
            writer.WriteBoolean(IsCollectingStats);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Infos = new CharacterBaseInformations();
            Infos.Deserialize(reader);
            IsCollectingStats = reader.ReadBoolean();
        }
    }
}