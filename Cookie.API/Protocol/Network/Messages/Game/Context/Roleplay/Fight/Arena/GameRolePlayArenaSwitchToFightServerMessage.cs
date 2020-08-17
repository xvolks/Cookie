using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaSwitchToFightServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6575;

        public GameRolePlayArenaSwitchToFightServerMessage(string address, List<ushort> ports, List<sbyte> ticket)
        {
            Address = address;
            Ports = ports;
            Ticket = ticket;
        }

        public GameRolePlayArenaSwitchToFightServerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Address { get; set; }
        public List<ushort> Ports { get; set; }
        public List<sbyte> Ticket { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Address);
            writer.WriteShort((short) Ports.Count);
            for (var portsIndex = 0; portsIndex < Ports.Count; portsIndex++)
                writer.WriteUShort(Ports[portsIndex]);
            writer.WriteVarInt(Ticket.Count);
            for (var ticketIndex = 0; ticketIndex < Ticket.Count; ticketIndex++)
                writer.WriteSByte(Ticket[ticketIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Address = reader.ReadUTF();
            var portsCount = reader.ReadUShort();
            Ports = new List<ushort>();
            for (var portsIndex = 0; portsIndex < portsCount; portsIndex++)
                Ports.Add(reader.ReadUShort());
            var ticketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
                Ticket.Add(reader.ReadSByte());
        }
    }
}