using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PlayerStatus : NetworkType
    {
        public const short ProtocolId = 415;
        public override short TypeId { get { return ProtocolId; } }

        public byte StatusId = 1;

        public PlayerStatus()
        {
        }

        public PlayerStatus(
            byte statusId
        )
        {
            StatusId = statusId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(StatusId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            StatusId = reader.ReadByte();
        }
    }
}