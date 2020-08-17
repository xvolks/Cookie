using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Status;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    public class PartyGuestInformations : NetworkType
    {
        public const ushort ProtocolId = 374;

        public PartyGuestInformations(ulong guestId, ulong hostId, string name, EntityLook guestLook, sbyte breed,
            bool sex, PlayerStatus status, List<PartyCompanionBaseInformations> companions)
        {
            GuestId = guestId;
            HostId = hostId;
            Name = name;
            GuestLook = guestLook;
            Breed = breed;
            Sex = sex;
            Status = status;
            Companions = companions;
        }

        public PartyGuestInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong GuestId { get; set; }
        public ulong HostId { get; set; }
        public string Name { get; set; }
        public EntityLook GuestLook { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public PlayerStatus Status { get; set; }
        public List<PartyCompanionBaseInformations> Companions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(GuestId);
            writer.WriteVarUhLong(HostId);
            writer.WriteUTF(Name);
            GuestLook.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteUShort(Status.TypeID);
            Status.Serialize(writer);
            writer.WriteShort((short) Companions.Count);
            for (var companionsIndex = 0; companionsIndex < Companions.Count; companionsIndex++)
            {
                var objectToSend = Companions[companionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestId = reader.ReadVarUhLong();
            HostId = reader.ReadVarUhLong();
            Name = reader.ReadUTF();
            GuestLook = new EntityLook();
            GuestLook.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
            var companionsCount = reader.ReadUShort();
            Companions = new List<PartyCompanionBaseInformations>();
            for (var companionsIndex = 0; companionsIndex < companionsCount; companionsIndex++)
            {
                var objectToAdd = new PartyCompanionBaseInformations();
                objectToAdd.Deserialize(reader);
                Companions.Add(objectToAdd);
            }
        }
    }
}