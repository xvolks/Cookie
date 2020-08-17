using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    public class LockableUseCodeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5667;

        public LockableUseCodeMessage(string code)
        {
            Code = code;
        }

        public LockableUseCodeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Code { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            Code = reader.ReadUTF();
        }
    }
}