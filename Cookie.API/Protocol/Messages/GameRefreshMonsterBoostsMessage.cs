using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRefreshMonsterBoostsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6618;

        public override ushort MessageID => ProtocolId;

        public List<MonsterBoosts> MonsterBoosts { get; set; }
        public List<MonsterBoosts> FamilyBoosts { get; set; }
        public GameRefreshMonsterBoostsMessage() { }

        public GameRefreshMonsterBoostsMessage( List<MonsterBoosts> MonsterBoosts, List<MonsterBoosts> FamilyBoosts ){
            this.MonsterBoosts = MonsterBoosts;
            this.FamilyBoosts = FamilyBoosts;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)MonsterBoosts.Count);
			foreach (var x in MonsterBoosts)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)FamilyBoosts.Count);
			foreach (var x in FamilyBoosts)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MonsterBoostsCount = reader.ReadShort();
            MonsterBoosts = new List<MonsterBoosts>();
            for (var i = 0; i < MonsterBoostsCount; i++)
            {
                var objectToAdd = new MonsterBoosts();
                objectToAdd.Deserialize(reader);
                MonsterBoosts.Add(objectToAdd);
            }
            var FamilyBoostsCount = reader.ReadShort();
            FamilyBoosts = new List<MonsterBoosts>();
            for (var i = 0; i < FamilyBoostsCount; i++)
            {
                var objectToAdd = new MonsterBoosts();
                objectToAdd.Deserialize(reader);
                FamilyBoosts.Add(objectToAdd);
            }
        }
    }
}
