//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using Cookie.Protocol.Network.Messages;
    using Cookie.Protocol.Network.Types;
    using Cookie.IO;
    
    
    public class FightStartingPositions : NetworkType
    {
        
        public const short ProtocolId = 513;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<ushort> m_positionsForChallengers;
        
        public virtual List<ushort> PositionsForChallengers
        {
            get
            {
                return m_positionsForChallengers;
            }
            set
            {
                m_positionsForChallengers = value;
            }
        }
        
        private List<ushort> m_positionsForDefenders;
        
        public virtual List<ushort> PositionsForDefenders
        {
            get
            {
                return m_positionsForDefenders;
            }
            set
            {
                m_positionsForDefenders = value;
            }
        }
        
        public FightStartingPositions(List<ushort> positionsForChallengers, List<ushort> positionsForDefenders)
        {
            m_positionsForChallengers = positionsForChallengers;
            m_positionsForDefenders = positionsForDefenders;
        }
        
        public FightStartingPositions()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_positionsForChallengers.Count)));
            int positionsForChallengersIndex;
            for (positionsForChallengersIndex = 0; (positionsForChallengersIndex < m_positionsForChallengers.Count); positionsForChallengersIndex = (positionsForChallengersIndex + 1))
            {
                writer.WriteVarUhShort(m_positionsForChallengers[positionsForChallengersIndex]);
            }
            writer.WriteShort(((short)(m_positionsForDefenders.Count)));
            int positionsForDefendersIndex;
            for (positionsForDefendersIndex = 0; (positionsForDefendersIndex < m_positionsForDefenders.Count); positionsForDefendersIndex = (positionsForDefendersIndex + 1))
            {
                writer.WriteVarUhShort(m_positionsForDefenders[positionsForDefendersIndex]);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int positionsForChallengersCount = reader.ReadUShort();
            int positionsForChallengersIndex;
            m_positionsForChallengers = new System.Collections.Generic.List<ushort>();
            for (positionsForChallengersIndex = 0; (positionsForChallengersIndex < positionsForChallengersCount); positionsForChallengersIndex = (positionsForChallengersIndex + 1))
            {
                m_positionsForChallengers.Add(reader.ReadVarUhShort());
            }
            int positionsForDefendersCount = reader.ReadUShort();
            int positionsForDefendersIndex;
            m_positionsForDefenders = new System.Collections.Generic.List<ushort>();
            for (positionsForDefendersIndex = 0; (positionsForDefendersIndex < positionsForDefendersCount); positionsForDefendersIndex = (positionsForDefendersIndex + 1))
            {
                m_positionsForDefenders.Add(reader.ReadVarUhShort());
            }
        }
    }
}
