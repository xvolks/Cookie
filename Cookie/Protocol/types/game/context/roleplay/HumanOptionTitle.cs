using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionTitle : HumanOption
    {
        public new const short ProtocolId = 408;
        public override short TypeId { get { return ProtocolId; } }

        public short TitleId = 0;
        public string TitleParam;

        public HumanOptionTitle(): base()
        {
        }

        public HumanOptionTitle(
            short titleId,
            string titleParam
        ): base()
        {
            TitleId = titleId;
            TitleParam = titleParam;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(TitleId);
            writer.WriteUTF(TitleParam);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TitleId = reader.ReadVarShort();
            TitleParam = reader.ReadUTF();
        }
    }
}