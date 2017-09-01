using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
    {
        public new const ushort ProtocolId = 6113;

        public GameActionFightDispellEffectMessage(int boostUID)
        {
            BoostUID = boostUID;
        }

        public GameActionFightDispellEffectMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int BoostUID { get; set; }

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