using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
    {
        public new const short ProtocolId = 129;
        public override short TypeId { get { return ProtocolId; } }

        public byte SellType = 0;
        public List<HumanOption> Options;

        public GameRolePlayMerchantInformations(): base()
        {
        }

        public GameRolePlayMerchantInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            string name,
            byte sellType,
            List<HumanOption> options
        ): base(
            contextualId,
            look,
            disposition,
            name
        )
        {
            SellType = sellType;
            Options = options;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(SellType);
            writer.WriteShort((short)Options.Count());
            foreach (var current in Options)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SellType = reader.ReadByte();
            var countOptions = reader.ReadShort();
            Options = new List<HumanOption>();
            for (short i = 0; i < countOptions; i++)
            {
                var optionstypeId = reader.ReadShort();
                HumanOption type = new HumanOption();
                type.Deserialize(reader);
                Options.Add(type);
            }
        }
    }
}