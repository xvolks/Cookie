using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyGuestInformations : NetworkType
    {
        public const ushort ProtocolId = 374;

        public override ushort TypeID => ProtocolId;

        public ulong GuestId { get; set; }
        public ulong HostId { get; set; }
        public string Name { get; set; }
        public EntityLook GuestLook { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public PlayerStatus Status { get; set; }
        public List<PartyEntityBaseInformation> Entities { get; set; }
        public PartyGuestInformations() { }

        public PartyGuestInformations( ulong GuestId, ulong HostId, string Name, EntityLook GuestLook, sbyte Breed, bool Sex, PlayerStatus Status, List<PartyEntityBaseInformation> Entities ){
            this.GuestId = GuestId;
            this.HostId = HostId;
            this.Name = Name;
            this.GuestLook = GuestLook;
            this.Breed = Breed;
            this.Sex = Sex;
            this.Status = Status;
            this.Entities = Entities;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(GuestId);
            writer.WriteVarUhLong(HostId);
            writer.WriteUTF(Name);
            GuestLook.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            Status.Serialize(writer);
			writer.WriteShort((short)Entities.Count);
			foreach (var x in Entities)
			{
				x.Serialize(writer);
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
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
            var EntitiesCount = reader.ReadShort();
            Entities = new List<PartyEntityBaseInformation>();
            for (var i = 0; i < EntitiesCount; i++)
            {
                var objectToAdd = new PartyEntityBaseInformation();
                objectToAdd.Deserialize(reader);
                Entities.Add(objectToAdd);
            }
        }
    }
}
