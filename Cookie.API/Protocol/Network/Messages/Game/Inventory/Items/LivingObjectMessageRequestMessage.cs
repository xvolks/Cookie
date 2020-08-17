using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class LivingObjectMessageRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6066;

        public LivingObjectMessageRequestMessage(ushort msgId, List<string> parameters, uint livingObject)
        {
            MsgId = msgId;
            Parameters = parameters;
            LivingObject = livingObject;
        }

        public LivingObjectMessageRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort MsgId { get; set; }
        public List<string> Parameters { get; set; }
        public uint LivingObject { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(MsgId);
            writer.WriteShort((short) Parameters.Count);
            for (var parametersIndex = 0; parametersIndex < Parameters.Count; parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
            writer.WriteVarUhInt(LivingObject);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgId = reader.ReadVarUhShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new List<string>();
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters.Add(reader.ReadUTF());
            LivingObject = reader.ReadVarUhInt();
        }
    }
}