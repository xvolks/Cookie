using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage
    {
        public new const uint ProtocolId = 6757;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> MissingIds;

        public PresetUseResultWithMissingIdsMessage(): base()
        {
        }

        public PresetUseResultWithMissingIdsMessage(
            short presetId,
            byte code,
            List<short> missingIds
        ): base(
            presetId,
            code
        )
        {
            MissingIds = missingIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)MissingIds.Count());
            foreach (var current in MissingIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countMissingIds = reader.ReadShort();
            MissingIds = new List<short>();
            for (short i = 0; i < countMissingIds; i++)
            {
                MissingIds.Add(reader.ReadVarShort());
            }
        }
    }
}