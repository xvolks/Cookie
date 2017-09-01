using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class HavenBagPackListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6620;

        public HavenBagPackListMessage(List<sbyte> packIds)
        {
            PackIds = packIds;
        }

        public HavenBagPackListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<sbyte> PackIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PackIds.Count);
            for (var packIdsIndex = 0; packIdsIndex < PackIds.Count; packIdsIndex++)
                writer.WriteSByte(PackIds[packIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var packIdsCount = reader.ReadUShort();
            PackIds = new List<sbyte>();
            for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++)
                PackIds.Add(reader.ReadSByte());
        }
    }
}