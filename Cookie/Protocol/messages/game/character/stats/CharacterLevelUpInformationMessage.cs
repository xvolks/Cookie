using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
    {
        public new const uint ProtocolId = 6076;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public long Id_ = 0;

        public CharacterLevelUpInformationMessage(): base()
        {
        }

        public CharacterLevelUpInformationMessage(
            short newLevel,
            string name,
            long id_
        ): base(
            newLevel
        )
        {
            Name = name;
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarLong(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Id_ = reader.ReadVarLong();
        }
    }
}