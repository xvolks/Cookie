using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 154;
        public override short TypeId { get { return ProtocolId; } }

        public string Name;

        public GameRolePlayNamedActorInformations(): base()
        {
        }

        public GameRolePlayNamedActorInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            string name
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}