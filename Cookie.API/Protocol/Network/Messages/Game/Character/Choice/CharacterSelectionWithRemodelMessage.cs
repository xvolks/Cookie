using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
    {
        public new const ushort ProtocolId = 6549;

        public CharacterSelectionWithRemodelMessage(RemodelingInformation remodel)
        {
            Remodel = remodel;
        }

        public CharacterSelectionWithRemodelMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public RemodelingInformation Remodel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Remodel.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Remodel = new RemodelingInformation();
            Remodel.Deserialize(reader);
        }
    }
}