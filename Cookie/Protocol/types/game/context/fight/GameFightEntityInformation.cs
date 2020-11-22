using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightEntityInformation : GameFightFighterInformations
    {
        public new const short ProtocolId = 551;
        public override short TypeId { get { return ProtocolId; } }

        public byte EntityModelId = 0;
        public short Level = 0;
        public double MasterId = 0;

        public GameFightEntityInformation(): base()
        {
        }

        public GameFightEntityInformation(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            byte teamId,
            byte wave,
            bool alive,
            GameFightMinimalStats stats,
            List<short> previousPositions,
            byte entityModelId,
            short level,
            double masterId
        ): base(
            contextualId,
            look,
            disposition,
            teamId,
            wave,
            alive,
            stats,
            previousPositions
        )
        {
            EntityModelId = entityModelId;
            Level = level;
            MasterId = masterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EntityModelId);
            writer.WriteVarShort(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadByte();
            Level = reader.ReadVarShort();
            MasterId = reader.ReadDouble();
        }
    }
}