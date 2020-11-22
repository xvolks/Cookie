using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolFightPreparationUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6586;

        public override ushort MessageID => ProtocolId;

        public sbyte IdolSource { get; set; }
        public List<Idol> Idols { get; set; }
        public IdolFightPreparationUpdateMessage() { }

        public IdolFightPreparationUpdateMessage( sbyte IdolSource, List<Idol> Idols ){
            this.IdolSource = IdolSource;
            this.Idols = Idols;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(IdolSource);
			writer.WriteShort((short)Idols.Count);
			foreach (var x in Idols)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolSource = reader.ReadSByte();
            var IdolsCount = reader.ReadShort();
            Idols = new List<Idol>();
            for (var i = 0; i < IdolsCount; i++)
            {
                Idol objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }
    }
}
