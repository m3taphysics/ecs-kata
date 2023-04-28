using UnityEngine;

namespace ECS.Components
{
    public class PrefabReferenceComponent
    {
        public string gameObjectReference;

        public PrefabReferenceComponent(string prefabName)
        {
            this.gameObjectReference = prefabName;
        }
    }
}