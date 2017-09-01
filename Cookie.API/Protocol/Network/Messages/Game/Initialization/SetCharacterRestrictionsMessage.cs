using Cookie.API.Protocol.Network.Types.Game.Character.Restriction;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Initialization
{
    public class SetCharacterRestrictionsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 170;

        public SetCharacterRestrictionsMessage(double actorId, ActorRestrictionsInformations restrictions)
        {
            ActorId = actorId;
            Restrictions = restrictions;
        }

        public SetCharacterRestrictionsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double ActorId { get; set; }
        public ActorRestrictionsInformations Restrictions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ActorId);
            Restrictions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActorId = reader.ReadDouble();
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
        }
    }
}