using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
    {
        public new const ushort ProtocolId = 129;

        public GameRolePlayMerchantInformations(byte sellType, List<HumanOption> options)
        {
            SellType = sellType;
            Options = options;
        }

        public GameRolePlayMerchantInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte SellType { get; set; }
        public List<HumanOption> Options { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(SellType);
            writer.WriteShort((short) Options.Count);
            for (var optionsIndex = 0; optionsIndex < Options.Count; optionsIndex++)
            {
                var objectToSend = Options[optionsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SellType = reader.ReadByte();
            var optionsCount = reader.ReadUShort();
            Options = new List<HumanOption>();
            for (var optionsIndex = 0; optionsIndex < optionsCount; optionsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Options.Add(objectToAdd);
            }
        }
    }
}