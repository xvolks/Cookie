using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class SelectedServerDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 42;

        public SelectedServerDataMessage(ushort serverId, string address, ushort port, bool canCreateNewCharacter,
            List<sbyte> ticket)
        {
            ServerId = serverId;
            Address = address;
            Port = port;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
        }

        public SelectedServerDataMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ServerId { get; set; }
        public string Address { get; set; }
        public ushort Port { get; set; }
        public bool CanCreateNewCharacter { get; set; }
        public List<sbyte> Ticket { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteUTF(Address);
            writer.WriteUShort(Port);
            writer.WriteBoolean(CanCreateNewCharacter);
            writer.WriteVarInt(Ticket.Count);
            for (var ticketIndex = 0; ticketIndex < Ticket.Count; ticketIndex++)
                writer.WriteSByte(Ticket[ticketIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
            Address = reader.ReadUTF();
            Port = reader.ReadUShort();
            CanCreateNewCharacter = reader.ReadBoolean();
            var ticketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
                Ticket.Add(reader.ReadSByte());
        }
    }
}