using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class HumanInformations : NetworkType
    {
        public const short ProtocolId = 157;
        public override short TypeId { get { return ProtocolId; } }

        public ActorRestrictionsInformations Restrictions;
        public bool Sex = false;
        public List<HumanOption> Options;

        public HumanInformations()
        {
        }

        public HumanInformations(
            ActorRestrictionsInformations restrictions,
            bool sex,
            List<HumanOption> options
        )
        {
            Restrictions = restrictions;
            Sex = sex;
            Options = options;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Restrictions.Serialize(writer);
            writer.WriteBoolean(Sex);
            writer.WriteShort((short)Options.Count());
            foreach (var current in Options)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
            Sex = reader.ReadBoolean();
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