using System.Collections.Generic;
using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class SelectedServerDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 42;
        public string Address;
        public bool CanCreateNewCharacter;
        public ushort Port;

        public ushort ServerId;
        public List<int> Ticket;

        public SelectedServerDataMessage()
        {
        }

        public SelectedServerDataMessage(ushort serverId, string address, ushort port, bool canCreateNewCharacter,
            List<int> ticket)
        {
            ServerId = serverId;
            Address = address;
            Port = port;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteUTF(Address);
            writer.WriteUShort(Port);
            writer.WriteBoolean(CanCreateNewCharacter);
            for (var i = 0; i < Ticket.Count; i++)
                writer.WriteByte((byte) Ticket[i]);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ServerId = reader.ReadVarUhShort();
            Address = reader.ReadUTF();
            Port = reader.ReadUShort();
            CanCreateNewCharacter = reader.ReadBoolean();
            var size = reader.ReadVarInt();
            Ticket = new List<int>();
            for (var i = 0; i < size; i++)
                Ticket.Add(reader.ReadByte());
        }
    }
}