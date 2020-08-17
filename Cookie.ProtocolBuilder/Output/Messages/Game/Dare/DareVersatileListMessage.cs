namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using System.Collections.Generic;
    using Utils.IO;

    public class DareVersatileListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6657;
        public override ushort MessageID => ProtocolId;
        public List<DareVersatileInformations> Dares { get; set; }

        public DareVersatileListMessage(List<DareVersatileInformations> dares)
        {
            Dares = dares;
        }

        public DareVersatileListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Dares.Count);
            for (var daresIndex = 0; daresIndex < Dares.Count; daresIndex++)
            {
                var objectToSend = Dares[daresIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var daresCount = reader.ReadUShort();
            Dares = new List<DareVersatileInformations>();
            for (var daresIndex = 0; daresIndex < daresCount; daresIndex++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                Dares.Add(objectToAdd);
            }
        }

    }
}
