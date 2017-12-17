using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Application
{
    public class VillageCommunicationHandler
    {
        Dictionary<int, Village> villages = new Dictionary<int, Village>();

        public int CountAmountOfVillagesConnectedToId(int id)
        {
            if (!villages.ContainsKey(id))
                throw new Exception($"Village with id '{id}' doesn't exist!");
            
            List<int> addedVillagedToQueue = new List<int>{id};
            List<int> countedVillages = new List<int>();
            Queue<Village> villageQueue = new Queue<Village>();
            villageQueue.Enqueue(villages[id]);

            while (villageQueue.Count > 0)
            {
                Village currentVillage = villageQueue.Dequeue();
                
                foreach (Village village in currentVillage.ConnectedToVillages.Values)
                {
                    if (!addedVillagedToQueue.Contains(village.Id))
                    {
                        addedVillagedToQueue.Add(village.Id);
                        villageQueue.Enqueue(village);
                    }
                }
                
                countedVillages.Add(currentVillage.Id);
            }
            
            return countedVillages.Count;
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