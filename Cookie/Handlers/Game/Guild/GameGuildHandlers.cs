using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Guild;

namespace Cookie.Handlers.Game.Guild
{
    public class GameGuildHandlers
    {
        [MessageHandler(GuildMembershipMessage.ProtocolId)]
        private void GuildMembershipMessageHandler(DofusClient client, GuildMembershipMessage message)
        {
            //
        }

        [MessageHandler(GuildInformationsGeneralMessage.ProtocolId)]
        private void GuildInformationsGeneralMessageHandler(DofusClient client, GuildInformationsGeneralMessage message)
        {
            //
        }

        [MessageHandler(GuildInformationsMembersMessage.ProtocolId)]
        private void GuildInformationsMembersMessageHandler(DofusClient client, GuildInformationsMembersMessage message)
        {
            //
        }

        [MessageHandler(GuildMemberOnlineStatusMessage.ProtocolId)]
        private void GuildMemberOnlineStatusMessageHandler(DofusClient client, GuildMemberOnlineStatusMessage message)
        {
            //
        }

        [MessageHandler(GuildMotdMessage.ProtocolId)]
        private void GuildMotdMessageHandler(DofusClient client, GuildMotdMessage message)
        {
            client.Logger.Log("Annonce de guilde : " + message.Content, LogMessageType.Guild);
        }

        [MessageHandler(ChallengeFightJoinRefusedMessage.ProtocolId)]
        private void ChallengeFightJoinRefusedMessageHandler(DofusClient client,
            ChallengeFightJoinRefusedMessage message)
        {
            switch ((FighterRefusedReasonEnum) message.Reason)
            {
                case FighterRefusedReasonEnum.CHALLENGE_FULL:
                    client.Logger.Log("Partie pleine");
                    break;
                case FighterRefusedReasonEnum.AVA_ZONE:
                    client.Logger.Log("Impossible d'agresser en zone de combat d'alliance");
                    break;
                case FighterRefusedReasonEnum.TEAM_FULL:
                    client.Logger.Log("Equipe pleine.");
                    break;
                case FighterRefusedReasonEnum.WRONG_GUILD:
                    client.Logger.Log("Votre guilde ne vous permet pas de faire cette action.");
                    break;
                case FighterRefusedReasonEnum.TOO_LATE:
                    client.Logger.Log("Il est trop tard pour rejoindre ce combat.");
                    break;
                case FighterRefusedReasonEnum.MUTANT_REFUSED:
                    client.Logger.Log("Action impossible lorsque vous êtes transformé en monstre.");
                    break;
                case FighterRefusedReasonEnum.WRONG_MAP:
                    client.Logger.Log("Action impossible sur cette map.");
                    break;
                case FighterRefusedReasonEnum.JUST_RESPAWNED:
                    client.Logger.Log("Impossible de rentrer en combat avec ce joueur car il n'est pas prêt.");
                    break;
                case FighterRefusedReasonEnum.IM_OCCUPIED:
                    client.Logger.Log("Impossible de combatre car vous êtes occupé.");
                    break;
                case FighterRefusedReasonEnum.OPPONENT_OCCUPIED:
                    client.Logger.Log("Impossible de combatre avec ce joueur car il est occupé.");
                    break;
                case FighterRefusedReasonEnum.MULTIACCOUNT_NOT_ALLOWED:
                    client.Logger.Log("Vous ne pouvez pas rejoindre ce combat avec plus d'un compte.");
                    break;
                case FighterRefusedReasonEnum.INSUFFICIENT_RIGHTS:
                    client.Logger.Log("Action impossible en raison des droits des deux joueurs.");
                    break;
                case FighterRefusedReasonEnum.MEMBER_ACCOUNT_NEEDED:
                    client.Logger.Log("Action impossible car votre abonnement a expiré.");
                    break;
                case FighterRefusedReasonEnum.GUEST_ACCOUNT:
                    client.Logger.Log("Action impossible en mode invité.");
                    break;
                case FighterRefusedReasonEnum.OPPONENT_NOT_MEMBER:
                    client.Logger.Log("Action impossible car ce joueur n'a pas un compte membre.");
                    break;
                case FighterRefusedReasonEnum.TEAM_LIMITED_BY_MAINCHARACTER:
                    client.Logger.Log("Impossible de rejoindre le combat (fermé ou limité au groupe.");
                    break;
                case FighterRefusedReasonEnum.GHOST_REFUSED:
                    client.Logger.Log("Une fois mort, les rivalités des vivants paraissent vraiment insignifiantes.");
                    break;
                case FighterRefusedReasonEnum.RESTRICTED_ACCOUNT:
                    client.Logger.Log("Le mode restreint est actif pour la session, cette action est impossible");
                    break;
                default:
                    break;
            }
        }
    }
}