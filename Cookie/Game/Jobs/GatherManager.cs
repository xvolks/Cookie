using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Game.Jobs;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.Core;

namespace Cookie.Game.Jobs
{
    public class GatherManager : IGatherManager
    {
        private readonly Character _character;

        public GatherManager(Character character)
        {
            _character = character;
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
            //Client.Log(listeRessourcesId.Count.ToString());
            try
            {
                //Client.Log("Try Catch");
                if (ToGather.Count > 0)
                    foreach (var ressourceId in ToGather)
                    foreach (var usableElement in _character.Map.UsableElements)
                    foreach (var interactiveElement in _character.Map.InteractiveElements.Values)
                    {
                        if (usableElement.Value.Element.Id != interactiveElement.Id ||
                            !interactiveElement.IsUsable) continue;
                        if (interactiveElement.TypeId != ressourceId ||
                            !_character.Map.NoEntitiesOnCell(usableElement.Value.CellId))
                            continue;
                        listUsableElement.Add(usableElement.Value);
                        listDistance.Add(GetRessourceDistance((int) usableElement.Value.Element.Id));
                        //Client.Log(usableElement.Value.Element.Id.ToString());
                    }
                else
                    foreach (var usableElement in _character.Map.UsableElements)
                    foreach (var interactiveElement in _character.Map.InteractiveElements.Values)
                    {
                        if (usableElement.Value.Element.Id != interactiveElement.Id ||
                            !interactiveElement.IsUsable) continue;
                        if (!_character.Map.NoEntitiesOnCell(usableElement.Value.CellId)) continue;
                        listUsableElement.Add(usableElement.Value);
                        listDistance.Add(GetRessourceDistance((int) usableElement.Value.Element.Id));
                        //Client.Log(usableElement.Value.Element.Id.ToString());
                    }
                //Client.Log($"ListDistance.Count {listDistance.Count}");
                if (listDistance.Count <= 0) return false;
                {
                    foreach (var usableElement in TrierDistanceElement(listDistance, listUsableElement))
                    {
                        //Client.Log("FOREACH");
                        if (GetRessourceDistance((int) usableElement.Element.Id) == 1 || IsFishing)
                        {
                            if (Moved)
                                _character.Map.UseElement(Id, SkillInstanceUid);
                            else
                                _character.Map.UseElement((int) usableElement.Element.Id,
                                    usableElement.Skills[0].SkillInstanceUid);

                            Moved = false;
                            IsFishing = false;
                            //Console.WriteLine("Lol");
                            // Client.Log("LOL");
                            return true;
                        }
                        if (!_character.Map.MoveToElement((int) usableElement.Element.Id, 1)) continue;
                        //Client.Log("MOVING ? ");
                        Id = (int) usableElement.Element.Id;
                        SkillInstanceUid = usableElement.Skills[0].SkillInstanceUid;
                        _character.Map.UseElement(Id, SkillInstanceUid);
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
            var characterMapPoint = new MapPoint(_character.CellId);
            var statedRessource = _character.Map.StatedElements.FirstOrDefault(se => se.Value.Id == id).Value;
            if (statedRessource == null) return -1;
            var ressourceMapPoint = new MapPoint((int) statedRessource.CellId);
            return characterMapPoint.DistanceTo(ressourceMapPoint);
        }
    }
}