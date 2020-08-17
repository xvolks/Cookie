using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class EntityTalkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6110;

        public EntityTalkMessage(double entityId, ushort textId, List<string> parameters)
        {
            EntityId = entityId;
            TextId = textId;
            Parameters = parameters;
        }

        public EntityTalkMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double EntityId { get; set; }
        public ushort TextId { get; set; }
        public List<string> Parameters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarUhShort(TextId);
            writer.WriteShort((short) Parameters.Count);
            for (var parametersIndex = 0; parametersIndex < Parameters.Count; parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadDouble();
            TextId = reader.ReadVarUhShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new List<string>();
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters.Add(reader.ReadUTF());
        }
    }
}