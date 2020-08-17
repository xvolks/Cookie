using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Mount
{
    public class UpdateMountIntBoost : UpdateMountBoost
    {
        public new const ushort ProtocolId = 357;

        public UpdateMountIntBoost(int value)
        {
            Value = value;
        }

        public UpdateMountIntBoost()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}