using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SelectedServerDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 42;

        public override ushort MessageID => ProtocolId;

        public ushort ServerId { get; set; }
        public string Address { get; set; }
        public List<int> Ports { get; set; }
        public bool CanCreateNewCharacter { get; set; }
        public List<sbyte> Ticket { get; set; }
        public SelectedServerDataMessage() { }

        public SelectedServerDataMessage( ushort ServerId, string Address, List<int> Ports, bool CanCreateNewCharacter, List<sbyte> Ticket ){
            this.ServerId = ServerId;
            this.Address = Address;
            this.Ports = Ports;
            this.CanCreateNewCharacter = CanCreateNewCharacter;
            this.Ticket = Ticket;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteUTF(Address);
			writer.WriteShort((short)Ports.Count);
			foreach (var x in Ports)
			{
				writer.WriteInt(x);
			}
            writer.WriteBoolean(CanCreateNewCharacter);
			writer.WriteVarInt((int)Ticket.Count);
			foreach (var x in Ticket)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
            Address = reader.ReadUTF();
            var PortsCount = reader.ReadShort();
            Ports = new List<int>();
            for (var i = 0; i < PortsCount; i++)
            {
                Ports.Add(reader.ReadInt());
            }
            CanCreateNewCharacter = reader.ReadBoolean();
            var TicketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var i = 0; i < TicketCount; i++)
            {
                Ticket.Add(reader.ReadSByte());
            }
        }
    }
}
