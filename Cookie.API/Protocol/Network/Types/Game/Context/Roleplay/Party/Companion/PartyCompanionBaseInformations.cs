using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion
{
    public class PartyCompanionBaseInformations : NetworkType
    {
        public const ushort ProtocolId = 453;

        public PartyCompanionBaseInformations(byte indexId, byte companionGenericId, EntityLook entityLook)
        {
            IndexId = indexId;
            CompanionGenericId = companionGenericId;
            EntityLook = entityLook;
        }

        public PartyCompanionBaseInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte IndexId { get; set; }
        public byte CompanionGenericId { get; set; }
        public EntityLook EntityLook { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(IndexId);
            writer.WriteByte(CompanionGenericId);
            EntityLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            IndexId = reader.ReadByte();
            CompanionGenericId = reader.ReadByte();
            EntityLook = new EntityLook();
            EntityLook.Deserialize(reader);
        }
    }
}