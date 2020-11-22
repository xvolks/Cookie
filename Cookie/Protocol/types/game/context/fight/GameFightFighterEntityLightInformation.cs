using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterEntityLightInformation : GameFightFighterLightInformations
    {
        public new const short ProtocolId = 548;
        public override short TypeId { get { return ProtocolId; } }

        public byte EntityModelId = 0;
        public double MasterId = 0;

        public GameFightFighterEntityLightInformation(): base()
        {
        }

        public GameFightFighterEntityLightInformation(
            bool sex,
            bool alive,
            double id_,
            byte wave,
            short level,
            byte breed,
            byte entityModelId,
            double masterId
        ): base(
            sex,
            alive,
            id_,
            wave,
            level,
            breed
        )
        {
            EntityModelId = entityModelId;
            MasterId = masterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EntityModelId);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadByte();
            MasterId = reader.ReadDouble();
        }
    }
}