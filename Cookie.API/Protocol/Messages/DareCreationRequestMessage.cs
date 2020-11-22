using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareCreationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6665;

        public override ushort MessageID => ProtocolId;

        public bool IsPrivate { get; set; }
        public bool IsForGuild { get; set; }
        public bool IsForAlliance { get; set; }
        public bool NeedNotifications { get; set; }
        public ulong SubscriptionFee { get; set; }
        public ulong Jackpot { get; set; }
        public ushort MaxCountWinners { get; set; }
        public uint DelayBeforeStart { get; set; }
        public uint Duration { get; set; }
        public List<DareCriteria> Criterions { get; set; }
        public DareCreationRequestMessage() { }

        public DareCreationRequestMessage( bool IsPrivate, bool IsForGuild, bool IsForAlliance, bool NeedNotifications, ulong SubscriptionFee, ulong Jackpot, ushort MaxCountWinners, uint DelayBeforeStart, uint Duration, List<DareCriteria> Criterions ){
            this.IsPrivate = IsPrivate;
            this.IsForGuild = IsForGuild;
            this.IsForAlliance = IsForAlliance;
            this.NeedNotifications = NeedNotifications;
            this.SubscriptionFee = SubscriptionFee;
            this.Jackpot = Jackpot;
            this.MaxCountWinners = MaxCountWinners;
            this.DelayBeforeStart = DelayBeforeStart;
            this.Duration = Duration;
            this.Criterions = Criterions;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, IsPrivate);
			flag = BooleanByteWrapper.SetFlag(1, flag, IsForGuild);
			flag = BooleanByteWrapper.SetFlag(2, flag, IsForAlliance);
			flag = BooleanByteWrapper.SetFlag(3, flag, NeedNotifications);
			writer.WriteByte(flag);
            writer.WriteVarUhLong(SubscriptionFee);
            writer.WriteVarUhLong(Jackpot);
            writer.WriteUnsignedShort(MaxCountWinners);
            writer.WriteUnsignedInt(DelayBeforeStart);
            writer.WriteUnsignedInt(Duration);
			writer.WriteShort((short)Criterions.Count);
			foreach (var x in Criterions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			IsPrivate = BooleanByteWrapper.GetFlag(flag, 0);;
			IsForGuild = BooleanByteWrapper.GetFlag(flag, 1);;
			IsForAlliance = BooleanByteWrapper.GetFlag(flag, 2);;
			NeedNotifications = BooleanByteWrapper.GetFlag(flag, 3);;
            SubscriptionFee = reader.ReadVarUhLong();
            Jackpot = reader.ReadVarUhLong();
            MaxCountWinners = reader.ReadUnsignedShort();
            DelayBeforeStart = reader.ReadUnsignedInt();
            Duration = reader.ReadUnsignedInt();
            var CriterionsCount = reader.ReadShort();
            Criterions = new List<DareCriteria>();
            for (var i = 0; i < CriterionsCount; i++)
            {
                var objectToAdd = new DareCriteria();
                objectToAdd.Deserialize(reader);
                Criterions.Add(objectToAdd);
            }
        }
    }
}
