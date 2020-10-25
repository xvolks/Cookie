using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightSpectateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6069;
        public override uint MessageID { get { return ProtocolId; } }

        public List<FightDispellableEffectExtendedInformations> Effects;
        public List<GameActionMark> Marks;
        public short GameTurn = 0;
        public int FightStart = 0;
        public List<Idol> Idols;

        public GameFightSpectateMessage()
        {
        }

        public GameFightSpectateMessage(
            List<FightDispellableEffectExtendedInformations> effects,
            List<GameActionMark> marks,
            short gameTurn,
            int fightStart,
            List<Idol> idols
        )
        {
            Effects = effects;
            Marks = marks;
            GameTurn = gameTurn;
            FightStart = fightStart;
            Idols = idols;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Effects.Count());
            foreach (var current in Effects)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)Marks.Count());
            foreach (var current in Marks)
            {
                current.Serialize(writer);
            }
            writer.WriteVarShort(GameTurn);
            writer.WriteInt(FightStart);
            writer.WriteShort((short)Idols.Count());
            foreach (var current in Idols)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countEffects = reader.ReadShort();
            Effects = new List<FightDispellableEffectExtendedInformations>();
            for (short i = 0; i < countEffects; i++)
            {
                FightDispellableEffectExtendedInformations type = new FightDispellableEffectExtendedInformations();
                type.Deserialize(reader);
                Effects.Add(type);
            }
            var countMarks = reader.ReadShort();
            Marks = new List<GameActionMark>();
            for (short i = 0; i < countMarks; i++)
            {
                GameActionMark type = new GameActionMark();
                type.Deserialize(reader);
                Marks.Add(type);
            }
            GameTurn = reader.ReadVarShort();
            FightStart = reader.ReadInt();
            var countIdols = reader.ReadShort();
            Idols = new List<Idol>();
            for (short i = 0; i < countIdols; i++)
            {
                Idol type = new Idol();
                type.Deserialize(reader);
                Idols.Add(type);
            }
        }
    }
}