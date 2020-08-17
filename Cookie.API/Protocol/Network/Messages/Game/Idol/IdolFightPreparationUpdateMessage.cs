namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    using Types.Game.Idol;
    using System.Collections.Generic;
    using Utils.IO;

    public class IdolFightPreparationUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6586;
        public override ushort MessageID => ProtocolId;
        public byte IdolSource { get; set; }
        public List<Idol> Idols { get; set; }

        public IdolFightPreparationUpdateMessage(byte idolSource, List<Idol> idols)
        {
            IdolSource = idolSource;
            Idols = idols;
        }

        public IdolFightPreparationUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(IdolSource);
            writer.WriteShort((short)Idols.Count);
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
            Idols = new List<Idol>();
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Idol>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }

    }
}
