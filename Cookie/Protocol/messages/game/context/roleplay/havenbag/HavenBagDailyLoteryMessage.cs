using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HavenBagDailyLoteryMessage : NetworkMessage
    {
        public const uint ProtocolId = 6644;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ReturnType = 0;
        public string GameActionId;

        public HavenBagDailyLoteryMessage()
        {
        }

        public HavenBagDailyLoteryMessage(
            byte returnType,
            string gameActionId
        )
        {
            ReturnType = returnType;
            GameActionId = gameActionId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ReturnType);
            writer.WriteUTF(GameActionId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ReturnType = reader.ReadByte();
            GameActionId = reader.ReadUTF();
        }
    }
}