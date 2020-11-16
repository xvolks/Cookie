using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
    {
        public new const short ProtocolId = 456;
        public override short TypeId { get { return ProtocolId; } }

        public string Name;

        public GameFightFighterNamedLightInformations(): base()
        {
        }

        public GameFightFighterNamedLightInformations(
            bool sex,
            bool alive,
            double id_,
            byte wave,
            short level,
            byte breed,
            string name
        ): base(
            sex,
            alive,
            id_,
            wave,
            level,
            breed
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