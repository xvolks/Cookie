using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6454;

        public override ushort MessageID => ProtocolId;

        public List<long> PlayerIds { get; set; }
        public List<sbyte> Enable { get; set; }
        public UpdateMapPlayersAgressableStatusMessage() { }

        public UpdateMapPlayersAgressableStatusMessage( List<long> PlayerIds, List<sbyte> Enable ){
            this.PlayerIds = PlayerIds;
            this.Enable = Enable;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)PlayerIds.Count);
			foreach (var x in PlayerIds)
			{
				writer.WriteVarLong(x);
			}
			writer.WriteShort((short)Enable.Count);
			foreach (var x in Enable)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var PlayerIdsCount = reader.ReadShort();
            PlayerIds = new List<long>();
            for (var i = 0; i < PlayerIdsCount; i++)
            {
                PlayerIds.Add(reader.ReadVarLong());
            }
            var EnableCount = reader.ReadShort();
            Enable = new List<sbyte>();
            for (var i = 0; i < EnableCount; i++)
            {
                Enable.Add(reader.ReadSByte());
            }
        }
    }
}
