using Cookie.IO;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Messages.Connection
{
    public class SelectedServerDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 42;
        public override uint MessageID { get { return ProtocolId; } }

        public ushort ServerId;
        public string Address;
        public ushort Port;
        public bool CanCreateNewCharacter = false;
        public List<int> Ticket;

        public SelectedServerDataMessage() { }

        public SelectedServerDataMessage(ushort serverId, string address, ushort port, bool canCreateNewCharacter, List<int> ticket)
        {
            ServerId = serverId;
            Address = address;
            Port = port;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteUTF(Address);
            writer.WriteUShort(Port);
            writer.WriteBoolean(CanCreateNewCharacter);
            for (int i = 0; i < Ticket.Count; i++)
            {
                writer.WriteByte((byte)Ticket[i]);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ServerId = reader.ReadVarUhShort();
            Address = reader.ReadUTF();
            Port = reader.ReadUShort();
            CanCreateNewCharacter = reader.ReadBoolean();
            int size = reader.ReadVarInt();
            Ticket = new List<int>();
            for (int i = 0; i < size; i++)
            {
                Ticket.Add(reader.ReadByte());
            }
        }
    }
}
