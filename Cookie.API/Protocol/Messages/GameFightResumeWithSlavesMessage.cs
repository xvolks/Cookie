using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public new const ushort ProtocolId = 6215;

        public override ushort MessageID => ProtocolId;

        public List<GameFightResumeSlaveInfo> SlavesInfo { get; set; }
        public GameFightResumeWithSlavesMessage() { }

        public GameFightResumeWithSlavesMessage( List<GameFightResumeSlaveInfo> SlavesInfo ){
            this.SlavesInfo = SlavesInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)SlavesInfo.Count);
			foreach (var x in SlavesInfo)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var SlavesInfoCount = reader.ReadShort();
            SlavesInfo = new List<GameFightResumeSlaveInfo>();
            for (var i = 0; i < SlavesInfoCount; i++)
            {
                var objectToAdd = new GameFightResumeSlaveInfo();
                objectToAdd.Deserialize(reader);
                SlavesInfo.Add(objectToAdd);
            }
        }
    }
}
