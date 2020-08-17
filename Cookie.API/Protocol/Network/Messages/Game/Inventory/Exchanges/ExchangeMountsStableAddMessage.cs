using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Mount;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeMountsStableAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6555;

        public ExchangeMountsStableAddMessage(List<MountClientData> mountDescription)
        {
            MountDescription = mountDescription;
        }

        public ExchangeMountsStableAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<MountClientData> MountDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MountDescription.Count);
            for (var mountDescriptionIndex = 0; mountDescriptionIndex < MountDescription.Count; mountDescriptionIndex++)
            {
                var objectToSend = MountDescription[mountDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var mountDescriptionCount = reader.ReadUShort();
            MountDescription = new List<MountClientData>();
            for (var mountDescriptionIndex = 0; mountDescriptionIndex < mountDescriptionCount; mountDescriptionIndex++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                MountDescription.Add(objectToAdd);
            }
        }
    }
}