using Cookie.Core;
using Cookie.Gamedata;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job;

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
            client.Account.Character.Jobs = message.ExperiencesUpdate;
        }

        [MessageHandler(JobLevelUpMessage.ProtocolId)]
        private void JobLevelUpMessageHandler(DofusClient client, JobLevelUpMessage message)
        {
            var jobName = D2OParsing.GetJobName(message.JobsDescription.JobId);
            client.Logger.Log("Votre métier de " + jobName + " vient de passer niveau " + message.NewLevel);
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
            foreach (var job in client.Account.Character.Jobs)
                if (job.JobId == message.ExperiencesUpdate.JobId)
                {
                    job.JobLevel = message.ExperiencesUpdate.JobLevel;
                    job.JobXP = message.ExperiencesUpdate.JobXP;
                    job.JobXpLevelFloor = message.ExperiencesUpdate.JobXpLevelFloor;
                    job.JobXpNextLevelFloor = message.ExperiencesUpdate.JobXpNextLevelFloor;
                    break;
                }
            client.Logger.Log(
                $"{FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<API.Datacenter.Job>(message.ExperiencesUpdate.JobId).NameId)} | Level: {message.ExperiencesUpdate.JobLevel} | Exp: {message.ExperiencesUpdate.JobXP}");
        }
    }
}