using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Restriction;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class HumanInformations : NetworkType
    {
        public const ushort ProtocolId = 157;

        public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, List<HumanOption> options)
        {
            Restrictions = restrictions;
            Sex = sex;
            Options = options;
        }

        public HumanInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ActorRestrictionsInformations Restrictions { get; set; }
        public bool Sex { get; set; }
        public List<HumanOption> Options { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Restrictions.Serialize(writer);
            writer.WriteBoolean(Sex);
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
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
            Sex = reader.ReadBoolean();
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