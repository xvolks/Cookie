using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightSpectateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6069;

        public override ushort MessageID => ProtocolId;

        public List<FightDispellableEffectExtendedInformations> Effects { get; set; }
        public List<GameActionMark> Marks { get; set; }
        public ushort GameTurn { get; set; }
        public int FightStart { get; set; }
        public List<Idol> Idols { get; set; }
        public GameFightSpectateMessage() { }

        public GameFightSpectateMessage( List<FightDispellableEffectExtendedInformations> Effects, List<GameActionMark> Marks, ushort GameTurn, int FightStart, List<Idol> Idols ){
            this.Effects = Effects;
            this.Marks = Marks;
            this.GameTurn = GameTurn;
            this.FightStart = FightStart;
            this.Idols = Idols;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Effects.Count);
			foreach (var x in Effects)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Marks.Count);
			foreach (var x in Marks)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhShort(GameTurn);
            writer.WriteInt(FightStart);
			writer.WriteShort((short)Idols.Count);
			foreach (var x in Idols)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var EffectsCount = reader.ReadShort();
            Effects = new List<FightDispellableEffectExtendedInformations>();
            for (var i = 0; i < EffectsCount; i++)
            {
                var objectToAdd = new FightDispellableEffectExtendedInformations();
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            var MarksCount = reader.ReadShort();
            Marks = new List<GameActionMark>();
            for (var i = 0; i < MarksCount; i++)
            {
                var objectToAdd = new GameActionMark();
                objectToAdd.Deserialize(reader);
                Marks.Add(objectToAdd);
            }
            GameTurn = reader.ReadVarUhShort();
            FightStart = reader.ReadInt();
            var IdolsCount = reader.ReadShort();
            Idols = new List<Idol>();
            for (var i = 0; i < IdolsCount; i++)
            {
                var objectToAdd = new Idol();
                objectToAdd.Deserialize(reader);
                Idols.Add(objectToAdd);
            }
        }
    }
}
