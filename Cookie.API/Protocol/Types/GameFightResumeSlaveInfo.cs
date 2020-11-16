using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightResumeSlaveInfo : NetworkType
    {
        public const ushort ProtocolId = 364;

        public override ushort TypeID => ProtocolId;

        public double SlaveId { get; set; }
        public List<GameFightSpellCooldown> SpellCooldowns { get; set; }
        public sbyte SummonCount { get; set; }
        public sbyte BombCount { get; set; }
        public GameFightResumeSlaveInfo() { }

        public GameFightResumeSlaveInfo( double SlaveId, List<GameFightSpellCooldown> SpellCooldowns, sbyte SummonCount, sbyte BombCount ){
            this.SlaveId = SlaveId;
            this.SpellCooldowns = SpellCooldowns;
            this.SummonCount = SummonCount;
            this.BombCount = BombCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SlaveId);
			writer.WriteShort((short)SpellCooldowns.Count);
			foreach (var x in SpellCooldowns)
			{
				x.Serialize(writer);
			}
            writer.WriteSByte(SummonCount);
            writer.WriteSByte(BombCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            SlaveId = reader.ReadDouble();
            var SpellCooldownsCount = reader.ReadShort();
            SpellCooldowns = new List<GameFightSpellCooldown>();
            for (var i = 0; i < SpellCooldownsCount; i++)
            {
                var objectToAdd = new GameFightSpellCooldown();
                objectToAdd.Deserialize(reader);
                SpellCooldowns.Add(objectToAdd);
            }
            SummonCount = reader.ReadSByte();
            BombCount = reader.ReadSByte();
        }
    }
}
