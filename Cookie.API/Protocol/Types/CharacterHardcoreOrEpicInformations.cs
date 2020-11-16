using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
    {
        public new const ushort ProtocolId = 474;

        public override ushort TypeID => ProtocolId;

        public sbyte DeathState { get; set; }
        public ushort DeathCount { get; set; }
        public ushort DeathMaxLevel { get; set; }
        public CharacterHardcoreOrEpicInformations() { }

        public CharacterHardcoreOrEpicInformations( sbyte DeathState, ushort DeathCount, ushort DeathMaxLevel ){
            this.DeathState = DeathState;
            this.DeathCount = DeathCount;
            this.DeathMaxLevel = DeathMaxLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(DeathState);
            writer.WriteVarUhShort(DeathCount);
            writer.WriteVarUhShort(DeathMaxLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DeathState = reader.ReadSByte();
            DeathCount = reader.ReadVarUhShort();
            DeathMaxLevel = reader.ReadVarUhShort();
        }
    }
}
