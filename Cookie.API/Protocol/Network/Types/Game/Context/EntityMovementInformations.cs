using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    public class EntityMovementInformations : NetworkType
    {
        public const ushort ProtocolId = 63;

        public EntityMovementInformations(int objectId, List<sbyte> steps)
        {
            ObjectId = objectId;
            Steps = steps;
        }

        public EntityMovementInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int ObjectId { get; set; }
        public List<sbyte> Steps { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ObjectId);
            writer.WriteShort((short) Steps.Count);
            for (var stepsIndex = 0; stepsIndex < Steps.Count; stepsIndex++)
                writer.WriteSByte(Steps[stepsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadInt();
            var stepsCount = reader.ReadUShort();
            Steps = new List<sbyte>();
            for (var stepsIndex = 0; stepsIndex < stepsCount; stepsIndex++)
                Steps.Add(reader.ReadSByte());
        }
    }
}