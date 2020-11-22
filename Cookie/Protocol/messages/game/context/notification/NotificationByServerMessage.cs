using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class NotificationByServerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6103;
        public override uint MessageID { get { return ProtocolId; } }

        public short Id_ = 0;
        public List<string> Parameters;
        public bool ForceOpen = false;

        public NotificationByServerMessage()
        {
        }

        public NotificationByServerMessage(
            short id_,
            List<string> parameters,
            bool forceOpen
        )
        {
            Id_ = id_;
            Parameters = parameters;
            ForceOpen = forceOpen;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
            writer.WriteShort((short)Parameters.Count());
            foreach (var current in Parameters)
            {
                writer.WriteUTF(current);
            }
            writer.WriteBoolean(ForceOpen);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
            var countParameters = reader.ReadShort();
            Parameters = new List<string>();
            for (short i = 0; i < countParameters; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
            ForceOpen = reader.ReadBoolean();
        }
    }
}