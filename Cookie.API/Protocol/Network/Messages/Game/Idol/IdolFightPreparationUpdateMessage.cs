using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    public class IdolFightPreparationUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6586;

        public IdolFightPreparationUpdateMessage(byte idolSource, List<Types.Game.Idol.Idol> idols)
        {
            IdolSource = idolSource;
            Idols = idols;
        }

        public IdolFightPreparationUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte IdolSource { get; set; }
        public List<Types.Game.Idol.Idol> Idols { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(IdolSource);
            writer.WriteShort((short) Idols.Count);
            for (var idolsIndex = 0; idolsIndex < Idols.Count; idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolSource = reader.ReadByte();
            var idolsCount = reader.ReadUShort();
            Idols = new List<Types.Game.Idol.Idol>();
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Types.Game.Idol.Idol>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }
    }
}