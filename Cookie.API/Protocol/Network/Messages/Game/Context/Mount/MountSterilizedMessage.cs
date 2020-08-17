using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountSterilizedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5977;

        public MountSterilizedMessage(int mountId)
        {
            MountId = mountId;
        }

        public MountSterilizedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
        }
    }
}