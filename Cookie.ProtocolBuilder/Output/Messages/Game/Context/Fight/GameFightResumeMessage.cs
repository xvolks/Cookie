namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Types.Game.Action.Fight;
    using Types.Game.Actions.Fight;
    using Types.Game.Context.Fight;
    using Types.Game.Idol;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public new const ushort ProtocolId = 6067;
        public override ushort MessageID => ProtocolId;
        public List<GameFightSpellCooldown> SpellCooldowns { get; set; }
        public byte SummonCount { get; set; }
        public byte BombCount { get; set; }

        public GameFightResumeMessage(List<GameFightSpellCooldown> spellCooldowns, byte summonCount, byte bombCount)
        {
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }

        public GameFightResumeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)SpellCooldowns.Count);
            for (var spellCooldownsIndex = 0; spellCooldownsIndex < SpellCooldowns.Count; spellCooldownsIndex++)
            {
                var objectToSend = SpellCooldowns[spellCooldownsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteByte(SummonCount);
            writer.WriteByte(BombCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var spellCooldownsCount = reader.ReadUShort();
            SpellCooldowns = new List<GameFightSpellCooldown>();
            for (var spellCooldownsIndex = 0; spellCooldownsIndex < spellCooldownsCount; spellCooldownsIndex++)
            {
                var objectToAdd = new GameFightSpellCooldown();
                objectToAdd.Deserialize(reader);
                SpellCooldowns.Add(objectToAdd);
            }
            SummonCount = reader.ReadByte();
            BombCount = reader.ReadByte();
        }

    }
}
