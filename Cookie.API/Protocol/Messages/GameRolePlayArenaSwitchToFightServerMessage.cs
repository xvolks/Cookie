using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaSwitchToFightServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6575;

        public override ushort MessageID => ProtocolId;

        public string Address { get; set; }
        public List<short> Ports { get; set; }
        public List<sbyte> Ticket { get; set; }
        public GameRolePlayArenaSwitchToFightServerMessage() { }

        public GameRolePlayArenaSwitchToFightServerMessage( string Address, List<short> Ports, List<sbyte> Ticket ){
            this.Address = Address;
            this.Ports = Ports;
            this.Ticket = Ticket;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Address);
			writer.WriteShort((short)Ports.Count);
			foreach (var x in Ports)
			{
				writer.WriteShort(x);
			}
			writer.WriteVarInt((int)Ticket.Count);
			foreach (var x in Ticket)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Address = reader.ReadUTF();
            var PortsCount = reader.ReadShort();
            Ports = new List<short>();
            for (var i = 0; i < PortsCount; i++)
            {
                Ports.Add(reader.ReadShort());
            }
            var TicketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var i = 0; i < TicketCount; i++)
            {
                Ticket.Add(reader.ReadSByte());
            }
        }
    }
}
