namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Utils.IO;

    public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
    {
        public new const ushort ProtocolId = 6113;
        public override ushort MessageID => ProtocolId;
        public int BoostUID { get; set; }

        public GameActionFightDispellEffectMessage(int boostUID)
        {
            BoostUID = boostUID;
        }

        public GameActionFightDispellEffectMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(BoostUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BoostUID = reader.ReadInt();
        }

    }
}
