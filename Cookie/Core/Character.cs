using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Core.Pathmanager;
using Cookie.API.Datacenter;
using Cookie.API.Game.Achievement;
using Cookie.API.Game.Alliance;
using Cookie.API.Game.BidHouse;
using Cookie.API.Game.Chat;
using Cookie.API.Game.Fight;
using Cookie.API.Game.Friend;
using Cookie.API.Game.Guild;
using Cookie.API.Game.Inventory;
using Cookie.API.Game.Jobs;
using Cookie.API.Game.Map;
using Cookie.API.Game.Party;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Character.Choice;
using Cookie.API.Protocol.Network.Messages.Game.Character.Creation;
using Cookie.API.Protocol.Network.Messages.Game.Character.Deletion;
using Cookie.API.Protocol.Network.Messages.Game.Character.Stats;
using Cookie.API.Protocol.Network.Messages.Game.Chat.Channel;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest;
using Cookie.API.Protocol.Network.Messages.Game.Friend;
using Cookie.API.Protocol.Network.Messages.Game.Initialization;
using Cookie.API.Protocol.Network.Messages.Security;
using Cookie.API.Protocol.Network.Types.Game.Character.Characteristic;
using Cookie.API.Protocol.Network.Types.Game.Character.Restriction;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core.Pathmanager;
using Cookie.Game.Alliance;
using Cookie.Game.BidHouse;
using Cookie.Game.Chat;
using Cookie.Game.Fight;
using Cookie.Game.Friend;
using Cookie.Game.Guild;
using Cookie.Game.Inventory;
using Cookie.Game.Jobs;
using Cookie.Game.Map;
using Cookie.Game.Party;
using Achievement = Cookie.Game.Achievement.Achievement;

namespace Cookie.Core
{
    public class Character : ICharacter
    {
        public Character(IAccount account)
        {
            Account = account;
            Stats = new CharacterCharacteristicsInformations();
            Look = new EntityLook();
            Restrictions = new ActorRestrictionsInformations();
            Spells = new List<SpellItem>();
            Status = CharacterStatus.Disconnected;
            Jobs = new List<JobExperience>();
            GatherManager = new GatherManager(Account);
            PathManager = new PathManager(Account);

            Achievement = new Achievement(Account);
            Alliance = new Alliance(Account);
            BidHouse = new BidHouse(Account);
            Chat = new Chat(Account);
            Map = new Map(Account);
            Fight = new Fight(Account);
            Friend = new Friend(Account);
            Guild = new Guild(Account);
            Inventory = new Inventory(Account);
            Party = new Party(Account);

            #region Choice Handler

            account.Network.RegisterPacket<BasicCharactersListMessage>(HandleBasicCharactersListMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharactersListMessage>(HandleCharactersListMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterSelectedSuccessMessage>(HandleCharacterSelectedSuccessMessage,
                MessagePriority.VeryHigh);

            #endregion Choice Handler

            #region Creation Handler

            account.Network.RegisterPacket<CharacterCanBeCreatedResultMessage>(HandleCharacterCanBeCreatedResultMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterCreationResultMessage>(HandleCharacterCreationResultMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterNameSuggestionFailureMessage>(
                HandleCharacterNameSuggestionFailureMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterNameSuggestionSuccessMessage>(
                HandleCharacterNameSuggestionSuccessMessage, MessagePriority.VeryHigh);

            #endregion Creation Handler

            #region Deletion Handler

            account.Network.RegisterPacket<CharacterDeletionErrorMessage>(HandleCharacterDeletionErrorMessage,
                MessagePriority.VeryHigh);

            #endregion Deletion Handler

            #region Stats Handler

            account.Network.RegisterPacket<CharacterStatsListMessage>(HandleCharacterStatsListMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterExperienceGainMessage>(HandleCharacterExperienceGainMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterLevelUpInformationMessage>(HandleCharacterLevelUpInformationMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CharacterLevelUpMessage>(HandleCharacterLevelUpMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<LifePointsRegenEndMessage>(HandleLifePointsRegenEndMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<UpdateLifePointsMessage>(HandleUpdateLifePointsMessage,
                MessagePriority.VeryHigh);

            #endregion Stats Handler

            #region Initialization Handler

            account.Network.RegisterPacket<CharacterLoadingCompleteMessage>(HandleCharacterLoadingCompleteMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<OnConnectionEventMessage>(HandleOnConnectionEventMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<SetCharacterRestrictionsMessage>(HandleSetCharacterRestrictionsMessage,
                MessagePriority.VeryHigh);

            #endregion Initialization Handler

            Account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(
                HandleMapComplementaryInformationsDataMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<GameContextRefreshEntityLookMessage>(
                HandleGameContextRefreshEntityLookMessage, MessagePriority.Normal);
        }

        private IAccount Account { get; }

        public ArtificialIntelligence Ia { get; set; }
        public IFight Fight { get; set; }

        public bool IsFirstConnection { get; set; }

        public CharacterStatus Status { get; set; }

        public double Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool Sex { get; set; }
        public CharacterCharacteristicsInformations Stats { get; set; }
        public EntityLook Look { get; set; }

        public BreedEnum Breed { get; set; }

        public int LifePercentage => (int) (Stats.LifePoints / (double) Stats.MaxLifePoints * 100);
        public int WeightPercentage => (int) (Weight / (double) MaxWeight * 100);
        public int EnergyPercentage => (int) (Stats.EnergyPoints / (double) Stats.MaxEnergyPoints * 100);
        public int ExperiencePercentage => (int) (Stats.Experience / (double) Stats.ExperienceNextLevelFloor * 100);

        public int CellId { get; set; }
        public int MapId { get; set; }

        public uint Weight { get; set; }
        public uint MaxWeight { get; set; }

        public ActorRestrictionsInformations Restrictions { get; set; }

        public IAchievement Achievement { get; set; }
        public IAlliance Alliance { get; set; }
        public IBidHouse BidHouse { get; set; }
        public IChat Chat { get; set; }
        public IMap Map { get; set; }
        public IFriend Friend { get; set; }
        public IGuild Guild { get; set; }
        public IInventory Inventory { get; set; }
        public IParty Party { get; set; }
        public List<SpellItem> Spells { get; set; }
        public List<JobExperience> Jobs { get; set; }
        public IGatherManager GatherManager { get; set; }
        public IPathManager PathManager { get; set; }

        public string GetSkinUrl(string mode, int orientation, int width, int height, int zoom)
        {
            var look = Look;
            var text = "http://staticns.ankama.com/dofus/renderer/look/7";
            text += "b3";
            var num = 0;
            var array = look.BonesId.ToString().ToCharArray();
            var array2 = array;
            foreach (var c in array2)
            {
                var num2 = num;
                num = num2 + 1;
                text += c.ToString();
                var flag = num >= array.Length;
                if (flag)
                    text += "7";
                else
                    text += "3";
            }
            var num3 = 0;
            var num4 = 0;
            foreach (var current in look.Skins)
            {
                var num2 = num3;
                num3 = num2 + 1;
                text += "c3";
                var array3 = current.ToString().ToCharArray();
                var array4 = array3;
                foreach (var c2 in array4)
                {
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c2.ToString();
                    var flag2 = num4 >= array3.Length && num3 < look.Skins.Count;
                    if (flag2)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        var flag3 = num4 < array3.Length && num3 <= look.Skins.Count;
                        if (flag3)
                            text += "3";
                    }
                }
                var flag4 = num3 >= look.Skins.Count;
                if (flag4)
                    text += "7";
            }
            var num5 = 0;
            foreach (var current2 in look.IndexedColors)
            {
                var num2 = num5;
                num5 = num2 + 1;
                text = string.Concat(text, "c3", num5, "3d3");
                num4 = 0;
                var array5 = current2.ToString().ToCharArray();
                var array6 = array5;
                foreach (var c3 in array6)
                {
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c3.ToString();
                    var flag5 = num4 >= array5.Length && num5 < look.IndexedColors.Count;
                    if (flag5)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        var flag6 = num4 < array5.Length && num5 <= look.IndexedColors.Count;
                        if (flag6)
                            text += "3";
                    }
                }
                var flag7 = num5 >= look.IndexedColors.Count;
                if (flag7)
                    text += "7";
            }
            var num6 = 0;
            foreach (var current3 in look.Scales)
            {
                var num2 = num6;
                num6 = num2 + 1;
                text += "c3";
                num4 = 0;
                var array7 = current3.ToString().ToCharArray();
                var array8 = array7;
                foreach (var c4 in array8)
                {
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c4.ToString();
                    var flag8 = num4 >= array7.Length && num6 < look.Scales.Count;
                    if (flag8)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        var flag9 = num4 < array7.Length && num6 <= look.Scales.Count;
                        if (flag9)
                            text += "3";
                    }
                }
                var flag10 = num6 >= look.Scales.Count;
                if (flag10)
                    text += "7";
            }
            text = string.Concat(text, "d/", mode, "/", orientation, "/", width, "_", height, "-", zoom, ".png");
            return text;
        }

        #region Deletion

        private void HandleCharacterDeletionErrorMessage(IAccount account, CharacterDeletionErrorMessage message)
        {
            Logger.Default.Log("Une erreur est survenue lors de la suppresion du personnae.");
        }

        #endregion Deletion

        private void HandleMapComplementaryInformationsDataMessage(IAccount account,
            MapComplementaryInformationsDataMessage message)
        {
            if (account.Character.IsFirstConnection)
            {
                account.Network.SendToServer(new GuidedModeQuitRequestMessage());
                account.Character.IsFirstConnection = false;
            }

            foreach (var actor in message.Actors)
            {
                if (actor.ContextualId != account.Character.Id) continue;
                account.Character.CellId = actor.Disposition.CellId;
            }
        }

        private void HandleGameContextRefreshEntityLookMessage(IAccount account,
            GameContextRefreshEntityLookMessage message)
        {
            if (message.ObjectId == Id)
                Look = message.Look;
        }

        #region Choice

        private void HandleBasicCharactersListMessage(IAccount account, BasicCharactersListMessage message)
        {
            if (message.Characters.Count == 0)
            {
                account.Network.SendToServer(new CharacterNameSuggestionRequestMessage());
            }
            else
            {
                var c = message.Characters[0];
                Logger.Default.Log($"Connection sur le personnage {c.Name}");
                account.Network.SendToServer(account.Character.IsFirstConnection == false
                    ? new CharacterSelectionMessage(c.ObjectId)
                    : new CharacterFirstSelectionMessage(false) {ObjectId = c.ObjectId});
            }
        }

        private void HandleCharactersListMessage(IAccount account, CharactersListMessage message)
        {
            if (message.Characters.Count == 0)
            {
                Logger.Default.Log("Pas de personnage.");
                Logger.Default.Log("Création du personnage en cours.");
                account.Network.SendToServer(new CharacterNameSuggestionRequestMessage());
            }
            else
            {
                var c = message.Characters[0];
                Logger.Default.Log("Connexion sur le personnage " + c.Name);

                account.Network.SendToServer(account.Character.IsFirstConnection == false
                    ? new CharacterSelectionMessage(c.ObjectId)
                    : new CharacterFirstSelectionMessage(false) {ObjectId = c.ObjectId});
            }
        }

        private void HandleCharacterSelectedSuccessMessage(IAccount account, CharacterSelectedSuccessMessage message)
        {
            account.Character.Level = message.Infos.Level;
            account.Character.Id = message.Infos.ObjectId;
            account.Character.Name = message.Infos.Name;
            account.Character.Sex = message.Infos.Sex;
            account.Character.Look = message.Infos.EntityLook;
            account.Character.Breed = (BreedEnum) message.Infos.Breed;
        }

        #endregion Choice

        #region Creation

        private void HandleCharacterCanBeCreatedResultMessage(IAccount account,
            CharacterCanBeCreatedResultMessage message)
        {
            // Si nous ne pouvons pas créer de personnages, nous arrêtons la fonction
            if (!message.YesYouCan) return;
            // Sinon, nous choisissons une classe au hasard
            var breedId = (sbyte) Randomize.GetRandomNumber(1, 18);
            // Nous récupérons les informations de la classe avec les D2O
            var breed = ObjectDataManager.Instance.Get<Breed>(breedId);
            // Nous récupérons la couleur de base de la classe, et nous faisons un léger random sur la couleur
            var breedColors = breed.MaleColors.Select(i => Randomize.GetRandomNumber((int) i - 80000, (int) i + 80000))
                .ToList();
            // On récupère la liste des cosmetics disponibles pour cette classe et ce sexe
            var headsList = ObjectDataManager.Instance.EnumerateObjects<Head>().ToList()
                .FindAll(h => h.Breed == breedId && h.Gender == 0);
            // Nous selectionnons au hasard un cosmetics dans la liste
            var head = headsList[Randomize.GetRandomNumber(0, 7)];
            //// Nous envoyons la requête pour créer le personnage
            var ccrm = new CharacterCreationRequestMessage(account.Character.Name, breedId, false, breedColors,
                (ushort) head.Id);
            account.Network.SendToServer(ccrm);
        }

        private void HandleCharacterCreationResultMessage(IAccount account, CharacterCreationResultMessage message)
        {
            switch ((CharacterCreationResultEnum) message.Result)
            {
                case CharacterCreationResultEnum.OK:
                    account.Character.IsFirstConnection = true;
                    break;

                case CharacterCreationResultEnum.ERR_NO_REASON:
                    break;

                case CharacterCreationResultEnum.ERR_INVALID_NAME:
                    Logger.Default.Log("Ce nom de personnage est invalide.", LogMessageType.Public);
                    break;

                case CharacterCreationResultEnum.ERR_NAME_ALREADY_EXISTS:
                    Logger.Default.Log("Ce nom de personnage est déjà pris.", LogMessageType.Public);
                    break;

                case CharacterCreationResultEnum.ERR_TOO_MANY_CHARACTERS:
                    Logger.Default.Log("Vous avez déjà atteint la limite de personnages disponible.",
                        LogMessageType.Public);
                    break;

                case CharacterCreationResultEnum.ERR_NOT_ALLOWED:
                    break;

                case CharacterCreationResultEnum.ERR_NEW_PLAYER_NOT_ALLOWED:
                    break;

                case CharacterCreationResultEnum.ERR_RESTRICED_ZONE:
                    break;

                case CharacterCreationResultEnum.ERR_INCONSISTENT_COMMUNITY:
                    break;
            }
        }

        private void HandleCharacterNameSuggestionFailureMessage(IAccount account,
            CharacterNameSuggestionFailureMessage message)
        {
            Logger.Default.Log($"{message.Reason}", LogMessageType.Public);
            account.Network.SendToServer(new CharacterNameSuggestionRequestMessage());
        }

        private void HandleCharacterNameSuggestionSuccessMessage(IAccount account,
            CharacterNameSuggestionSuccessMessage message)
        {
            Logger.Default.Log($"Pseudo Suggérer: {message.Suggestion}");
            account.Character.Name = message.Suggestion;

            var test = new CharacterCanBeCreatedRequestMessage();
            account.Network.SendToServer(test);
        }

        #endregion Creation

        #region Stats

        private void HandleCharacterStatsListMessage(IAccount account, CharacterStatsListMessage message)
        {
            account.Character.Stats = message.Stats;
        }

        private void HandleCharacterExperienceGainMessage(IAccount account, CharacterExperienceGainMessage message)
        {
            if (message.ExperienceCharacter != 0)
            {
                account.Character.Stats.Experience += message.ExperienceCharacter;
                Logger.Default.Log($"Vous avez gagné {message.ExperienceCharacter} points d'expérience.",
                    LogMessageType.Info);
            }
            if (message.ExperienceGuild != 0)
                Logger.Default.Log($"Votre guilde a gagné {message.ExperienceGuild} points d'expérience.",
                    LogMessageType.Info);
            if (message.ExperienceMount != 0)
                Logger.Default.Log($"Vous monture a gagné {message.ExperienceMount} points d'expérience.",
                    LogMessageType.Info);
        }

        private void HandleCharacterLevelUpInformationMessage(IAccount account,
            CharacterLevelUpInformationMessage message)
        {
            Logger.Default.Log($"{message.Name} viens de passer niveau {message.NewLevel}.", LogMessageType.Info);
        }

        private void HandleCharacterLevelUpMessage(IAccount account, CharacterLevelUpMessage message)
        {
            Logger.Default.Log($"Vous venez de passer niveau {message.NewLevel}.", LogMessageType.Info);
            account.Character.Level = message.NewLevel;
        }

        private void HandleLifePointsRegenEndMessage(IAccount account, LifePointsRegenEndMessage message)
        {
            account.Character.Stats.LifePoints = message.LifePoints;
            account.Character.Stats.MaxLifePoints = message.MaxLifePoints;
            if (message.LifePointsGained != 0)
                Logger.Default.Log($"Vous avez récupéré {message.LifePointsGained} points de vie.",
                    LogMessageType.Info);
        }

        private void HandleUpdateLifePointsMessage(IAccount account, UpdateLifePointsMessage message)
        {
            account.Character.Stats.LifePoints = message.LifePoints;
            account.Character.Stats.MaxLifePoints = message.MaxLifePoints;
        }

        #endregion Stats

        #region Initialization

        private void HandleCharacterLoadingCompleteMessage(IAccount account, CharacterLoadingCompleteMessage message)
        {
            account.Network.SendToServer(new FriendsGetListMessage());
            account.Network.SendToServer(new IgnoredGetListMessage());
            account.Network.SendToServer(new SpouseGetInformationsMessage());
            account.Network.SendToServer(new ClientKeyMessage(FlashKeyGenerator.GetRandomFlashKey(account.Nickname)));
            account.Network.SendToServer(new GameContextCreateRequestMessage());
            account.Network.SendToServer(new ChannelEnablingMessage(7, false));
        }

        private void HandleOnConnectionEventMessage(IAccount account, OnConnectionEventMessage message)
        {
            Logger.Default.Log("Connection Event Type: " + message.EventType + " | MessageID: " + message.MessageID,
                LogMessageType.Arena);
        }

        private void HandleSetCharacterRestrictionsMessage(IAccount account, SetCharacterRestrictionsMessage message)
        {
            account.Character.Restrictions = message.Restrictions;
        }

        #endregion Initialization
    }
}