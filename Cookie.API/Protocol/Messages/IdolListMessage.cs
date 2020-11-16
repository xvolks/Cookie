using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6585;

        public override ushort MessageID => ProtocolId;

        public List<short> ChosenIdols { get; set; }
        public List<short> PartyChosenIdols { get; set; }
        public List<PartyIdol> PartyIdols { get; set; }
        public IdolListMessage() { }

        public IdolListMessage( List<short> ChosenIdols, List<short> PartyChosenIdols, List<PartyIdol> PartyIdols ){
            this.ChosenIdols = ChosenIdols;
            this.PartyChosenIdols = PartyChosenIdols;
            this.PartyIdols = PartyIdols;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ChosenIdols.Count);
			foreach (var x in ChosenIdols)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)PartyChosenIdols.Count);
			foreach (var x in PartyChosenIdols)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)PartyIdols.Count);
			foreach (var x in PartyIdols)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ChosenIdolsCount = reader.ReadShort();
            ChosenIdols = new List<short>();
            for (var i = 0; i < ChosenIdolsCount; i++)
            {
                ChosenIdols.Add(reader.ReadVarShort());
            }
            var PartyChosenIdolsCount = reader.ReadShort();
            PartyChosenIdols = new List<short>();
            for (var i = 0; i < PartyChosenIdolsCount; i++)
            {
                PartyChosenIdols.Add(reader.ReadVarShort());
            }
            var PartyIdolsCount = reader.ReadShort();
            PartyIdols = new List<PartyIdol>();
            for (var i = 0; i < PartyIdolsCount; i++)
            {
                PartyIdol objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                PartyIdols.Add(objectToAdd);
            }
        }
    }
}
