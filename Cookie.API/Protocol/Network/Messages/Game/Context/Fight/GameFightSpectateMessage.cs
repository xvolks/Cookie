namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Types.Game.Action.Fight;
    using Types.Game.Actions.Fight;
    using Types.Game.Idol;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightSpectateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6069;
        public override ushort MessageID => ProtocolId;
        public List<FightDispellableEffectExtendedInformations> Effects { get; set; }
        public List<GameActionMark> Marks { get; set; }
        public ushort GameTurn { get; set; }
        public int FightStart { get; set; }
        public List<Idol> Idols { get; set; }

        public GameFightSpectateMessage(List<FightDispellableEffectExtendedInformations> effects, List<GameActionMark> marks, ushort gameTurn, int fightStart, List<Idol> idols)
        {
            Effects = effects;
            Marks = marks;
            GameTurn = gameTurn;
            FightStart = fightStart;
            Idols = idols;
        }

        public GameFightSpectateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Effects.Count);
            for (var effectsIndex = 0; effectsIndex < Effects.Count; effectsIndex++)
            {
                var objectToSend = Effects[effectsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short)Marks.Count);
            for (var marksIndex = 0; marksIndex < Marks.Count; marksIndex++)
            {
                var objectToSend = Marks[marksIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteVarUhShort(GameTurn);
            writer.WriteInt(FightStart);
            writer.WriteShort((short)Idols.Count);
            for (var idolsIndex = 0; idolsIndex < Idols.Count; idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var effectsCount = reader.ReadUShort();
            Effects = new List<FightDispellableEffectExtendedInformations>();
            for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
            {
                var objectToAdd = new FightDispellableEffectExtendedInformations();
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            var marksCount = reader.ReadUShort();
            Marks = new List<GameActionMark>();
            for (var marksIndex = 0; marksIndex < marksCount; marksIndex++)
            {
                var objectToAdd = new GameActionMark();
                objectToAdd.Deserialize(reader);
                Marks.Add(objectToAdd);
            }
            GameTurn = reader.ReadVarUhShort();
            FightStart = reader.ReadInt();
            var idolsCount = reader.ReadUShort();
            Idols = new List<Idol>();
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = new Idol();
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }

    }
}
