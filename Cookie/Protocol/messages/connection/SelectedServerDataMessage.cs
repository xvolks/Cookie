using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class SelectedServerDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 42;
        public override uint MessageID { get { return ProtocolId; } }

        public short ServerId = 0;
        public string Address;
        public List<int> Ports;
        public bool CanCreateNewCharacter = false;
        public List<byte> Ticket;

        public SelectedServerDataMessage()
        {
        }

        public SelectedServerDataMessage(
            short serverId,
            string address,
            List<int> ports,
            bool canCreateNewCharacter,
            List<byte> ticket
        )
        {
            ServerId = serverId;
            Address = address;
            Ports = ports;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ServerId);
            writer.WriteUTF(Address);
            writer.WriteShort((short)Ports.Count());
            foreach (var current in Ports)
            {
                writer.WriteInt(current);
            }
            writer.WriteBoolean(CanCreateNewCharacter);
            writer.WriteVarInt((int)Ticket.Count());
            foreach (var current in Ticket)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ServerId = reader.ReadVarShort();
            Address = reader.ReadUTF();
            var countPorts = reader.ReadShort();
            Ports = new List<int>();
            for (short i = 0; i < countPorts; i++)
            {
                Ports.Add(reader.ReadInt());
            }
            CanCreateNewCharacter = reader.ReadBoolean();
            var countTicket = reader.ReadVarInt();
            Ticket = new List<byte>();
            for (int i = 0; i < countTicket; i++)
            {
                Ticket.Add(reader.ReadByte());
            }
        }
    }
}