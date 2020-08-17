using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public new const ushort ProtocolId = 6215;

        public GameFightResumeWithSlavesMessage(List<GameFightResumeSlaveInfo> slavesInfo)
        {
            SlavesInfo = slavesInfo;
        }

        public GameFightResumeWithSlavesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<GameFightResumeSlaveInfo> SlavesInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) SlavesInfo.Count);
            for (var slavesInfoIndex = 0; slavesInfoIndex < SlavesInfo.Count; slavesInfoIndex++)
            {
                var objectToSend = SlavesInfo[slavesInfoIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var slavesInfoCount = reader.ReadUShort();
            SlavesInfo = new List<GameFightResumeSlaveInfo>();
            for (var slavesInfoIndex = 0; slavesInfoIndex < slavesInfoCount; slavesInfoIndex++)
            {
                var objectToAdd = new GameFightResumeSlaveInfo();
                objectToAdd.Deserialize(reader);
                SlavesInfo.Add(objectToAdd);
            }
        }
    }
}