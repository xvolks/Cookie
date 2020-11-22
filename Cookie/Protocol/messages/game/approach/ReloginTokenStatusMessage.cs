using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ReloginTokenStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6539;
        public override uint MessageID { get { return ProtocolId; } }

        public bool ValidToken = false;
        public List<byte> Ticket;

        public ReloginTokenStatusMessage()
        {
        }

        public ReloginTokenStatusMessage(
            bool validToken,
            List<byte> ticket
        )
        {
            ValidToken = validToken;
            Ticket = ticket;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(ValidToken);
            writer.WriteVarInt((int)Ticket.Count());
            foreach (var current in Ticket)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ValidToken = reader.ReadBoolean();
            var countTicket = reader.ReadVarInt();
            Ticket = new List<byte>();
            for (int i = 0; i < countTicket; i++)
            {
                Ticket.Add(reader.ReadByte());
            }
        }
    }
}