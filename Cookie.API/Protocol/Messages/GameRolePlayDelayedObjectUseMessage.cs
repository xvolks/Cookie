using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
    {
        public new const ushort ProtocolId = 6425;

        public override ushort MessageID => ProtocolId;

        public ushort ObjectGID { get; set; }
        public GameRolePlayDelayedObjectUseMessage() { }

        public GameRolePlayDelayedObjectUseMessage( ushort ObjectGID ){
            this.ObjectGID = ObjectGID;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}
