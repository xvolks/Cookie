namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class FightResultAdditionalData : NetworkType
    {
        public const ushort ProtocolId = 191;
        public override ushort TypeID => ProtocolId;

        public FightResultAdditionalData() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
