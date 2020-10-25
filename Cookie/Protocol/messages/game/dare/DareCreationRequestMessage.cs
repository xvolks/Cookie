using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DareCreationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6665;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsPrivate = false;
        public bool IsForGuild = false;
        public bool IsForAlliance = false;
        public bool NeedNotifications = false;
        public long SubscriptionFee = 0;
        public long Jackpot = 0;
        public short MaxCountWinners = 0;
        public uint DelayBeforeStart = 0;
        public uint Duration = 0;
        public List<DareCriteria> Criterions;

        public DareCreationRequestMessage()
        {
        }

        public DareCreationRequestMessage(
            bool isPrivate,
            bool isForGuild,
            bool isForAlliance,
            bool needNotifications,
            long subscriptionFee,
            long jackpot,
            short maxCountWinners,
            uint delayBeforeStart,
            uint duration,
            List<DareCriteria> criterions
        )
        {
            IsPrivate = isPrivate;
            IsForGuild = isForGuild;
            IsForAlliance = isForAlliance;
            NeedNotifications = needNotifications;
            SubscriptionFee = subscriptionFee;
            Jackpot = jackpot;
            MaxCountWinners = maxCountWinners;
            DelayBeforeStart = delayBeforeStart;
            Duration = duration;
            Criterions = criterions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, IsPrivate);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsForGuild);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, IsForAlliance);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, NeedNotifications);
            writer.WriteByte(box0);
            writer.WriteVarLong(SubscriptionFee);
            writer.WriteVarLong(Jackpot);
            writer.WriteShort(MaxCountWinners);
            writer.WriteUInt(DelayBeforeStart);
            writer.WriteUInt(Duration);
            writer.WriteShort((short)Criterions.Count());
            foreach (var current in Criterions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            IsPrivate = BooleanByteWrapper.GetFlag(box0, 1);
            IsForGuild = BooleanByteWrapper.GetFlag(box0, 2);
            IsForAlliance = BooleanByteWrapper.GetFlag(box0, 3);
            NeedNotifications = BooleanByteWrapper.GetFlag(box0, 4);
            SubscriptionFee = reader.ReadVarLong();
            Jackpot = reader.ReadVarLong();
            MaxCountWinners = reader.ReadShort();
            DelayBeforeStart = reader.ReadUInt();
            Duration = reader.ReadUInt();
            var countCriterions = reader.ReadShort();
            Criterions = new List<DareCriteria>();
            for (short i = 0; i < countCriterions; i++)
            {
                DareCriteria type = new DareCriteria();
                type.Deserialize(reader);
                Criterions.Add(type);
            }
        }
    }
}