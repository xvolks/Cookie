using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
    {
        public new const uint ProtocolId = 6113;
        public override uint MessageID { get { return ProtocolId; } }

        public int BoostUID = 0;

        public GameActionFightDispellEffectMessage(): base()
        {
        }

        public GameActionFightDispellEffectMessage(
            short actionId,
            double sourceId,
            double targetId,
            bool verboseCast,
            int boostUID
        ): base(
            actionId,
            sourceId,
            targetId,
            verboseCast
        )
        {
            BoostUID = boostUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(BoostUID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            BoostUID = reader.ReadInt();
        }
    }
}