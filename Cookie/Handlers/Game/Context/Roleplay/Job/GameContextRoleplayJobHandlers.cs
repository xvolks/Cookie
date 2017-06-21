using Cookie.Core;
using Cookie.Gamedata;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.I18n;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Job;

namespace Cookie.Handlers.Game.Context.Roleplay.Job
{
    public class GameContextRoleplayJobHandlers
    {
        [MessageHandler(JobDescriptionMessage.ProtocolId)]
        private void JobDescriptionMessageHandler(DofusClient client, JobDescriptionMessage message)
        {
            //
        }

        [MessageHandler(JobExperienceMultiUpdateMessage.ProtocolId)]
        private void JobExperienceMultiUpdateMessageHandler(DofusClient client, JobExperienceMultiUpdateMessage message)
        {
            message.ExperiencesUpdate.ForEach(Job =>
            {
                client.Logger.Log(D2OParsing.GetJobName(Job.JobId) + " | Level: " + Job.JobLevel + " | Exp: " + Job.JobXP);
            });
        }
        [MessageHandler(JobLevelUpMessage.ProtocolId)]
        private void JobLevelUpMessageHandler(DofusClient client, JobLevelUpMessage message)
        {
            var jobName = D2OParsing.GetJobName(message.JobsDescription.JobId);
            client.Logger.Log("Votre métier de " + jobName + " vient de passer niveau " + message.NewLevel );
        }
        [MessageHandler(JobCrafterDirectorySettingsMessage.ProtocolId)]
        private void JobCrafterDirectorySettingsMessageHandler(DofusClient client,
            JobCrafterDirectorySettingsMessage message)
        {
            //
        }

        [MessageHandler(JobExperienceUpdateMessage.ProtocolId)]
        private void JobExperienceUpdateMessageHandler(DofusClient client, JobExperienceUpdateMessage message)
        {
            client.Logger.Log(
                $"{I18nDataManager.Instance.ReadText(ObjectDataManager.Instance.Get<Datacenter.Job>(message.ExperiencesUpdate.JobId).NameId)} | Level: {message.ExperiencesUpdate.JobLevel} | Exp: {message.ExperiencesUpdate.JobXP}");
        }
    }
}