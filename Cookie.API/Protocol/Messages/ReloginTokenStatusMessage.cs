using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ReloginTokenStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6539;

        public override ushort MessageID => ProtocolId;

        public bool ValidToken { get; set; }
        public List<sbyte> Ticket { get; set; }
        public ReloginTokenStatusMessage() { }

        public ReloginTokenStatusMessage( bool ValidToken, List<sbyte> Ticket ){
            this.ValidToken = ValidToken;
            this.Ticket = Ticket;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ValidToken);
			writer.WriteVarInt((int)Ticket.Count);
			foreach (var x in Ticket)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ValidToken = reader.ReadBoolean();
            var TicketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var i = 0; i < TicketCount; i++)
            {
                Ticket.Add(reader.ReadSByte());
            }
        }
    }
}
