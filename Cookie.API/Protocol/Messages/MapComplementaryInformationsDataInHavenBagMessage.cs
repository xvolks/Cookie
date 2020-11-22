using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6622;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations OwnerInformations { get; set; }
        public sbyte Theme { get; set; }
        public sbyte RoomId { get; set; }
        public sbyte MaxRoomId { get; set; }
        public MapComplementaryInformationsDataInHavenBagMessage() { }

        public MapComplementaryInformationsDataInHavenBagMessage( CharacterMinimalInformations OwnerInformations, sbyte Theme, sbyte RoomId, sbyte MaxRoomId ){
            this.OwnerInformations = OwnerInformations;
            this.Theme = Theme;
            this.RoomId = RoomId;
            this.MaxRoomId = MaxRoomId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            OwnerInformations.Serialize(writer);
            writer.WriteSByte(Theme);
            writer.WriteSByte(RoomId);
            writer.WriteSByte(MaxRoomId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OwnerInformations = new CharacterMinimalInformations();
            OwnerInformations.Deserialize(reader);
            Theme = reader.ReadSByte();
            RoomId = reader.ReadSByte();
            MaxRoomId = reader.ReadSByte();
        }
    }
}
