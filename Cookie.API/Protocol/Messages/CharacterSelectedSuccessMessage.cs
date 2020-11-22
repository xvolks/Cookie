using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 153;

        public override ushort MessageID => ProtocolId;

        public CharacterBaseInformations Infos { get; set; }
        public bool IsCollectingStats { get; set; }
        public CharacterSelectedSuccessMessage() { }

        public CharacterSelectedSuccessMessage( CharacterBaseInformations Infos, bool IsCollectingStats ){
            this.Infos = Infos;
            this.IsCollectingStats = IsCollectingStats;
        }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
            writer.WriteBoolean(IsCollectingStats);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = new CharacterBaseInformations();
            Infos.Deserialize(reader);
            IsCollectingStats = reader.ReadBoolean();
        }
    }
}
