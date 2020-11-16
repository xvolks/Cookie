using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
    {
        public new const ushort ProtocolId = 129;

        public override ushort TypeID => ProtocolId;

        public sbyte SellType { get; set; }
        public List<HumanOption> Options { get; set; }
        public GameRolePlayMerchantInformations() { }

        public GameRolePlayMerchantInformations( sbyte SellType, List<HumanOption> Options ){
            this.SellType = SellType;
            this.Options = Options;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(SellType);
			writer.WriteShort((short)Options.Count);
			foreach (var x in Options)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SellType = reader.ReadSByte();
            var OptionsCount = reader.ReadShort();
            Options = new List<HumanOption>();
            for (var i = 0; i < OptionsCount; i++)
            {
                HumanOption objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Options.Add(objectToAdd);
            }
        }
    }
}
