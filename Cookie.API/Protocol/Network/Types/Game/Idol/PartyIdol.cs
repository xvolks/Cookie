using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Idol
{
    public class PartyIdol : Idol
    {
        public new const ushort ProtocolId = 490;

        public PartyIdol(List<ulong> ownersIds)
        {
            OwnersIds = ownersIds;
        }

        public PartyIdol()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<ulong> OwnersIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) OwnersIds.Count);
            for (var ownersIdsIndex = 0; ownersIdsIndex < OwnersIds.Count; ownersIdsIndex++)
                writer.WriteVarUhLong(OwnersIds[ownersIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ownersIdsCount = reader.ReadUShort();
            OwnersIds = new List<ulong>();
            for (var ownersIdsIndex = 0; ownersIdsIndex < ownersIdsCount; ownersIdsIndex++)
                OwnersIds.Add(reader.ReadVarUhLong());
        }
    }
}