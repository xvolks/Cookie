using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Ui
{
    public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
    {
        public new const ushort ProtocolId = 6463;

        public ClientUIOpenedByObjectMessage(uint uid)
        {
            Uid = uid;
        }

        public ClientUIOpenedByObjectMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint Uid { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Uid);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Uid = reader.ReadVarUhInt();
        }
    }
}