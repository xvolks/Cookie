using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTriggeredEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 210;

        public override ushort TypeID => ProtocolId;

        public int Param1 { get; set; }
        public int Param2 { get; set; }
        public int Param3 { get; set; }
        public short Delay { get; set; }
        public FightTriggeredEffect() { }

        public FightTriggeredEffect( int Param1, int Param2, int Param3, short Delay ){
            this.Param1 = Param1;
            this.Param2 = Param2;
            this.Param3 = Param3;
            this.Delay = Delay;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Param1);
            writer.WriteInt(Param2);
            writer.WriteInt(Param3);
            writer.WriteShort(Delay);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Param1 = reader.ReadInt();
            Param2 = reader.ReadInt();
            Param3 = reader.ReadInt();
            Delay = reader.ReadShort();
        }
    }
}
