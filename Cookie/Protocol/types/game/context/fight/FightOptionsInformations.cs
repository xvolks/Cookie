using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightOptionsInformations : NetworkType
    {
        public const short ProtocolId = 20;
        public override short TypeId { get { return ProtocolId; } }

        public bool IsSecret = false;
        public bool IsRestrictedToPartyOnly = false;
        public bool IsClosed = false;
        public bool IsAskingForHelp = false;

        public FightOptionsInformations()
        {
        }

        public FightOptionsInformations(
            bool isSecret,
            bool isRestrictedToPartyOnly,
            bool isClosed,
            bool isAskingForHelp
        )
        {
            IsSecret = isSecret;
            IsRestrictedToPartyOnly = isRestrictedToPartyOnly;
            IsClosed = isClosed;
            IsAskingForHelp = isAskingForHelp;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, IsSecret);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsRestrictedToPartyOnly);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, IsClosed);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, IsAskingForHelp);
            writer.WriteByte(box0);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            IsSecret = BooleanByteWrapper.GetFlag(box0, 1);
            IsRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(box0, 2);
            IsClosed = BooleanByteWrapper.GetFlag(box0, 3);
            IsAskingForHelp = BooleanByteWrapper.GetFlag(box0, 4);
        }
    }
}