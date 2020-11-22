using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightDispellableEffectExtendedInformations : NetworkType
    {
        public const ushort ProtocolId = 208;

        public override ushort TypeID => ProtocolId;

        public ushort ActionId { get; set; }
        public double SourceId { get; set; }
        public AbstractFightDispellableEffect Effect { get; set; }
        public FightDispellableEffectExtendedInformations() { }

        public FightDispellableEffectExtendedInformations( ushort ActionId, double SourceId, AbstractFightDispellableEffect Effect ){
            this.ActionId = ActionId;
            this.SourceId = SourceId;
            this.Effect = Effect;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
            writer.WriteDouble(SourceId);
            Effect.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
            SourceId = reader.ReadDouble();
            Effect = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Effect.Deserialize(reader);
        }
    }
}
