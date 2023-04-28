using ECS.Interfaces;
using UnityEngine;

namespace Implementations
{
    public class GameObjectHandler : IGameObjectHandler
    {
        private readonly GameObject collectiblePrefab;

        public GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(collectiblePrefab, position, rotation);
        }
    }
}