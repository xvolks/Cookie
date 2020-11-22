using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanInformations : NetworkType
    {
        public const ushort ProtocolId = 157;

        public override ushort TypeID => ProtocolId;

        public ActorRestrictionsInformations Restrictions { get; set; }
        public bool Sex { get; set; }
        public List<HumanOption> Options { get; set; }
        public HumanInformations() { }

        public HumanInformations( ActorRestrictionsInformations Restrictions, bool Sex, List<HumanOption> Options ){
            this.Restrictions = Restrictions;
            this.Sex = Sex;
            this.Options = Options;
        }

        public override void Serialize(IDataWriter writer)
        {
            Restrictions.Serialize(writer);
            writer.WriteBoolean(Sex);
			writer.WriteShort((short)Options.Count);
			foreach (var x in Options)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
            Sex = reader.ReadBoolean();
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
