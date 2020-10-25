using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamMemberInformations : NetworkType
    {
        public const short ProtocolId = 44;
        public override short TypeId { get { return ProtocolId; } }

        public double Id_ = 0;

        public FightTeamMemberInformations()
        {
        }

        public FightTeamMemberInformations(
            double id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
        }
    }
}