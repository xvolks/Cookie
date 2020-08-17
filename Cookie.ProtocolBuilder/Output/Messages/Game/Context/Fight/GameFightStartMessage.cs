namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Types.Game.Idol;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 712;
        public override ushort MessageID => ProtocolId;
        public List<Idol> Idols { get; set; }

        public GameFightStartMessage(List<Idol> idols)
        {
            Idols = idols;
        }

        public GameFightStartMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Idols.Count);
            for (var idolsIndex = 0; idolsIndex < Idols.Count; idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var idolsCount = reader.ReadUShort();
            Idols = new List<Idol>();
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = new Idol();
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }

    }
}
