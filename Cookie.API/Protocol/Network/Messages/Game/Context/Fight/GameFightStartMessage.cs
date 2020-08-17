using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 712;

        public GameFightStartMessage(List<Types.Game.Idol.Idol> idols)
        {
            Idols = idols;
        }

        public GameFightStartMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<Types.Game.Idol.Idol> Idols { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Idols.Count);
            for (var idolsIndex = 0; idolsIndex < Idols.Count; idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var idolsCount = reader.ReadUShort();
            Idols = new List<Types.Game.Idol.Idol>();
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = new Types.Game.Idol.Idol();
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }
    }
}