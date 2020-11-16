using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public new const ushort ProtocolId = 180;

        public override ushort TypeID => ProtocolId;

        public string OwnerName { get; set; }
        public byte Level { get; set; }
        public GameRolePlayMountInformations() { }

        public GameRolePlayMountInformations( string OwnerName, byte Level ){
            this.OwnerName = OwnerName;
            this.Level = Level;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(OwnerName);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OwnerName = reader.ReadUTF();
            Level = reader.ReadByte();
        }
    }
}
