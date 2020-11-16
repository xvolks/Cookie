using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public new const ushort ProtocolId = 6067;

        public override ushort MessageID => ProtocolId;

        public List<GameFightSpellCooldown> SpellCooldowns { get; set; }
        public sbyte SummonCount { get; set; }
        public sbyte BombCount { get; set; }
        public GameFightResumeMessage() { }

        public GameFightResumeMessage( List<GameFightSpellCooldown> SpellCooldowns, sbyte SummonCount, sbyte BombCount ){
            this.SpellCooldowns = SpellCooldowns;
            this.SummonCount = SummonCount;
            this.BombCount = BombCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
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
            base.Deserialize(reader);
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
