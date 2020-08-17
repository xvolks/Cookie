using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Character
{
    public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
    {
        public new const ushort ProtocolId = 6218;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}