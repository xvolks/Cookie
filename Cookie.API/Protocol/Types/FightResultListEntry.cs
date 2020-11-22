using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultListEntry : NetworkType
    {
        public const ushort ProtocolId = 16;

        public override ushort TypeID => ProtocolId;

        public ushort Outcome { get; set; }
        public sbyte Wave { get; set; }
        public FightLoot Rewards { get; set; }
        public FightResultListEntry() { }

        public FightResultListEntry( ushort Outcome, sbyte Wave, FightLoot Rewards ){
            this.Outcome = Outcome;
            this.Wave = Wave;
            this.Rewards = Rewards;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Outcome);
            writer.WriteSByte(Wave);
            Rewards.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Outcome = reader.ReadVarUhShort();
            Wave = reader.ReadSByte();
            Rewards = new FightLoot();
            Rewards.Deserialize(reader);
        }
    }
}
