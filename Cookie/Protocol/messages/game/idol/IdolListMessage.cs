using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6585;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> ChosenIdols;
        public List<short> PartyChosenIdols;
        public List<PartyIdol> PartyIdols;

        public IdolListMessage()
        {
        }

        public IdolListMessage(
            List<short> chosenIdols,
            List<short> partyChosenIdols,
            List<PartyIdol> partyIdols
        )
        {
            ChosenIdols = chosenIdols;
            PartyChosenIdols = partyChosenIdols;
            PartyIdols = partyIdols;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ChosenIdols.Count());
            foreach (var current in ChosenIdols)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)PartyChosenIdols.Count());
            foreach (var current in PartyChosenIdols)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)PartyIdols.Count());
            foreach (var current in PartyIdols)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countChosenIdols = reader.ReadShort();
            ChosenIdols = new List<short>();
            for (short i = 0; i < countChosenIdols; i++)
            {
                ChosenIdols.Add(reader.ReadVarShort());
            }
            var countPartyChosenIdols = reader.ReadShort();
            PartyChosenIdols = new List<short>();
            for (short i = 0; i < countPartyChosenIdols; i++)
            {
                PartyChosenIdols.Add(reader.ReadVarShort());
            }
            var countPartyIdols = reader.ReadShort();
            PartyIdols = new List<PartyIdol>();
            for (short i = 0; i < countPartyIdols; i++)
            {
                var partyIdolstypeId = reader.ReadShort();
                PartyIdol type = new PartyIdol();
                type.Deserialize(reader);
                PartyIdols.Add(type);
            }
        }
    }
}