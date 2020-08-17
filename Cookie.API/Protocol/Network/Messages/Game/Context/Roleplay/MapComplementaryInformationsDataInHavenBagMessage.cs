namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.Character;
    using Types.Game.House;
    using Types.Game.Context.Roleplay;
    using Types.Game.Interactive;
    using Types.Game.Interactive;
    using Types.Game.Interactive;
    using Types.Game.Context.Fight;
    using Types.Game.Context.Fight;
    using System.Collections.Generic;
    using Utils.IO;

    public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6622;
        public override ushort MessageID => ProtocolId;
        public CharacterMinimalInformations OwnerInformations { get; set; }
        public sbyte Theme { get; set; }
        public byte RoomId { get; set; }
        public byte MaxRoomId { get; set; }

        public MapComplementaryInformationsDataInHavenBagMessage(CharacterMinimalInformations ownerInformations, sbyte theme, byte roomId, byte maxRoomId)
        {
            OwnerInformations = ownerInformations;
            Theme = theme;
            RoomId = roomId;
            MaxRoomId = maxRoomId;
        }

        public MapComplementaryInformationsDataInHavenBagMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            OwnerInformations.Serialize(writer);
            writer.WriteSByte(Theme);
            writer.WriteByte(RoomId);
            writer.WriteByte(MaxRoomId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OwnerInformations = new CharacterMinimalInformations();
            OwnerInformations.Deserialize(reader);
            Theme = reader.ReadSByte();
            RoomId = reader.ReadByte();
            MaxRoomId = reader.ReadByte();
        }

    }
}
