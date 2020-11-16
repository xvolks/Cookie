using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaSwitchToFightServerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6575;
        public override uint MessageID { get { return ProtocolId; } }

        public string Address;
        public List<short> Ports;
        public List<byte> Ticket;

        public GameRolePlayArenaSwitchToFightServerMessage()
        {
        }

        public GameRolePlayArenaSwitchToFightServerMessage(
            string address,
            List<short> ports,
            List<byte> ticket
        )
        {
            Address = address;
            Ports = ports;
            Ticket = ticket;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Address);
            writer.WriteShort((short)Ports.Count());
            foreach (var current in Ports)
            {
                writer.WriteShort(current);
            }
            writer.WriteVarInt((int)Ticket.Count());
            foreach (var current in Ticket)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Address = reader.ReadUTF();
            var countPorts = reader.ReadShort();
            Ports = new List<short>();
            for (short i = 0; i < countPorts; i++)
            {
                Ports.Add(reader.ReadShort());
            }
            var countTicket = reader.ReadVarInt();
            Ticket = new List<byte>();
            for (int i = 0; i < countTicket; i++)
            {
                Ticket.Add(reader.ReadByte());
            }
        }
    }
}