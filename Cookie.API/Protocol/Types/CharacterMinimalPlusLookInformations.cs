using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public new const ushort ProtocolId = 163;

        public override ushort TypeID => ProtocolId;

        public EntityLook EntityLook { get; set; }
        public sbyte Breed { get; set; }
        public CharacterMinimalPlusLookInformations() { }

        public CharacterMinimalPlusLookInformations( EntityLook EntityLook, sbyte Breed ){
            this.EntityLook = EntityLook;
            this.Breed = Breed;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            EntityLook.Serialize(writer);
            writer.WriteSByte(Breed);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityLook = new EntityLook();
            EntityLook.Deserialize(reader);
            Breed = reader.ReadSByte();
        }
    }
}
