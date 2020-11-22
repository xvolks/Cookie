using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6276;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public List<double> AlliesId { get; set; }
        public ushort Duration { get; set; }
        public GameRolePlayArenaFightPropositionMessage() { }

        public GameRolePlayArenaFightPropositionMessage( ushort FightId, List<double> AlliesId, ushort Duration ){
            this.FightId = FightId;
            this.AlliesId = AlliesId;
            this.Duration = Duration;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
			writer.WriteShort((short)AlliesId.Count);
			foreach (var x in AlliesId)
			{
				writer.WriteDouble(x);
			}
            writer.WriteVarUhShort(Duration);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            var AlliesIdCount = reader.ReadShort();
            AlliesId = new List<double>();
            for (var i = 0; i < AlliesIdCount; i++)
            {
                AlliesId.Add(reader.ReadDouble());
            }
            Duration = reader.ReadVarUhShort();
        }
    }
}
