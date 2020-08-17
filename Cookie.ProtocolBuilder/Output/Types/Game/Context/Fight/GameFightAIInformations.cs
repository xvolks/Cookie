namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Context;
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightAIInformations : GameFightFighterInformations
    {
        public new const ushort ProtocolId = 151;
        public override ushort TypeID => ProtocolId;

        public GameFightAIInformations() { }

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
