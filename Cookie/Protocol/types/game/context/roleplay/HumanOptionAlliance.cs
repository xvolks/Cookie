using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionAlliance : HumanOption
    {
        public new const short ProtocolId = 425;
        public override short TypeId { get { return ProtocolId; } }

        public AllianceInformations AllianceInformations_;
        public byte Aggressable = 0;

        public HumanOptionAlliance(): base()
        {
        }

        public HumanOptionAlliance(
            AllianceInformations allianceInformations_,
            byte aggressable
        ): base()
        {
            AllianceInformations_ = allianceInformations_;
            Aggressable = aggressable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            AllianceInformations_.Serialize(writer);
            writer.WriteByte(Aggressable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceInformations_ = new AllianceInformations();
            AllianceInformations_.Deserialize(reader);
            Aggressable = reader.ReadByte();
        }
    }
}