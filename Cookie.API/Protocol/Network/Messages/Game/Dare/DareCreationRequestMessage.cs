using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Dare;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareCreationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6665;

        public DareCreationRequestMessage(bool isPrivate, bool isForGuild, bool isForAlliance, bool needNotifications,
            ulong subscriptionFee, ulong jackpot, ushort maxCountWinners, uint delayBeforeStart, uint duration,
            List<DareCriteria> criterions)
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

        public DareCreationRequestMessage()
        {
        }

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
            writer.WriteUShort(MaxCountWinners);
            writer.WriteUInt(DelayBeforeStart);
            writer.WriteUInt(Duration);
            writer.WriteShort((short) Criterions.Count);
            for (var criterionsIndex = 0; criterionsIndex < Criterions.Count; criterionsIndex++)
            {
                var objectToSend = Criterions[criterionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            IsPrivate = BooleanByteWrapper.GetFlag(flag, 0);
            IsForGuild = BooleanByteWrapper.GetFlag(flag, 1);
            IsForAlliance = BooleanByteWrapper.GetFlag(flag, 2);
            NeedNotifications = BooleanByteWrapper.GetFlag(flag, 3);
            SubscriptionFee = reader.ReadVarUhLong();
            Jackpot = reader.ReadVarUhLong();
            MaxCountWinners = reader.ReadUShort();
            DelayBeforeStart = reader.ReadUInt();
            Duration = reader.ReadUInt();
            var criterionsCount = reader.ReadUShort();
            Criterions = new List<DareCriteria>();
            for (var criterionsIndex = 0; criterionsIndex < criterionsCount; criterionsIndex++)
            {
                var objectToAdd = new DareCriteria();
                objectToAdd.Deserialize(reader);
                Criterions.Add(objectToAdd);
            }
        }
    }
}