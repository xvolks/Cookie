using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachStateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6799;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations Owner;
        public List<ObjectEffectInteger> Bonuses;
        public int Bugdet = 0;
        public bool Saved = false;

        public BreachStateMessage()
        {
        }

        public BreachStateMessage(
            CharacterMinimalInformations owner,
            List<ObjectEffectInteger> bonuses,
            int bugdet,
            bool saved
        )
        {
            Owner = owner;
            Bonuses = bonuses;
            Bugdet = bugdet;
            Saved = saved;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Owner.Serialize(writer);
            writer.WriteShort((short)Bonuses.Count());
            foreach (var current in Bonuses)
            {
                current.Serialize(writer);
            }
            writer.WriteVarInt(Bugdet);
            writer.WriteBoolean(Saved);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Owner = new CharacterMinimalInformations();
            Owner.Deserialize(reader);
            var countBonuses = reader.ReadShort();
            Bonuses = new List<ObjectEffectInteger>();
            for (short i = 0; i < countBonuses; i++)
            {
                ObjectEffectInteger type = new ObjectEffectInteger();
                type.Deserialize(reader);
                Bonuses.Add(type);
            }
            Bugdet = reader.ReadVarInt();
            Saved = reader.ReadBoolean();
        }
    }
}