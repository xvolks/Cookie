using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Game.Jobs;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job;
using Cookie.API.Protocol.Network.Messages.Game.Interactive;
using Cookie.API.Utils;
using Cookie.Core;

namespace Cookie.Game.Jobs
{
    public class GatherManager : IGatherManager
    {
        private readonly IAccount _account;

        public GatherManager(IAccount account)
        {
            _account = account;
            _account.Network.RegisterPacket<JobExperienceMultiUpdateMessage>(HandleJobExperienceMultiUpdateMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<JobLevelUpMessage>(HandleJobLevelUpMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<JobExperienceUpdateMessage>(HandleJobExperienceUpdateMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(HandleMapComplementaryInformationsDataMessage, MessagePriority.Normal);
            _account.Network.RegisterPacket<GameMapMovementCancelMessage>(HandleGameMapMovementCancelMessage, MessagePriority.Normal);
            _account.Network.RegisterPacket<GameMapMovementConfirmMessage>(HandleGameMapMovementConfirmMessage, MessagePriority.Normal);
            _account.Network.RegisterPacket<InteractiveElementUpdatedMessage>(HandleInteractiveElementUpdatedMessage, MessagePriority.Normal);
            _account.Network.RegisterPacket<InteractiveMapUpdateMessage>(HandleInteractiveMapUpdateMessage, MessagePriority.Normal);
        }

        private int SkillInstanceUid { get; set; } = -1;

        public int Id { get; set; } = -1;

        public bool IsFishing { get; set; }
        public bool Moved { get; set; }
        public bool Launched { get; set; }
        public List<int> ToGather { get; set; }

        public object Gather(List<int> @params)
        {
            Launched = true;
            Console.WriteLine(@"[GATHER] Lauching récolte");
            ToGather = @params;
            var listDistance = new List<int>();
            var listUsableElement = new List<IUsableElement>();
            try
            {
                if (ToGather.Count > 0)
                    foreach (var ressourceId in ToGather)
                    foreach (var usableElement in _account.Map.UsableElements)
                    foreach (var interactiveElement in _account.Map.InteractiveElements.Values)
                    {
                        if (usableElement.Value.Element.Id != interactiveElement.Id ||
                            !interactiveElement.IsUsable) continue;
                        if (interactiveElement.TypeId != ressourceId ||
                            !_account.Map.NoEntitiesOnCell(usableElement.Value.CellId))
                            continue;
                        listUsableElement.Add(usableElement.Value);
                        listDistance.Add(GetRessourceDistance((int) usableElement.Value.Element.Id));
                    }
                else
                    foreach (var usableElement in _account.Map.UsableElements)
                    foreach (var interactiveElement in _account.Map.InteractiveElements.Values)
                    {
                        if (usableElement.Value.Element.Id != interactiveElement.Id ||
                            !interactiveElement.IsUsable) continue;
                        if (!_account.Map.NoEntitiesOnCell(usableElement.Value.CellId)) continue;
                        listUsableElement.Add(usableElement.Value);
                        listDistance.Add(GetRessourceDistance((int) usableElement.Value.Element.Id));
                    }
                if (listDistance.Count <= 0) return false;
                {
                    foreach (var usableElement in TrierDistanceElement(listDistance, listUsableElement))
                    {
                        if (GetRessourceDistance((int) usableElement.Element.Id) == 1 || IsFishing)
                        {
                            if (Moved)
                                _account.Map.UseElement(Id, SkillInstanceUid);
                            else
                                _account.Map.UseElement((int) usableElement.Element.Id,
                                    usableElement.Skills[0].SkillInstanceUid);

                            Moved = false;
                            IsFishing = false;
                            return true;
                        }
                        if (!_account.Map.MoveToElement((int) usableElement.Element.Id, 1)) continue;
                        Id = (int) usableElement.Element.Id;
                        SkillInstanceUid = usableElement.Skills[0].SkillInstanceUid;
                        _account.Map.UseElement(Id, SkillInstanceUid);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public object Gather()
        {
            return Gather(ToGather);
        }

        public List<IUsableElement> TrierDistanceElement(List<int> listDistance, List<IUsableElement> listUsableElement)
        {
            var inOrder = false;

            var listLength = listDistance.Count;
            while (!inOrder)
            {
                inOrder = true;
                for (var i = 0; i <= listLength - 2; i++)
                {
                    if (listDistance[i] <= listDistance[i + 1]) continue;
                    object timeToAccess = listDistance[i];
                    listDistance[i] = listDistance[i + 1];
                    listDistance[i + 1] = Convert.ToInt32(timeToAccess);
                    timeToAccess = listUsableElement[i];
                    listUsableElement[i] = listUsableElement[i + 1];
                    listUsableElement[i + 1] = (IUsableElement) timeToAccess;
                    inOrder = false;
                }
                listLength = listLength - 1;
            }

            return listUsableElement;
        }

        private int GetRessourceDistance(int id)
        {
            var characterMapPoint = new MapPoint(_account.Character.CellId);
            var statedRessource = _account.Map.StatedElements.FirstOrDefault(se => se.Value.Id == id).Value;
            if (statedRessource == null) return -1;
            var ressourceMapPoint = new MapPoint((int) statedRessource.CellId);
            return characterMapPoint.DistanceTo(ressourceMapPoint);
        }

        private void HandleJobExperienceMultiUpdateMessage(IAccount account, JobExperienceMultiUpdateMessage message)
        {
            _account.Character.Jobs = message.ExperiencesUpdate;
        }

        private void HandleJobLevelUpMessage(IAccount account, JobLevelUpMessage message)
        {
            var jobName = D2OParsing.GetJobName(message.JobsDescription.JobId);
            Logger.Default.Log("Votre métier " + jobName + " vient de passer niveau " + message.NewLevel);
        }

        private void HandleJobExperienceUpdateMessage(IAccount account, JobExperienceUpdateMessage message)
        {
            foreach (var job in _account.Character.Jobs)
                if (job.JobId == message.ExperiencesUpdate.JobId)
                {
                    job.JobLevel = message.ExperiencesUpdate.JobLevel;
                    job.JobXP = message.ExperiencesUpdate.JobXP;
                    job.JobXpLevelFloor = message.ExperiencesUpdate.JobXpLevelFloor;
                    job.JobXpNextLevelFloor = message.ExperiencesUpdate.JobXpNextLevelFloor;
                    break;
                }
            Logger.Default.Log(
                $"{FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<API.Datacenter.Job>(message.ExperiencesUpdate.JobId).NameId)} | Level: {message.ExperiencesUpdate.JobLevel} | Exp: {message.ExperiencesUpdate.JobXP}");
        }

        private void HandleMapComplementaryInformationsDataMessage(IAccount account,
            MapComplementaryInformationsDataMessage message)
        {
            if (Launched)
                Gather();
        }

        private void HandleGameMapMovementCancelMessage(IAccount account, GameMapMovementCancelMessage message)
        {
            if (Id != -1)
                Id = -1;
        }

        private void HandleGameMapMovementConfirmMessage(IAccount account, GameMapMovementConfirmMessage message)
        {
            Moved = true;
        }

        private void HandleInteractiveElementUpdatedMessage(IAccount account, InteractiveElementUpdatedMessage message)
        {
            if (Launched && message.InteractiveElement.OnCurrentMap)
                Gather();
        }

        private void HandleInteractiveMapUpdateMessage(IAccount account, InteractiveMapUpdateMessage message)
        {
            if (message.InteractiveElements.Any(element => Launched && element.OnCurrentMap))
                Gather();
        }
    }
}