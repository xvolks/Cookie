using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NotificationByServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6103;

        public override ushort MessageID => ProtocolId;

        public ushort Id { get; set; }
        public List<string> Parameters { get; set; }
        public bool ForceOpen { get; set; }
        public NotificationByServerMessage() { }

        public NotificationByServerMessage( ushort Id, List<string> Parameters, bool ForceOpen ){
            this.Id = Id;
            this.Parameters = Parameters;
            this.ForceOpen = ForceOpen;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
			writer.WriteShort((short)Parameters.Count);
			foreach (var x in Parameters)
			{
				writer.WriteUTF(x);
			}
            writer.WriteBoolean(ForceOpen);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
            var ParametersCount = reader.ReadShort();
            Parameters = new List<string>();
            for (var i = 0; i < ParametersCount; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
            ForceOpen = reader.ReadBoolean();
        }
    }
}
