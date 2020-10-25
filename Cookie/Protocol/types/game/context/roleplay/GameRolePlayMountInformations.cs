using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public new const short ProtocolId = 180;
        public override short TypeId { get { return ProtocolId; } }

        public string OwnerName;
        public byte Level = 0;

        public GameRolePlayMountInformations(): base()
        {
        }

        public GameRolePlayMountInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            string name,
            string ownerName,
            byte level
        ): base(
            contextualId,
            look,
            disposition,
            name
        )
        {
            OwnerName = ownerName;
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(OwnerName);
            writer.WriteByte(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            OwnerName = reader.ReadUTF();
            Level = reader.ReadByte();
        }
    }
}