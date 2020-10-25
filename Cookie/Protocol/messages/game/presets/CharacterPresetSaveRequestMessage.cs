using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterPresetSaveRequestMessage : PresetSaveRequestMessage
    {
        public new const uint ProtocolId = 6756;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;

        public CharacterPresetSaveRequestMessage(): base()
        {
        }

        public CharacterPresetSaveRequestMessage(
            short presetId,
            byte symbolId,
            bool updateData,
            string name
        ): base(
            presetId,
            symbolId,
            updateData
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