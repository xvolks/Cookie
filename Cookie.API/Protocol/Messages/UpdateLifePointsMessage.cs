using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class UpdateLifePointsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5658;

        public override ushort MessageID => ProtocolId;

        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public UpdateLifePointsMessage() { }

        public UpdateLifePointsMessage( uint LifePoints, uint MaxLifePoints ){
            this.LifePoints = LifePoints;
            this.MaxLifePoints = MaxLifePoints;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
        }

        public override void Deserialize(IDataReader reader)
        {
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
        }
    }
}
