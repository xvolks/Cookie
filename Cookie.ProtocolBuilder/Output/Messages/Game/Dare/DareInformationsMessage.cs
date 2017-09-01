namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using Types.Game.Dare;
    using Utils.IO;

    public class DareInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6656;
        public override ushort MessageID => ProtocolId;
        public DareInformations DareFixedInfos { get; set; }
        public DareVersatileInformations DareVersatilesInfos { get; set; }

        public DareInformationsMessage(DareInformations dareFixedInfos, DareVersatileInformations dareVersatilesInfos)
        {
            DareFixedInfos = dareFixedInfos;
            DareVersatilesInfos = dareVersatilesInfos;
        }

        public DareInformationsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            DareFixedInfos.Serialize(writer);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareFixedInfos = new DareInformations();
            DareFixedInfos.Deserialize(reader);
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }

    }
}
