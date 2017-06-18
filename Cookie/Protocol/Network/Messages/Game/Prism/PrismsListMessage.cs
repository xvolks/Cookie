namespace Cookie.Protocol.Network.Messages.Game.Prism
{
    using Cookie.Protocol.Network.Types.Game.Prism;
    using Cookie.IO;
    using System.Collections.Generic;

    public class PrismsListMessage : NetworkMessage
    {

        public const uint ProtocolId = 6440;

        public override uint MessageID => ProtocolId;

        private List<PrismSubareaEmptyInfo> _mPrisms;

        public virtual List<PrismSubareaEmptyInfo> Prisms
        {
            get => _mPrisms;
            set => _mPrisms = value;
        }

        public PrismsListMessage(List<PrismSubareaEmptyInfo> prisms)
        {
            _mPrisms = prisms;
        }

        public PrismsListMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(_mPrisms.Count)));
            int prismsIndex;
            for (prismsIndex = 0; (prismsIndex < _mPrisms.Count); prismsIndex = (prismsIndex + 1))
            {
                var objectToSend = _mPrisms[prismsIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            _mPrisms = new List<PrismSubareaEmptyInfo>();
            var loc2 = reader.ReadUShort();
            for (var loc3 = 0; loc3 < loc2; loc3++)
            {
                var loc4 = reader.ReadUShort();
                var loc5 = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>((short)loc4);
                loc5.Deserialize(reader);
                _mPrisms.Add(loc5);
            }
        }
    }
}