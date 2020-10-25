using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
    {
        public new const uint ProtocolId = 6218;
        public override uint MessageID { get { return ProtocolId; } }

        public GameFightShowFighterRandomStaticPoseMessage(): base()
        {
        }

        public GameFightShowFighterRandomStaticPoseMessage(
            GameFightFighterInformations informations
        ): base(
            informations
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}