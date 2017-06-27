using System.Collections.Generic;
using Cookie.API.Game.Jobs;
using Cookie.API.Game.Map;
using Cookie.API.Game.Pathmanager;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Types.Game.Character.Characteristic;
using Cookie.API.Protocol.Network.Types.Game.Character.Restriction;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.Enums;

namespace Cookie.API.Core
{
    public interface ICharacter
    {
        /// <summary>
        ///     The actual status of the character
        /// </summary>
        CharacterStatus Status { get; set; }

        /// <summary>
        ///     Determine if this is his first connection or not
        /// </summary>
        bool IsFirstConnection { get; set; }

        /// <summary>
        ///     The character id
        /// </summary>
        ulong Id { get; set; }

        /// <summary>
        ///     The character name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     The character level
        /// </summary>
        int Level { get; set; }

        /// <summary>
        ///     The character gender
        /// </summary>
        bool Sex { get; set; }

        /// <summary>
        ///     The character Stats (include Kamas, etc)
        /// </summary>
        CharacterCharacteristicsInformations Stats { get; set; }

        /// <summary>
        ///     The character Look
        /// </summary>
        EntityLook Look { get; set; }

        /// <summary>
        ///     The character Breed
        /// </summary>
        BreedEnum Breed { get; set; }

        /// <summary>
        ///     The character life percentage
        /// </summary>
        int LifePercentage { get; }

        /// <summary>
        ///     The character weight percentage
        /// </summary>
        int WeightPercentage { get; }

        /// <summary>
        ///     The character energy percentage
        /// </summary>
        int EnergyPercentage { get; }

        /// <summary>
        ///     The character Experience percentage
        /// </summary>
        int ExperiencePercentage { get; }

        /// <summary>
        ///     The character actual cellid on the map
        /// </summary>
        int CellId { get; set; }

        /// <summary>
        ///     The character actual map id
        /// </summary>
        int MapId { get; set; }

        /// <summary>
        ///     The current weight of the character
        /// </summary>
        uint Weight { get; set; }

        /// <summary>
        ///     The maximum weight of the character
        /// </summary>
        uint MaxWeight { get; set; }

        /// <summary>
        ///     All character restrictions
        /// </summary>
        ActorRestrictionsInformations Restrictions { get; set; }

        /// <summary>
        ///     The character inventory
        /// </summary>
        List<ObjectItem> Inventory { get; set; }

        /// <summary>
        ///     The character spells
        /// </summary>
        List<SpellItem> Spells { get; set; }

        /// <summary>
        ///     The character jobs
        /// </summary>
        List<JobExperience> Jobs { get; set; }

        /// <summary>
        ///     Gather Manager
        /// </summary>
        IGatherManager GatherManager { get; set; }

        IPathManager PathManager { get; set; }

        /// <summary>
        ///     This method return the url string of the image of this character
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="orientation"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        string GetSkinUrl(string mode, int orientation, int width, int height, int zoom);
    }
}