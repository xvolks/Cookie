using Cookie.API.Core;
using Cookie.API.Game.Guild;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Guild;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Guild
{
    public class Guild : IGuild
    {
        public Guild(IAccount account)
        {
            account.Network.RegisterPacket<GuildMotdMessage>(HandleGuildMotdMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ChallengeFightJoinRefusedMessage>(HandleChallengeFightJoinRefusedMessage,
                MessagePriority.VeryHigh);
        }

        private void HandleGuildMotdMessage(IAccount account, GuildMotdMessage message)
        {
            Logger.Default.Log("Annonce de guilde : " + message.Content, LogMessageType.Guild);
        }

        private void HandleChallengeFightJoinRefusedMessage(IAccount account, ChallengeFightJoinRefusedMessage message)
        {
            switch ((FighterRefusedReasonEnum) message.Reason)
            {
                case FighterRefusedReasonEnum.CHALLENGE_FULL:
                    Logger.Default.Log("Partie pleine");
                    break;
                case FighterRefusedReasonEnum.AVA_ZONE:
                    Logger.Default.Log("Impossible d'agresser en zone de combat d'alliance");
                    break;
                case FighterRefusedReasonEnum.TEAM_FULL:
                    Logger.Default.Log("Equipe pleine.");
                    break;
                case FighterRefusedReasonEnum.WRONG_GUILD:
                    Logger.Default.Log("Votre guilde ne vous permet pas de faire cette action.");
                    break;
                case FighterRefusedReasonEnum.TOO_LATE:
                    Logger.Default.Log("Il est trop tard pour rejoindre ce combat.");
                    break;
                case FighterRefusedReasonEnum.MUTANT_REFUSED:
                    Logger.Default.Log("Action impossible lorsque vous êtes transformé en monstre.");
                    break;
                case FighterRefusedReasonEnum.WRONG_MAP:
                    Logger.Default.Log("Action impossible sur cette map.");
                    break;
                case FighterRefusedReasonEnum.JUST_RESPAWNED:
                    Logger.Default.Log("Impossible de rentrer en combat avec ce joueur car il n'est pas prêt.");
                    break;
                case FighterRefusedReasonEnum.IM_OCCUPIED:
                    Logger.Default.Log("Impossible de combatre car vous êtes occupé.");
                    break;
                case FighterRefusedReasonEnum.OPPONENT_OCCUPIED:
                    Logger.Default.Log("Impossible de combatre avec ce joueur car il est occupé.");
                    break;
                case FighterRefusedReasonEnum.MULTIACCOUNT_NOT_ALLOWED:
                    Logger.Default.Log("Vous ne pouvez pas rejoindre ce combat avec plus d'un compte.");
                    break;
                case FighterRefusedReasonEnum.INSUFFICIENT_RIGHTS:
                    Logger.Default.Log("Action impossible en raison des droits des deux joueurs.");
                    break;
                case FighterRefusedReasonEnum.MEMBER_ACCOUNT_NEEDED:
                    Logger.Default.Log("Action impossible car votre abonnement a expiré.");
                    break;
                case FighterRefusedReasonEnum.GUEST_ACCOUNT:
                    Logger.Default.Log("Action impossible en mode invité.");
                    break;
                case FighterRefusedReasonEnum.OPPONENT_NOT_MEMBER:
                    Logger.Default.Log("Action impossible car ce joueur n'a pas un compte membre.");
                    break;
                case FighterRefusedReasonEnum.TEAM_LIMITED_BY_MAINCHARACTER:
                    Logger.Default.Log("Impossible de rejoindre le combat (fermé ou limité au groupe.");
                    break;
                case FighterRefusedReasonEnum.GHOST_REFUSED:
                    Logger.Default.Log("Une fois mort, les rivalités des vivants paraissent vraiment insignifiantes.");
                    break;
                case FighterRefusedReasonEnum.RESTRICTED_ACCOUNT:
                    Logger.Default.Log("Le mode restreint est actif pour la session, cette action est impossible");
                    break;
            }
        }
    }
}