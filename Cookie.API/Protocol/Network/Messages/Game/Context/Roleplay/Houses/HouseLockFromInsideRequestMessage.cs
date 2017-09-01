using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
    {
        public new const ushort ProtocolId = 5885;

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