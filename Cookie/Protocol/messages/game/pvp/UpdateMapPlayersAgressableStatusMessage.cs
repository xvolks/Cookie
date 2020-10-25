using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6454;
        public override uint MessageID { get { return ProtocolId; } }

        public List<long> PlayerIds;
        public List<byte> Enable;

        public UpdateMapPlayersAgressableStatusMessage()
        {
        }

        public UpdateMapPlayersAgressableStatusMessage(
            List<long> playerIds,
            List<byte> enable
        )
        {
            PlayerIds = playerIds;
            Enable = enable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)PlayerIds.Count());
            foreach (var current in PlayerIds)
            {
                writer.WriteVarLong(current);
            }
            writer.WriteShort((short)Enable.Count());
            foreach (var current in Enable)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countPlayerIds = reader.ReadShort();
            PlayerIds = new List<long>();
            for (short i = 0; i < countPlayerIds; i++)
            {
                PlayerIds.Add(reader.ReadVarLong());
            }
            var countEnable = reader.ReadShort();
            Enable = new List<byte>();
            for (short i = 0; i < countEnable; i++)
            {
                Enable.Add(reader.ReadByte());
            }
        }
    }
}