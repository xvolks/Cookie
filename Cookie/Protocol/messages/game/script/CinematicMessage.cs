using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CinematicMessage : NetworkMessage
    {
        public const uint ProtocolId = 6053;
        public override uint MessageID { get { return ProtocolId; } }

        public short CinematicId = 0;

        public CinematicMessage()
        {
        }

        public CinematicMessage(
            short cinematicId
        )
        {
            CinematicId = cinematicId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CinematicId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CinematicId = reader.ReadVarShort();
        }
    }
}