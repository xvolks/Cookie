using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Notification
{
    public class NotificationByServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6103;

        public NotificationByServerMessage(ushort objectId, List<string> parameters, bool forceOpen)
        {
            ObjectId = objectId;
            Parameters = parameters;
            ForceOpen = forceOpen;
        }

        public NotificationByServerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ObjectId { get; set; }
        public List<string> Parameters { get; set; }
        public bool ForceOpen { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
            writer.WriteShort((short) Parameters.Count);
            for (var parametersIndex = 0; parametersIndex < Parameters.Count; parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
            writer.WriteBoolean(ForceOpen);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new List<string>();
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters.Add(reader.ReadUTF());
            ForceOpen = reader.ReadBoolean();
        }
    }
}