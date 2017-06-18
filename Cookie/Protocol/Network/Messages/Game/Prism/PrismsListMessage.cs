namespace Cookie.Protocol.Network.Messages.Game.Prism
{
    using Cookie.Protocol.Network.Types.Game.Prism;
    using Cookie.IO;
    using System.Collections.Generic;

    public class PrismsListMessage : NetworkMessage
    {

        public const uint ProtocolId = 6440;

        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }

        private List<PrismSubareaEmptyInfo> m_prisms;

        public virtual List<PrismSubareaEmptyInfo> Prisms
        {
            get
            {
                return m_prisms;
            }
            set
            {
                m_prisms = value;
            }
        }

        public PrismsListMessage(List<PrismSubareaEmptyInfo> prisms)
        {
            m_prisms = prisms;
        }

        public PrismsListMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_prisms.Count)));
            int prismsIndex;
            for (prismsIndex = 0; (prismsIndex < m_prisms.Count); prismsIndex = (prismsIndex + 1))
            {
                var objectToSend = m_prisms[prismsIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            m_prisms = new List<PrismSubareaEmptyInfo>();
            var loc2 = reader.ReadUShort();
            for (var loc3 = 0; loc3 < loc2; loc3++)
            {
                var loc4 = reader.ReadUShort();
                var loc5 = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>((short)loc4);
                loc5.Deserialize(reader);
                m_prisms.Add(loc5);
            }
        }
    }
}