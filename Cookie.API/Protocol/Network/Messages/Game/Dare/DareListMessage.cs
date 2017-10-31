namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using System.Collections.Generic;
    using Utils.IO;

    public class DareListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6661;
        public override ushort MessageID => ProtocolId;
        public List<DareInformations> Dares { get; set; }

        public DareListMessage(List<DareInformations> dares)
        {
            Dares = dares;
        }

        public DareListMessage() { }

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
            Dares = new List<DareInformations>();
            for (var daresIndex = 0; daresIndex < daresCount; daresIndex++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                Dares.Add(objectToAdd);
            }
        }

    }
}
