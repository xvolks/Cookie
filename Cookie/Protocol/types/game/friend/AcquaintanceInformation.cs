using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AcquaintanceInformation : AbstractContactInformations
    {
        public new const short ProtocolId = 561;
        public override short TypeId { get { return ProtocolId; } }

        public byte PlayerState = 99;

        public AcquaintanceInformation(): base()
        {
        }

        public AcquaintanceInformation(
            int accountId,
            string accountName,
            byte playerState
        ): base(
            accountId,
            accountName
        )
        {
            PlayerState = playerState;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PlayerState);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerState = reader.ReadByte();
        }
    }
}