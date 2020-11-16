using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 456;

        public override ushort TypeID => ProtocolId;

        public string Name { get; set; }
        public GameFightFighterNamedLightInformations() { }

        public GameFightFighterNamedLightInformations( string Name ){
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}
