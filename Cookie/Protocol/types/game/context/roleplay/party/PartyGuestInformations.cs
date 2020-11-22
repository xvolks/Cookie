using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PartyGuestInformations : NetworkType
    {
        public const short ProtocolId = 374;
        public override short TypeId { get { return ProtocolId; } }

        public long GuestId = 0;
        public long HostId = 0;
        public string Name;
        public EntityLook GuestLook;
        public byte Breed = 0;
        public bool Sex = false;
        public PlayerStatus Status;
        public List<PartyEntityBaseInformation> Entities;

        public PartyGuestInformations()
        {
        }

        public PartyGuestInformations(
            long guestId,
            long hostId,
            string name,
            EntityLook guestLook,
            byte breed,
            bool sex,
            PlayerStatus status,
            List<PartyEntityBaseInformation> entities
        )
        {
            GuestId = guestId;
            HostId = hostId;
            Name = name;
            GuestLook = guestLook;
            Breed = breed;
            Sex = sex;
            Status = status;
            Entities = entities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(GuestId);
            writer.WriteVarLong(HostId);
            writer.WriteUTF(Name);
            GuestLook.Serialize(writer);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
            writer.WriteShort((short)Entities.Count());
            foreach (var current in Entities)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuestId = reader.ReadVarLong();
            HostId = reader.ReadVarLong();
            Name = reader.ReadUTF();
            GuestLook = new EntityLook();
            GuestLook.Deserialize(reader);
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
            var countEntities = reader.ReadShort();
            Entities = new List<PartyEntityBaseInformation>();
            for (short i = 0; i < countEntities; i++)
            {
                PartyEntityBaseInformation type = new PartyEntityBaseInformation();
                type.Deserialize(reader);
                Entities.Add(type);
            }
        }
    }
}