using System.Collections.Generic;
using Cookie.API.Game.Map;
using Cookie.API.Protocol.Network.Types.Game.Character.Characteristic;
using Cookie.API.Protocol.Network.Types.Game.Character.Restriction;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.Utils.Enums;

namespace Cookie.API.Core
{
    public interface ICharacter
    {
        bool IsFirstConnection { get; set; }
        CharacterStatus Status { get; set; }

        ulong Id { get; set; }
        string Name { get; set; }
        int Level { get; set; }
        bool Sex { get; set; }
        CharacterCharacteristicsInformations Stats { get; set; }
        EntityLook Look { get; set; }
        sbyte Breed { get; set; }
        IMap Map { get; set; }

        int LifePercentage { get; }
        int WeightPercentage { get; }
        int EnergyPercentage { get; }
        int XPPercentage { get; }

        int CellId { get; set; }
        int MapId { get; set; }

        uint Weight { get; set; }
        uint MaxWeight { get; set; }

        ActorRestrictionsInformations Restrictions { get; set; }

        List<ObjectItem> Inventory { get; set; }
        List<SpellItem> Spells { get; set; }
        List<JobExperience> Jobs { get; set; }
    }
}
