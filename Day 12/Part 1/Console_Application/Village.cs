using System;
using System.Collections.Generic;

namespace Console_Application
{
    public class Village
    {
        private int id;
        public readonly Dictionary<int, Village> ConnectedToVillages = new Dictionary<int, Village>();

        public Village(int id)
        {
            this.id = id;
        }

        public void AddPipeConnection(Village toVillage)
        {
            if (!ContainsConnectedVillage(toVillage))
                ConnectedToVillages.Add(toVillage.Id, toVillage);
            
            if (!toVillage.ContainsConnectedVillage(this))
                toVillage.AddPipeConnection(this);
        }

        public bool ContainsConnectedVillage(Village toVillage)
        {
            return ConnectedToVillages.ContainsKey(toVillage.Id);
        }

        public int Id => id;
    }
}