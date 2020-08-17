using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaSwitchToGameServerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6574;

        public GameRolePlayArenaSwitchToGameServerMessage(bool validToken, List<sbyte> ticket, short homeServerId)
        {
            ValidToken = validToken;
            Ticket = ticket;
            HomeServerId = homeServerId;
        }

        public GameRolePlayArenaSwitchToGameServerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool ValidToken { get; set; }
        public List<sbyte> Ticket { get; set; }
        public short HomeServerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ValidToken);
            writer.WriteVarInt(Ticket.Count);
            for (var ticketIndex = 0; ticketIndex < Ticket.Count; ticketIndex++)
                writer.WriteSByte(Ticket[ticketIndex]);
            writer.WriteShort(HomeServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ValidToken = reader.ReadBoolean();
            var ticketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
                Ticket.Add(reader.ReadSByte());
            HomeServerId = reader.ReadShort();
        }
    }
}