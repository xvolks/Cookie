using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaSwitchToGameServerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6574;
        public override uint MessageID { get { return ProtocolId; } }

        public bool ValidToken = false;
        public List<byte> Ticket;
        public short HomeServerId = 0;

        public GameRolePlayArenaSwitchToGameServerMessage()
        {
        }

        public GameRolePlayArenaSwitchToGameServerMessage(
            bool validToken,
            List<byte> ticket,
            short homeServerId
        )
        {
            ValidToken = validToken;
            Ticket = ticket;
            HomeServerId = homeServerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(ValidToken);
            writer.WriteVarInt((int)Ticket.Count());
            foreach (var current in Ticket)
            {
                writer.WriteByte(current);
            }
            writer.WriteShort(HomeServerId);
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
            HomeServerId = reader.ReadShort();
        }
    }
}