using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightOptionsInformations : NetworkType
    {
        public const ushort ProtocolId = 20;

        public FightOptionsInformations(bool isSecret, bool isRestrictedToPartyOnly, bool isClosed,
            bool isAskingForHelp)
        {
            IsSecret = isSecret;
            IsRestrictedToPartyOnly = isRestrictedToPartyOnly;
            IsClosed = isClosed;
            IsAskingForHelp = isAskingForHelp;
        }

        public FightOptionsInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool IsSecret { get; set; }
        public bool IsRestrictedToPartyOnly { get; set; }
        public bool IsClosed { get; set; }
        public bool IsAskingForHelp { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, IsSecret);
            flag = BooleanByteWrapper.SetFlag(1, flag, IsRestrictedToPartyOnly);
            flag = BooleanByteWrapper.SetFlag(2, flag, IsClosed);
            flag = BooleanByteWrapper.SetFlag(3, flag, IsAskingForHelp);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            IsSecret = BooleanByteWrapper.GetFlag(flag, 0);
            IsRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag, 1);
            IsClosed = BooleanByteWrapper.GetFlag(flag, 2);
            IsAskingForHelp = BooleanByteWrapper.GetFlag(flag, 3);
        }
    }
}