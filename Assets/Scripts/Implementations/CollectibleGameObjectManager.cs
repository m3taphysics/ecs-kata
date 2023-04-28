using ECS.Interfaces;
using UnityEngine;

namespace Implementations
{
    public class GameObjectHandler : IGameObjectHandler
    {
        private readonly GameObject collectiblePrefab;

        public GameObject Instantiate(Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(collectiblePrefab, position, rotation);
        }
        
        public GameObject Destroy(GameObject gameObject)
        {
            
        }
    }
}