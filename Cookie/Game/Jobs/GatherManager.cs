using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Cookie.API.Core;
using Cookie.API.Datacenter;
using Cookie.API.Game.Jobs;
using Cookie.API.Game.Map;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using Cookie.Game.Map;

namespace Cookie.Game.Jobs
{
    public class GatherManager : IGatherManager
    {
        private readonly IAccount _account;
        #region Constructors
        public GatherManager(IAccount account)
        {
            _account = account;
            _account.Network.RegisterPacket<JobExperienceMultiUpdateMessage>(HandleJobExperienceMultiUpdateMessage,
                MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<JobLevelUpMessage>(HandleJobLevelUpMessage, MessagePriority.VeryHigh);
            _account.Network.RegisterPacket<JobExperienceUpdateMessage>(HandleJobExperienceUpdateMessage,
                MessagePriority.VeryHigh);

            //_account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(HandleMapComplementaryInformationsDataMessage, MessagePriority.Normal);
            //_account.Network.RegisterPacket<GameMapMovementCancelMessage>(HandleGameMapMovementCancelMessage, MessagePriority.Normal);
            //_account.Network.RegisterPacket<GameMapMovementConfirmMessage>(HandleGameMapMovementConfirmMessage, MessagePriority.Normal);
            //_account.Network.RegisterPacket<InteractiveElementUpdatedMessage>(HandleInteractiveElementUpdatedMessage, MessagePriority.Normal);
            //_account.Network.RegisterPacket<InteractiveMapUpdateMessage>(HandleInteractiveMapUpdateMessage, MessagePriority.Normal);
            Moved = false;
        }
        #endregion
        #region Variables
        private ICellMovement Move { get; set; }
        private int SkillInstanceUid { get; set; } = -1;
        public int Id { get; set; } = -1;
        public bool IsFishing { get; set; }
        public bool Moved { get; set; }
        public bool Launched { get; set; }
        public List<int> ToGather { get; set; }
        public bool AutoGather { get; set; }
        #endregion
        public void Launch()
        {
            if (!Launched)
                Launched = true;
        }

        public void Stop()
        {
            if (Launched)
                Launched = false;
        }

        public void DoAutoGather(bool arg)
        {
            AutoGather = !arg;
        }

        public void Gather(List<int> @params, bool autoGather)
        {
            if (@params.Count < 1) return;
            Launched = true;
            AutoGather = autoGather;
            ToGather = @params;
            if (Moved && Id != -1 && (GetRessourceDistance(Id) == 1))
            {
                Logger.Default.Log($"Moved[{Moved}] => Farming[{Id}]");
                _account.Character.Map.UseElement(Id, SkillInstanceUid);
                Id = -1;
                Moved = false;
                IsFishing = false;
                return;
            }
            var listDistance = new List<int>();
            var listUsableElement = new List<IUsableElement>();
            try
            {
                foreach (var ressourceId in ToGather)
                {
                    foreach (var usableElement in _account.Character.Map.UsableElements)
                    {
                        foreach (var interactiveElement in _account.Character.Map.InteractiveElements.Values)
                        {
                            if (usableElement.Value.Element.Id == interactiveElement.Id && interactiveElement.IsUsable
                                        && interactiveElement.TypeId == ressourceId/* && _account.Character.Map.NoEntitiesOnCell(usableElement.Value.CellId)*/)
                            {
                                listUsableElement.Add(usableElement.Value);
                                listDistance.Add(GetRessourceDistance((int)usableElement.Value.Element.Id));

                            }
                        }
                    }
                }
                if (listDistance.Count <= 0) return;
                foreach (var usableElement in TrierDistanceElement(listDistance, listUsableElement))
                {
                    Id = (int) usableElement.Element.Id;
                    SkillInstanceUid = usableElement.Skills[0].SkillInstanceUid;
                    Move = _account.Character.Map.MoveToElement(Id, 1);
                    Console.WriteLine($"Moving closer to element[{Id}]");
                    // after confirming that we actually moved closer to the element we launch Gather() once again to collect the ressource
                    Move.MovementFinished += Move_MovementFinished;
                    Move.PerformMovement();
                    break;
                }
                Launched = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Move_MovementFinished(object sender, CellMovementEventArgs e)
        {
            Move.MovementFinished -= Move_MovementFinished;
            if (e.Sucess)
            {
                Moved = true;
                Gather();
            }
            /*else if(_account.Character.PathManager.Launched)
                _account.Character.PathManager.DoAction();*/
        }

        public bool CanGatherOnMap(List<int> ids)
        {
            try
            {
                return ids.Count >= 1 && (from ressourceId in ids
                           from usableElement in _account.Character.Map.UsableElements
                           from interactiveElement in _account.Character.Map.InteractiveElements.Values
                           where usableElement.Value.Element.Id == interactiveElement.Id && interactiveElement.IsUsable
                           where interactiveElement.TypeId == ressourceId &&
                                 _account.Character.Map.NoEntitiesOnCell(usableElement.Value.CellId)
                           select ressourceId).Any();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void Gather()
        {
            Gather(ToGather, AutoGather);
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
            var statedRessource = _account.Character.Map.StatedElements.FirstOrDefault(se => se.Value.Id == id).Value;
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
                $"{FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Job>(message.ExperiencesUpdate.JobId).NameId)} | Level: {message.ExperiencesUpdate.JobLevel} | Exp: {message.ExperiencesUpdate.JobXP}");
        }
        private void HandleMapComplementaryInformationsDataMessage(IAccount account,
            MapComplementaryInformationsDataMessage message)
        {
            if (!AutoGather) return;
            Launched = true;
            account.PerformAction(Gather, 1000);
        }

        private void HandleGameMapMovementCancelMessage(IAccount account, GameMapMovementCancelMessage message)
        {
            if (Id != -1)
                Id = -1;
        }
        private void HandleGameMapMovementConfirmMessage(IAccount account, GameMapMovementConfirmMessage message)
        {
            //moviment finished being displayed
            Moved = true;
        }
        /*
        private void HandleInteractiveElementUpdatedMessage(IAccount account, InteractiveElementUpdatedMessage message)
        {
            Console.WriteLine($"InteractiveElementUpdatedMessage");
            if (account.Character.PathManager.Launched)
            {
                account.PerformAction(account.Character.PathManager.DoAction, 1000);
            }
            if (!AutoGather || !message.InteractiveElement.OnCurrentMap) return;
            Launched = true;
            account.PerformAction(Gather, 1000);
        }
        */
        /*
        private void HandleInteractiveMapUpdateMessage(IAccount account, InteractiveMapUpdateMessage message)
        {
            //this is being handled inside Character.Map
            Console.WriteLine($"InteractiveMapUpdateMessage");
            if (!message.InteractiveElements.Any(element => Launched && element.OnCurrentMap) || !AutoGather) return;
            Launched = true;
            account.PerformAction(Gather, 1000);
        }
        */
    }
}