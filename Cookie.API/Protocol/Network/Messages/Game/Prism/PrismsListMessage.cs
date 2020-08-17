using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Prism;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6440;

        public PrismsListMessage(List<PrismSubareaEmptyInfo> prisms)
        {
            Prisms = prisms;
        }

        public PrismsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<PrismSubareaEmptyInfo> Prisms { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Prisms.Count);
            for (var prismsIndex = 0; prismsIndex < Prisms.Count; prismsIndex++)
            {
                var objectToSend = Prisms[prismsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var prismsCount = reader.ReadUShort();
            Prisms = new List<PrismSubareaEmptyInfo>();
            for (var prismsIndex = 0; prismsIndex < prismsCount; prismsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Prisms.Add(objectToAdd);
            }
        }
    }
}