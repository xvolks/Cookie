using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class HumanOptionTitle : HumanOption
    {
        public new const ushort ProtocolId = 408;

        public HumanOptionTitle(ushort titleId, string titleParam)
        {
            TitleId = titleId;
            TitleParam = titleParam;
        }

        public HumanOptionTitle()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort TitleId { get; set; }
        public string TitleParam { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(TitleId);
            writer.WriteUTF(TitleParam);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TitleId = reader.ReadVarUhShort();
            TitleParam = reader.ReadUTF();
        }
    }
}