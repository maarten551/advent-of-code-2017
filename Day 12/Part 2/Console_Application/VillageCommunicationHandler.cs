using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Application
{
    public class VillageCommunicationHandler
    {
        Dictionary<int, Village> villages = new Dictionary<int, Village>();

        public int CountAmountOfVillagesGroups()
        {
            List<int> countedVillages = new List<int>();
            List<List<Village>> villageGroups = new List<List<Village>>();

            foreach (Village village in villages.Values)
            {
                if (!countedVillages.Contains(village.Id))
                {
                    List<Village> addedVillagedToQueue = new List<Village>{village};
                    Queue<Village> villageQueue = new Queue<Village>();
                    villageQueue.Enqueue(village);

                    while (villageQueue.Count > 0)
                    {
                        Village currentVillage = villageQueue.Dequeue();
                
                        foreach (Village villageInGroup in currentVillage.ConnectedToVillages.Values)
                        {
                            if (!addedVillagedToQueue.Contains(villageInGroup))
                            {
                                addedVillagedToQueue.Add(villageInGroup);
                                villageQueue.Enqueue(villageInGroup);
                            }
                        }
                
                        countedVillages.Add(currentVillage.Id);
                    }
                    
                    villageGroups.Add(addedVillagedToQueue);
                }
            }
            
            return villageGroups.Count;
        }
        
        public void AddVillage(int villageId, int[] connectedToVillages)
        {
            Village village = GetOrCreateVillage(villageId);

            foreach (Village connectToVillage in connectedToVillages.Select(GetOrCreateVillage))
                village.AddPipeConnection(connectToVillage);
        }

        private Village GetOrCreateVillage(int id)
        {
            if (villages.ContainsKey(id))
                return villages[id];

            Village newVillage = new Village(id);
            villages[id] = newVillage;

            return newVillage;
        }
    }
}