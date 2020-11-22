using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterMinimalGuildPublicInformations : CharacterMinimalInformations
    {
        public new const short ProtocolId = 556;
        public override short TypeId { get { return ProtocolId; } }

        public int Rank = 0;

        public CharacterMinimalGuildPublicInformations(): base()
        {
        }

        public CharacterMinimalGuildPublicInformations(
            long id_,
            string name,
            short level,
            int rank
        ): base(
            id_,
            name,
            level
        )
        {
            Rank = rank;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Rank);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarInt();
        }
    }
}